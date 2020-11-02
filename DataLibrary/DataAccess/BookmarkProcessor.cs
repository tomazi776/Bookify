using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DataAccess
{
    public class BookmarkProcessor : IBookmarkProcessor
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public BookmarkProcessor(ISqlDataAccess dataAccess)
        {
            _sqlDataAccess = dataAccess;
        }
        public int CreateBookmark(int bookmarkId, string name, string webAddress, string filePath, string icon, int userId )
        {
            //For usage reference
            //string query = @"INSERT INTO [Bookmark] (BookmarkId, Name, WebAddress, FilePath, Icon, UserId)
            //                 values (@BookmarkId, @WebAddress, @FilePath, @Icon, @UserId);";

            //var data = new BookmarkModel()
            //{
            //    BookmarkId = bookmarkId,
            //    Name = name,
            //    WebAddress = webAddress,
            //    FilePath = filePath,
            //    Icon = icon,
            //    UserId = userId
            //};

            var sp = "dbo.spInsert_Bookmark";
            var rowsAffected = _sqlDataAccess.SaveData(sp, new {
                BookmarkId = bookmarkId, 
                Name = name, 
                WebAddress = webAddress, 
                FilePath = filePath, 
                Icon = icon, 
                UserId = userId }, System.Data.CommandType.StoredProcedure);
            return rowsAffected;
        }

        public List<BookmarkModel> GetAllBookmarks(int userId)
        {
            string query = $@"SELECT BookmarkId, Name, WebAddress, FilePath, Icon, UserId 
                             FROM [Bookmark]
                             WHERE UserId = '{userId}';";
            return _sqlDataAccess.LoadAllData<BookmarkModel>(query);
        }
    }
}
