using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Core.Domain.ViewModel
{
    public class ChuyenNganhViewModel
    {
        public string Id { get; set; }
        public string MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public string VanPhong { get; set; }
        public string HopThu { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
