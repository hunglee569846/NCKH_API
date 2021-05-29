using System;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.Models
{
    public class GVHDTheoKy
    {
        public string IdGVHDTheoKy { get; set; }
        public string IdGVHD { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string IdHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string DonViCongTac { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public TypeGVHD Type { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayXoa { get; set; }
        public GVHDTheoKy()
        {
            NgayTao = DateTime.Now;
            NgayXoa = null;
            IsActive = true;
            IsDelete = false;
        }
    }
}
