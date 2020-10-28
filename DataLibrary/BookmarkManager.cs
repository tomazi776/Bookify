using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLibrary
{
    public class BookmarkManager
    {
        private string envPath;
        public Dictionary<string, string>  Bookmarks { get; set; }
        private void GetAllBookmarks()
        {

        }
        public BookmarkManager(string environmentPath)
        {
            envPath = environmentPath;
            ReadBookmarksFile();
        }
        private void ReadBookmarksFile()
        {
            var folderPath = envPath + @"\Resources\";
            var importedBookmarksDir = Directory.CreateDirectory(Path.Combine(folderPath, "ImportedBookmarks"));
            var file = importedBookmarksDir.GetFiles()[0];

            using (StreamReader streamReader = new StreamReader(file.FullName))
            {
                string html = streamReader.ReadToEnd();
                var ddd = "";
            }
        }
    }
}
