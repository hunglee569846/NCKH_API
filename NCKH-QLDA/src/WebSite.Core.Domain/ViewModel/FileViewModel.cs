using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class FileViewModel
    {
        public string IdFile { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Type { get; set; }
        public float Size { get; set; }
        public string Url { get; set; }
        public int? FolderId { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
    }
}
