using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class BookmarkModel
    {
        public int Id { get; set; }
        public int BookmarkId { get; set; }
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string FilePath { get; set; }
        public string Icon { get; set; }
        public int UserId { get; set; }
    }
}
