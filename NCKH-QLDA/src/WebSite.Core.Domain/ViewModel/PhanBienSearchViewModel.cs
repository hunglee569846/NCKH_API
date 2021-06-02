using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class PhanBienSearchViewModel
    {
        public string IdPhanBien { get; set; }
        public string IdGVPB { get; set; }
        public string MaGVPB { get; set; }
        public string TenGVPB { get; set; }
        public string IdDetai { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public float? Diem { get; set; }
        public string Note { get; set; }
        public string IdHocKy { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatorUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
    }
}
