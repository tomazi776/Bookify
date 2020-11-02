using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.DataAccess
{
    public interface IBookmarkProcessor
    {
        List<BookmarkModel> GetAllBookmarks(int userId);
        int CreateBookmark(int bookmarkId, string name, string webAddress, string filePath, string icon, int userId );        
    }
}