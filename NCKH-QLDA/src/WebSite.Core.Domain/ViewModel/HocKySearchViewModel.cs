using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class HocKySearchViewModel
    {
        public string IdHocKy { get; set; }
        public string IdBoMon { get; set; }
        public string MaHocKy { get; set; }
        public string NamHoc { get; set; }
        public string TenHocKy { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? LockData { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
