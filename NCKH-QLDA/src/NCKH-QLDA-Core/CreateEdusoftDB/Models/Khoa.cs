namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Khoa
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string MaKhoa { get; set; }

        [Required]
        [StringLength(300)]
        public string TenKhoa { get; set; }

        public bool? IsDelete { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayCapNhat { get; set; }
    }
}
