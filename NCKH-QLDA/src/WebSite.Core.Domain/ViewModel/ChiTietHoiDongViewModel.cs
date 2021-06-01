using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class ChiTietHoiDongViewModel
    {
        public string IdChiTietHD { get; set; }
        public string IdHoiDong { get; set; }
        public string MaHoiDong { get; set; }
        public string TenHoiDong { get; set; }
        public string IdGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
