namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ChuongTrinhDaoTao
    {
        public string Id { get; set; }
        public string MaChuongTrinhDaoTao { get; set; }
        public string TenChuongTrinhDaoTao { get; set; }
        public string HeDaoTao { get; set; }
        public int ThoiGianDaoTao { get; set; }
        public int SoTinChi { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
}
