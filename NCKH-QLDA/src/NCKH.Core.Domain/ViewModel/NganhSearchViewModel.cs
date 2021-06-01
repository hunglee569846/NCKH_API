using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Core.Domain.ViewModel
{
	public class NganhSearchViewModel
	{
		public string Id { get; set; }
		public string MaNganh { get; set; }
		public string TenNganh { get; set; }
		public string IdBoMon { get; set; }
		public DateTime? NgayTao { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? NgayCapNhat { get; set; }
		public DateTime? NgayXoa { get; set; }
	}

}
