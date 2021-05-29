namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nganh
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string MaNganh { get; set; }

        [Required]
        [StringLength(500)]
        public string TenNganh { get; set; }

        [Required]
        [StringLength(50)]
        public string IdBoMon { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayTao { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayCapNhat { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayXoa { get; set; }
    }
}
