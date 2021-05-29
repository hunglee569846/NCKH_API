namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Nganh
    {
		public string Id { get; set; }
		public string MaNganh { get; set; }
		public string TenNganh { get; set; }
		public string IdBoMon { get; set; }
		public DateTime? NgayTao { get; set; }
		public bool? IsDelete { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? NgayCapNhat { get; set; }
		public DateTime? NgayXoa { get; set; }

		public Nganh()
		{
			IsDelete = false;
			IsActive = true;
			NgayTao = DateTime.Now;
			NgayCapNhat = null;
			NgayXoa = null;
		}
	}
}
