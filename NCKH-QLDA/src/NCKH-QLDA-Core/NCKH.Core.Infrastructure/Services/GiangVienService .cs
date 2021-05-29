using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
	public class GiangVienService : IGiangVienService
	{
		private readonly IGiangVienRepository _giangVienRepository;
		public GiangVienService(IGiangVienRepository giangVienRepository)
		{
			_giangVienRepository = giangVienRepository;
		}


		//public async Task<SearchResult<GiangVienSearchViewModel>> SearchAsync(string keyword, int page, int pageSize)
		//{
		//	return await _giangVienRepository.SearchAsync(keyword, page, pageSize);
		//}


		public async Task<List<GiangVienSearchViewModel>> SelectAllAsync()
		{
			return await _giangVienRepository.SelectAllAsync();
		}

        public async Task<ActionResultResponese<ThongTinGiangVienViewModel>> GetDetailAsync(string id)
        {
            var info = await _giangVienRepository.GetInfoAsync(id);
            if (info == null)
                return new ActionResultResponese<ThongTinGiangVienViewModel>(-1, "Không tồn tại.", "SinhVien");

            var giangvien = new ThongTinGiangVienViewModel
            {
                IdThongTinChung = info.IdThongTinChung,
                MaGiangVien = info.MaGiangVien,
                MaNhomChuyenNganh = info.MaNhomChuyenNganh,
                TenNhomChuyenNganh = info.TenNhomChuyenNganh,
                DonViCongTac = info.DonViCongTac,
                HoDem = info.HoDem,
                Ten = info.Ten,
                HoTen = info.HoTen,
                HomThu = info.HomThu,
                DienThoai = info.DienThoai,
                NgayTao = info.NgayTao,
                IsActive = info.IsActive,
                IdKhoa = info.IdKhoa,
                TenKhoa = info.TenKhoa,
                IdBoMon = info.IdBoMon,
                TenBoMon = info.TenBoMon,
                IdNganh = info.IdNganh,
                TenNganh = info.TenNganh,
                IdChuyenNganh = info.IdChuyenNganh,
                TenChuyenNganh = info.TenChuyenNganh

            };
            return new ActionResultResponese<ThongTinGiangVienViewModel>
            {
                Code = 1,
                Data = giangvien
            };
        }
    } 
}
