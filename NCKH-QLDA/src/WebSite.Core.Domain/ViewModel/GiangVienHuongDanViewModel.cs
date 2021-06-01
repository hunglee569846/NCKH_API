using System;
using System.Collections.Generic;
using System.Text;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.ViewModel
{
    public class GiangVienHuongDanViewModel
    {
        public string IdGVHDTheoKy { get; set; }
        public string IdGVHD { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string IdHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string DonViCongTac { get; set; }
        public string Email { get; set; }
        public int? DienThoai { get; set; }
        public TypeGVHD Type { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayXoa { get; set; }
    }
}
