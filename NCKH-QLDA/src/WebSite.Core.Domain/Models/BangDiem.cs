using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class BangDiem
    {
        public string IdBangDien { get; set; }
        public string IdDeTai { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string IdSinhVien { get; set; }
        public string IdHocKy { get; set; }
        public string TenHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public string IdHoiDong { get; set; }
        public string MaHoiDong { get; set; }
        public string TenHoiDong { get; set; }
        public string IdGiangVien { get; set; }
        public string MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public string NhanXetGV { get; set; }
        public float DiemSo { get; set; }
        public DateTime? NgayVaoDiem { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string NgaySua { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateFullName { get; set; }
        public BangDiem()
        {
            NgayTao = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
