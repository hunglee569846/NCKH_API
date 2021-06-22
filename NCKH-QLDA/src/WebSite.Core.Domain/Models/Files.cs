using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class Files
    {
        public string Id { get; set; }
        public string IdBoMon { get; set; }
        public string FileCode { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int? Folderld { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string CreatorUserId { get; set; }
        public string lastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public Files()
        {
            CreateDate = DateTime.Now;
            LastUpdate = null;
            DeleteTime = null;
            IsActive = true;
            IsDelete = false;
        }
    }
}
