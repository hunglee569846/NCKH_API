using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class SinhVienSearchViewModel
    {
        public string IdSinhVien { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DonViThucTap { get; set; }
        public string LopHoc { get; set; }
        public string IdHocKy { get; set; }
        public string TenChuyenNganh { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
    }
}
