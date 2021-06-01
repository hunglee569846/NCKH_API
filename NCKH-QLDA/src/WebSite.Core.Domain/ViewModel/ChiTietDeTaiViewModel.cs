using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class ChiTietDeTaiViewModel
    {
        public string IdChiTietDeTai { get; set; }
        public string IdDeTai { get; set; }
        public string MaDeTai { get; set; }
        public string IdGVHD { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public double? DiemSo { get; set; }
        public string NhanXet { get; set; }
        public string TeNguoiTao { get; set; }
        public string MaNguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
