namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SinhVien
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSinhVien { get; set; }

        [StringLength(50)]
        public string HoDem { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        public string HomThu { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLop { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayTao { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }
    }
}
