using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class HocKy
    {
        public string IdHocKy { get; set; }
        public string MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayXoa { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatetorId { get; set; }
        public string CreatorFullName { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateFullName { get; set; }
        public HocKy()
        {
            NgayTao = DateTime.Now;
            NgayXoa = null;
            IsActive = true;
            IsDelete = false;
        }
    }
}
