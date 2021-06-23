using System;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.Models
{
    public class GVHDTheoKy
    {
        public string IdGVHDTheoKy { get; set; }
        public string IdGVHD { get; set; }
        public string IdBoMon { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string IdHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string DonViCongTac { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public TypeGVHD Type { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeteteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CreatorUserId { get; set; }
        public string lastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }
        public GVHDTheoKy()
        {
            CreateTime = DateTime.Now;
            IsActive = true;
            IsDelete = false;
        }
    }
}
