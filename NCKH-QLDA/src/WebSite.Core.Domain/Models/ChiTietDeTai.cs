using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class ChiTietDeTai
    {
        public string IdChiTietDeTai { get; set; }
        public string IdDeTai { get; set; }
        public string MaDeTai { get; set; }
        public string IdGVHD { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public float? DiemSo { get; set; }
        public string NhanXet { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeteteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CreatorUserId { get; set; }
        public string lastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public ChiTietDeTai()
        {
            CreateTime = DateTime.Now;
            IsActive = true;
            IsDelete = false;
            DiemSo = 0;
        }
    }
}
