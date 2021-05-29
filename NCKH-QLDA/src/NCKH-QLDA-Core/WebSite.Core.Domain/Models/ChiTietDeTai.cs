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
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public DateTime? NgayXoa { get; set; }
        public string MaNguoiTao { get; set; }
        public string TenNguoiTao { get; set; }
        public string MaNguoiSua { get; set; }
        public string TenNguoiSua { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public ChiTietDeTai()
        {
            NgayTao = DateTime.Now;
            IsActive = true;
            IsDelete = false;
            DiemSo = 0;
        }
    }
}
