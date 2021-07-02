using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.Models
{
    public class BangDiem
    {
		public string IdBangDiem { get; set; }
		public string IdBoMon { get; set; }
		public string IdDeTai { get; set; }
		public string IdSinhVien { get; set; }
		public string IdHocKy { get; set; }
		public string IdMonHoc { get; set; }
		public string IdHoiDong { get; set; }
		public string IdGiangVien { get; set; }
		public string NhanXetGV { get; set; }
		public float DiemSo { get; set; }
		public DateTime? NgayVaoDiem { get; set; }
		public string CreatorPointUserId { get; set; }
		public string CreatorPointFullName { get; set; }
		public DateTime CreateTime { get; set; }
		public string CreatorUserId { get; set; }
		public string CreatorFullName { get; set; }
		public DateTime? LastUpdate { get; set; }
		public string LastUpdateUserId { get; set; }
		public string LastUpdateFullName { get; set; }
		public DateTime? DeleteTime { get; set; }
		public string DeleteUserId { get; set; }
		public string DeleteFullName { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }

		public BangDiem()
		{
			IsDelete = false;
			IsActive = true;
			CreateTime = DateTime.Now;
			LastUpdate = null;
			DeleteTime = null;
		}

	}
}
