using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class ChiTietHoiDong
    {
        public string IdChiTietHD { get; set; }
        public string IdBoMon { get; set; }
        public string IdHoiDong { get; set; }
        public string TenHoiDong { get; set; }
        public string IdGiangVien { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateFullName { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public ChiTietHoiDong()
        {
            CreateTime = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
