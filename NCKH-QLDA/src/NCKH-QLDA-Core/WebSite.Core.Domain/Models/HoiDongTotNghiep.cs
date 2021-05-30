using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class HoiDongTotNghiep
    {
        public string IdHoiDong { get; set; }
        public string MaHoiDong { get; set; }
        public string TenHoiDong { get; set; }
        public string IdHocKy { get; set; }
        public string TenHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
        public DateTime NgayBaoVe { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateFullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public HoiDongTotNghiep()
        {
            NgayTao = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
