using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Core.Domain.ViewModel
{
    public class ThongTinGiangVienViewModel
    {
		public string Id { get; set; }
		public string IdThongTinChung { get; set; }
		public string MaNhomChuyenNganh { get; set; }
		public string TenNhomChuyenNganh { get; set; }
		public string MaGiangVien { get; set; }
		public string DonViCongTac { get; set; }
		public string HoDem { get; set; }
		public string Ten { get; set; }
		public string HoTen { get; set; }
		public string HomThu { get; set; }
		public string DienThoai { get; set; }
		public string IdKhoa { get; set; }
		public string TenKhoa { get; set; }
		public string IdBoMon { get; set; }
		public string TenBoMon { get; set; }
		public string IdNganh { get; set; }
		public string TenNganh { get; set; }
		public string IdChuyenNganh { get; set; }
		public string TenChuyenNganh { get; set; }
		public DateTime? NgayTao { get; set; }
		public bool? IsActive { get; set; }
	}
}
