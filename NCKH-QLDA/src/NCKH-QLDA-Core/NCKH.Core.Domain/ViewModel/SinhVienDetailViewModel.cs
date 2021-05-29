using System;
using System.Collections.Generic;
namespace GHM.NailSpa.Domain.ViewModels
{
	public class SinhVienDetailViewModel
	{
		public string Id { get; set; }
		public string MaSinhVien { get; set; }
		public string HoDem { get; set; }
		public string Ten { get; set; }
		public string HoTen { get; set; }
		public string HomThu { get; set; }
		public string IdLop { get; set; }
		public string MaLop { get; set; }
		public string DienThoai { get; set; }
		public DateTime? NgayTao { get; set; }
		public bool? IsActive { get; set; }
	}
}