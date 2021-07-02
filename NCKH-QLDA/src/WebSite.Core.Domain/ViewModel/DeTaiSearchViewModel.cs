using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class DeTaiSearchViewModel
    {
        public string IdDeTai { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string IdSinhVien { get; set; }
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string IdHocKy { get; set; }
        public string TenHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public float? DiemTrungBinh { get; set; }
        public bool? IsDat { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeteteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CreatorUserId { get; set; }
        public string lastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }


    }
}
