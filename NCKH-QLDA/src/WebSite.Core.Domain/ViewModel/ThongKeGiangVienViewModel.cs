using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class ThongKeGiangVienViewModel
    {
        public string IdGVHD { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DonViCongTac { get; set; }
        public int SoLuongHD { get; set; }
        public int SoLuongPB { get; set; }
        public int SoLuongHoiDong { get; set; }
    }
}
