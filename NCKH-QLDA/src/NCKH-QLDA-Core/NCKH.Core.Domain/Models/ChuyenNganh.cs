namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChuyenNganh
    {
        public string Id { get; set; }
        public string MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public string VanPhong { get; set; }
        public string HopThu { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
        public string MaNganh { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public ChuyenNganh()
        {
            NgayCapNhat = null;
            NgayTao = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
