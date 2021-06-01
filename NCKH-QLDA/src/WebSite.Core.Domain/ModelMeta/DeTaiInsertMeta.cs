using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ModelMeta
{
    public class DeTaiInsertMeta
    {
        public string TenDeTai { get; set; }
        public double? DiemTrungBinh { get; set; }
       // public string NguoiTao { get; set; }
        public string DonViThucTap { get; set; }
        public bool IsApprove { get; set; }
        public string Email { get; set; }
    }
}
