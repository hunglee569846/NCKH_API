using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class PhanBien
    {
        public string IdPhanBien { get; set; }
        public string IdGVPB { get; set; }
        public string MaGVPB { get; set; }
        public string TenGVPB { get; set; }
        public string IdDetai { get; set; }
        public string MaDeTai { get; set; }
        public float? Diem { get; set; }
        public string Note { get; set; }
        public string IdHocKy { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public PhanBien()
        {
            Diem = 0;
            NgayTao = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
