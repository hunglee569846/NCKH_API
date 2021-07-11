using System;
using System.Collections.Generic;
using System.Text;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.ViewModel
{
    public class GiangVienGetListViewModel
    {
        public string IdChiTietHoiDong { get; set; }
        public string IdGVHDTheoKy { get; set; }
        public string IdGiangVien { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string IdHocKy { get; set; }
        public string DonViCongTac { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public TypeGVHD Type { get; set; }
    }
}
