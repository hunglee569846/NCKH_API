namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class KetQuaHocTap
    {
        public string Id { get; set; }
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }
        public int TinChiTichLuy { get; set; }
        public int TinChiThieu { get; set; }
        public double DiemTBTichLuy { get; set; }
    }
}
