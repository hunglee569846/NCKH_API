using System;
using System.Collections.Generic;
using System.Text;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.Models
{
	public class MonHoc
	{
		public string IdMonHoc { get; set; }
		public string IdBoMon { get; set; }
		public string MaMonHoc { get; set; }
		public string IdHocKy { get; set; }
		public string TenMonHoc { get; set; }
		public int? TypeApprover { get; set; }
		public string IdMonTienQuyet { get; set; }
		public string NameMonTienQuyet { get; set; }
		public int SoLuongGVHD{ get; set; }
		public int SoLuongPhanBien{ get; set; }
		public DateTime? LastUpdate { get; set; }
		public DateTime CreateTime { get; set; }
		public string CreatorUserId { get; set; }
		public string CreatorFullName { get; set; }
		public string LastUpdateUserId { get; set; }
		public string LastUpdateFullName { get; set; }
		public DateTime? DeleteTime { get; set; }
		public string DeleteTimeUserId { get; set; }
		public string DeleteTimeFullName { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }

		public MonHoc()
		{
			IsDelete = false;
			IsActive = true;
			CreateTime = DateTime.Now;
			LastUpdate = null;
			DeleteTime = null;
		}
	}
}
