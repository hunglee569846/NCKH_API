using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSite.Core.Domain.Constansts;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Services
{
    public class GiangVienHuongDanService : IGiangVienHuongDanService
	{
		private readonly IGiangVienHuongDanRepository _giangVienHuongDanRepository;
		private readonly IHocKysRepository _hockyRepository;
		private readonly IMonHocRepository _monhocRepository;
		public GiangVienHuongDanService(IGiangVienHuongDanRepository giangVienHuongDanRepository, 
										IHocKysRepository hockyRepository,
										IMonHocRepository monhocRepository)
		{
			_giangVienHuongDanRepository = giangVienHuongDanRepository;
			_hockyRepository = hockyRepository;
			_monhocRepository = monhocRepository;
		}


		public async Task<List<GiangVienHuongDanViewModel>> SelectAllAsync()
		{
			return await _giangVienHuongDanRepository.SelectAllAsync();
		}

		public async Task<SearchResult<GiangVienHuongDanViewModel>> GetByIdHocKyAsync(string idhocky)
		{
			var checkExit = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
			if (checkExit == false)
				return new SearchResult<GiangVienHuongDanViewModel>() { Code = -1, Data = null, Message = "Học kỳ không tồn tại." };
			return await _giangVienHuongDanRepository.SelectByIdHocKyAsync(idhocky);
		}

		public async Task<ActionResultResponese<string>> InsertAsync(GiangVienHDMeta gvhdkyMeta, string idhocky,string idmonhoc,TypeGVHD tygvhd)
        {
			var id = Guid.NewGuid().ToString();
			var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
			if (!checkHocKy)
				return new ActionResultResponese<string>(-3, "Không tồn tại.", "Học Kỳ");
			var checkmonhoc = await _monhocRepository.CheckExitsIsActvive(idmonhoc);
			if (!checkmonhoc)
				return new ActionResultResponese<string>(-6, "Không tồn tại.", "Môn Học");
			var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(id);
			if (checkGVHDTheoKy)
				return new ActionResultResponese<string>(-4, "Bản ghi đã tồn tại.", "Giang viên hướng dẫn theo kỳ.");
			var checkExitsGVHDinHocKy = await _giangVienHuongDanRepository.CheckExitsActive(idhocky, gvhdkyMeta.IdGVHD,idmonhoc);
			if (checkExitsGVHDinHocKy)
				return new ActionResultResponese<string>(-5, "Giang viên đã có trong kỳ.", "Giang vien hướng dẫn theo kỳ.");
			var gvhdky = new GVHDTheoKy()
			{
				IdGVHDTheoKy = id.Trim(),
				IdGVHD = gvhdkyMeta.IdGVHD?.Trim(),
				MaGVHD = gvhdkyMeta.MaGVHD?.Trim(),
				TenGVHD = gvhdkyMeta.TenGVHD?.Trim(),
				IdHocKy = idhocky?.Trim(),
				IdMonHoc = idmonhoc?.Trim(),
				DonViCongTac = gvhdkyMeta.DonViCongTac?.Trim(),
				Email = gvhdkyMeta.Email?.Trim(),
				DienThoai = gvhdkyMeta.DienThoai?.Trim(),
				Type = tygvhd,
				NgayTao = DateTime.Now
			};
			if (gvhdky == null)
				return new ActionResultResponese<string>(-8, "Dữ liệu trống.", "Giang viên hướng dẫn theo kỳ.");
			var result = await _giangVienHuongDanRepository.InsertAsync(gvhdky);
			if (result <= 0)
				return new ActionResultResponese<string>(result, "Thêm mới thất bại.", "Giang viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Giang viên hướng dẫn theo kỳ.");
		}

		public async Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta, string idGVHD, string idGvhdTheoKy, TypeGVHD tygvhd)
        {
			var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(idGvhdTheoKy);
			if (!checkGVHDTheoKy)
				return new ActionResultResponese<string>(-6, "Bản ghi không tồn tại.", "Giang viên hướng dẫn theo kỳ.");
			var checkExitsGVHD = await _giangVienHuongDanRepository.CheckExitsGVHD(idGVHD);
			if (!checkExitsGVHD)
				return new ActionResultResponese<string>(-10, "Giang viên không tồn tại.", "Giang vien hướng dẫn theo kỳ.");
			var gvhdky = new GVHDTheoKy()
			{
				IdGVHDTheoKy = idGvhdTheoKy?.Trim(),
				IdGVHD = idGVHD?.Trim(),
				DonViCongTac = gvhdkyUpdateMeta.DonViCongTac?.Trim(),
				Email = gvhdkyUpdateMeta.Email?.Trim(),
				DienThoai = gvhdkyUpdateMeta.DienThoai?.Trim(),
				Type = tygvhd,
			};
			if (gvhdky == null)
				return new ActionResultResponese<string>(-12, "Dữ liệu trống.", "Giang viên hướng dẫn theo kỳ.");
			var result = await _giangVienHuongDanRepository.UpdatetAsync(gvhdky);
			if (result <= 0)
				return new ActionResultResponese<string>(result, "Sửa thất bại.", "Giang viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Sửa thành công.", "Giang viên hướng dẫn theo kỳ.");
		}

		public async Task<ActionResultResponese<string>> DeleteAsync(string idGHVHDTheoKy)
        {
			var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(idGHVHDTheoKy);
			if (!checkGVHDTheoKy)
				return new ActionResultResponese<string>(-13, "Bản ghi không tồn tại.", "Giang viên hướng dẫn theo kỳ.");
			var result = await _giangVienHuongDanRepository.DeleteByIdAsync(idGHVHDTheoKy);
			if (result <= 0)
				return new ActionResultResponese<string>(result, "Xóa thất bại.", "Giang viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Xóa thành công.", "Giang viên hướng dẫn theo kỳ.");
		}
	}
}
