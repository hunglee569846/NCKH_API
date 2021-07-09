using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class HoiDongSearchViewModel
    {
        public string IdHoiDong { get; set; }
        public string MaHoiDong { get; set; }
        public string TenHoiDong { get; set; }
        public string IdHocKy { get; set; }
        public string TenHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string DiaDiem { get; set; }
        public string NgayBaoVe { get; set; }
        public List<ChiTietThanhVienHDViewModel> ThanhVienHD { get; set; }
    }
}
