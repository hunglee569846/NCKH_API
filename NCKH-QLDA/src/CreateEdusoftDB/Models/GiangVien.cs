namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GiangVien
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaGiangVien { get; set; }

        [StringLength(200)]
        public string HoDem { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        public string HomThu { get; set; }

        [StringLength(50)]
        public string MaBoMon { get; set; }

        public string GhiChu { get; set; }

        [StringLength(500)]
        public string DonViCongTac { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        public int? SoDeTai { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayCapNhat { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }
    }
}
