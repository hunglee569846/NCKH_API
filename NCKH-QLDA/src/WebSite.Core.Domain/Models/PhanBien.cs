using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class PhanBien
    {
        public string IdPhanBien { get; set; }
        public string IdGVPB { get; set; }
        public string IdBoMon { get; set; }
        public string IdDetai { get; set; }
        public float Diem { get; set; }
        public string Note { get; set; }
        public string IdHocKy { get; set; }
        public string IdMonHoc { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string CreatorUserId { get; set; }
        public string lastUpdateUserId { get; set; }
        public string DeleteUserId { get; set; }
        public string CreatorFullName { get; set; }
        public string DeleteFullName { get; set; }
        public string LastUpdateFullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public PhanBien()
        {
            Diem = 0;
            CreateTime = DateTime.Now;
            IsDelete = false;
            IsActive = true;
        }
    }
}
