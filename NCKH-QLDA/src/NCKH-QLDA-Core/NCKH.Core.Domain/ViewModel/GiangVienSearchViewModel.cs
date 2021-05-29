using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Core.Domain.ViewModel
{
	public class GiangVienSearchViewModel
	{
		public string Id { get; set; }
		public string MaGiangVien { get; set; }
		public string HoDem { get; set; }
		public string Ten { get; set; }
		public string HoTen { get; set; }
		public string HomThu { get; set; }
		public string GhiChu { get; set; }
		public string DonViCongTac { get; set; }
		public string DienThoai { get; set; }
		public int? SoDeTai { get; set; }
		public string IdThongTinChung { get; set; }
		public string TenThongTinChung { get; set; }
		public DateTime? NgayTao { get; set; }
		public DateTime? NgayCapNhat { get; set; }
		public bool? IsActive { get; set; }
	}

}
