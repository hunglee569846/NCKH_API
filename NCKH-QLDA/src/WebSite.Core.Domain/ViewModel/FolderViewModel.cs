using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class FolderViewModel
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string IdPath { get; set; }
        public string NamePath { get; set; }
        public string ParentId { get; set; }
        public string Description { get; set; }
        public int ChildCount { get; set; }
        public int Livel { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
