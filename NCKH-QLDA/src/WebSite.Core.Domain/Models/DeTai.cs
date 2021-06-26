using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
   public class DeTai
    {
		public string IdDeTai { get; set; }
		public string IdBoMon { get; set; }
		public string MaDeTai { get; set; }
		public string TenDeTai { get; set; }
		public string IdSinhVien { get; set; }
		public string IdHocKy { get; set; }
		public string IdMonHoc { get; set; }
		public float? DiemTrungBinh { get; set; }
		public bool? IsDat { get; set; }
		public bool? IsApprove { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? DeleteTime { get; set; }
		public DateTime? LastUpdate { get; set; }
		public string lastUpdateUserId { get; set; }
		public string DeleteUserId { get; set; }
		public string CreatorUserId { get; set; }
		public string CreatorFullName { get; set; }
		public string LastUpdateFullName { get; set; }
		public string DeleteFullName { get; set; }

		public DeTai()
		{
			IsDelete = false;
			IsActive = true;
			CreateTime = DateTime.Now;
			LastUpdate = null;
			DeleteTime = null;
		}

	}
}
