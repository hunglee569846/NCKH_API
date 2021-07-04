using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class DeTaiPhanBienViewModel
    {
        public string IdDeTai { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string IdSinhVien { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DonViThucTap { get; set; }
    }
}
