namespace CreateEdusoftDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQuaHocTap")]
    public partial class KetQuaHocTap
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaSinhVien { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLop { get; set; }

        public int TinChiTichLuy { get; set; }

        public int TinChiThieu { get; set; }

        public double DiemTBTichLuy { get; set; }
    }
}
