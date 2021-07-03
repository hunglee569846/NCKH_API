using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class HocKy
	{
		public string IdHocKy { get; set; }
		public string IdBoMon { get; set; }
		public string MaHocKy { get; set; }
		public string TenHocKy { get; set; }
		public string NamHoc { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime? LastUpdate { get; set; }
		public DateTime? DeleteTime { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
		public bool IsLockData { get; set; }
		public string CreatetorId { get; set; }
		public string CreatorFullName { get; set; }
		public string LastUpdateUserId { get; set; }
		public string LastUpdateFullName { get; set; }

		public HocKy()
		{
			IsDelete = false;
			IsActive = true;
			CreateTime = DateTime.Now;
			LastUpdate = null;
			DeleteTime = null;
		}
	}

}
