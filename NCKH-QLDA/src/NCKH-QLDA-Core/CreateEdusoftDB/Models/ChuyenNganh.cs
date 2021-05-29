namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChuyenNganh
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaChuyenNganh { get; set; }

        [Required]
        [StringLength(500)]
        public string TenChuyenNganh { get; set; }

        [StringLength(300)]
        public string VanPhong { get; set; }

        [StringLength(300)]
        public string HopThu { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNganh { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayCapNhat { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayTao { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }
    }
}
