using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class SinhVien
    {
        public string IdSinhVien { get; set; }
        public string IdBoMon { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DonViThucTap { get; set; }
        public string MaLopHoc { get; set; }
        public string LopHoc { get; set; }
        public string IdHocKy { get; set; }
        public string MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CreatorUserId { get; set; }
        public string LastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }

        public SinhVien()
        {
            CreateTime = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
