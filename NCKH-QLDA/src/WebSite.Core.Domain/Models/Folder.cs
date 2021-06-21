using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string IdBoMon { get; set; }
        //public int FolderId { get; set; }
        //public string IdPath { get; set; }
        //public string NamePath { get; set; }
        //public string ParentId { get; set; }
        //public string Description { get; set; }
        //public int Level { get; set; }
        //public int ChildCount { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public Folder()
        {
            CreateTime = DateTime.Now;
            LastUpdate = null;
            DeleteTime = null;
            IsDelete = false;
            IsActive = true;
        }
    }
}
