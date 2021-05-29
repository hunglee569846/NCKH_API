namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema; 

    public class SinhVien
    {
        public string Id { get; set; }
        public string MaSinhVien { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public string HomThu { get; set; }
        public string IdLop { get; set; }
        public string MaLop { get; set; }
        public string DienThoai { get; set; }
        public string TinChiTichLuy { get; set; }
        public string DiemTichLuy { get; set; }
        public string IdThongTinChung { get; set; }
        public string TenThongTinChung { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
