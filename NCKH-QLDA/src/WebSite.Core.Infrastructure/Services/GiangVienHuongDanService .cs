using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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


		public async Task<SearchResult<GiangVienHuongDanViewModel>> SelectAllAsync(string idbomon)
		{
			return await _giangVienHuongDanRepository.SelectAllAsync(idbomon);
		}

		public async Task<SearchResult<GiangVienHuongDanViewModel>> GetByIdHocKyAsync(string idhocky ,string idbomon)
		{
			var checkExit = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
			if (checkExit == false)
				return new SearchResult<GiangVienHuongDanViewModel>() { Code = -1, Data = null, Message = "Học kỳ không tồn tại." };
			return await _giangVienHuongDanRepository.SelectByIdHocKyAsync(idhocky,idbomon);
		}

		public async Task<ActionResultResponese<string>> InsertAsync(GiangVienHDMeta gvhdkyMeta, string idhocky, TypeGVHD tygvhd, string CreatorUserId, string creatorFullName,string idbomon)
        {
			var id = Guid.NewGuid().ToString();
			var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
			if (!checkHocKy)
				return new ActionResultResponese<string>(-3, "Không tồn tại.", "Học Kỳ");
			var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(id);
			if (checkGVHDTheoKy)
				return new ActionResultResponese<string>(-4, "Bản ghi đã tồn tại.", "Giang viên hướng dẫn theo kỳ.");
			var checkExitsGVHDinHocKy = await _giangVienHuongDanRepository.CheckExitsGVHD(gvhdkyMeta.MaGVHD);
			if (checkExitsGVHDinHocKy)
				return new ActionResultResponese<string>(-5, "Giảng viên đã có trong kỳ.", "Giảng viên hướng dẫn theo kỳ.");
			var gvhdky = new GVHDTheoKy()
			{
				IdGVHDTheoKy = id.Trim(),
				IdBoMon = idbomon?.Trim(),
				IdGVHD = Guid.NewGuid().ToString(),
				MaGVHD = gvhdkyMeta.MaGVHD?.Trim(),
				TenGVHD = gvhdkyMeta.TenGVHD?.Trim(),
				IdHocKy = idhocky?.Trim(),
				DonViCongTac = gvhdkyMeta.DonViCongTac?.Trim(),
				Email = gvhdkyMeta.Email?.Trim(),
				DienThoai = gvhdkyMeta.DienThoai?.Trim(),
				Type = tygvhd,
				CreateTime = DateTime.Now,
				CreatorUserId = CreatorUserId?.Trim(),
				CreatorFullName = creatorFullName?.Trim()
			};
			if (gvhdky == null)
				return new ActionResultResponese<string>(-8, "Dữ liệu trống.", "Giang viên hướng dẫn theo kỳ.");
			var result = await _giangVienHuongDanRepository.InsertAsync(gvhdky);
			if (result <= 0)

				return new ActionResultResponese<string>(result, "Thêm mới thất bại.", "Giang viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Giang viên hướng dẫn theo kỳ.");
		}
		public async Task<ActionResultResponese<string>> InsertListGVHDAsync(List<GiangVienListMeta> gvhdlistMeta, string idhocky, string CreatorUserId, string CreatorFullName, string idbomon)
        {
		
			var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
			if (!checkHocKy)
				return new ActionResultResponese<string>(-3, "Không tồn tại.", "Học Kỳ");
			//var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(id);
			//if (checkGVHDTheoKy)
			//	return new ActionResultResponese<string>(-4, "Bản ghi đã tồn tại.", "Giang viên hướng dẫn theo kỳ.");

			List<GiangVienListMeta> listmagiangvien = gvhdlistMeta.GroupBy(p => p.MaGVHD).Select(g => g.First()).ToList();
			if (listmagiangvien.Count() != gvhdlistMeta.Count())
				return new ActionResultResponese<string>(-23, "Trùng lặp", "Giảng viên.");

			foreach (var giangvien in gvhdlistMeta)
            {
				var checkExitsGVHDinHocKy = await _giangVienHuongDanRepository.CheckExitsActive(idhocky, giangvien.MaGVHD);
				if (checkExitsGVHDinHocKy)
					return new ActionResultResponese<string>(-15, "Giang viên đã có trong kỳ. ", "Giảng viên hướng dẫn theo kỳ.");
			}
			var listGVHD = new List<GVHDTheoKy>();
			foreach (var giangvien in gvhdlistMeta)
			{
				var checkExitsGVHDinHocKy = await _giangVienHuongDanRepository.CheckExitsActive(idhocky, giangvien.IdGVHD);
				if (checkExitsGVHDinHocKy)
					return new ActionResultResponese<string>(-16, "Giảng viên đã có trong kỳ.", "Giang vien hướng dẫn theo kỳ.");

				var id = Guid.NewGuid().ToString();
				listGVHD.Add(new GVHDTheoKy
				{
					IdGVHDTheoKy = id?.Trim(),
					IdBoMon = idbomon?.Trim(),
					IdGVHD = giangvien.IdGVHD?.Trim(),
					MaGVHD = giangvien.MaGVHD?.Trim(),
					TenGVHD = giangvien.TenGVHD?.Trim(),
					IdHocKy = idhocky?.Trim(),
					DonViCongTac = giangvien.DonViCongTac?.Trim(),
					Email = giangvien.Email?.Trim(),
					DienThoai= giangvien.DienThoai?.Trim(),
					Type = giangvien.Type,
					CreateTime = DateTime.Now,
					CreatorUserId = CreatorUserId?.Trim(),
					CreatorFullName = CreatorFullName?.Trim(),
					IsActive = true,
					IsDelete = false
				});
			}
			if (listGVHD.Count == 0)
				return new ActionResultResponese<string>(-15, "Vui Chọn giảng viên.", "Giảng viên.");
			foreach (var gianvienInsert in listGVHD)
			{
				await _giangVienHuongDanRepository.InsertAsync(gianvienInsert);
			}

			//  return new ActionResultResponese<string>(result, "Thêm mới chi tiết đề tài không thành công", "Chi tiết đề tài.");
			return new ActionResultResponese<string>(1, "Thêm mới danh sách giảng viên thành công.", "Giảng viên.");

		}
		public async Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta, string idGvhdTheoKy, TypeGVHD tygvhd,string CreatorUserId,string creatorFullName, string idbomon)
        {
			//var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(idGvhdTheoKy);
			//if (!checkGVHDTheoKy)
			//	return new ActionResultResponese<string>(-6, "Bản ghi không tồn tại.", "Giang viên hướng dẫn theo kỳ.");

			var infoGiangVien = await _giangVienHuongDanRepository.GetInfo(idGvhdTheoKy);
			if (infoGiangVien == null)
				return new ActionResultResponese<string>(-6, "Giảng viên không tồn tại", "Giảng viên hướng dẫn");
			
			if (infoGiangVien.IdBoMon != idbomon?.Trim())
				return new ActionResultResponese<string>(-6, "Bạn không có quyền sửa giảng viên này", "Giảng viên hướng dẫn");

			//var checkExitsGVHD = await _giangVienHuongDanRepository.CheckExitsGVHD(idGVHD);
			//if (!checkExitsGVHD)
			//	return new ActionResultResponese<string>(-10, "Giảng viên không tồn tại.", "Giang vien hướng dẫn theo kỳ.");

			infoGiangVien.IdGVHDTheoKy = idGvhdTheoKy?.Trim();
			infoGiangVien.DonViCongTac = gvhdkyUpdateMeta.DonViCongTac?.Trim();
			infoGiangVien.TenGVHD = gvhdkyUpdateMeta.TenGVHD?.Trim();
			infoGiangVien.Email = gvhdkyUpdateMeta.Email?.Trim();
			infoGiangVien.DienThoai = gvhdkyUpdateMeta.DienThoai?.Trim();
			infoGiangVien.lastUpdateUserId = CreatorUserId?.Trim();
			infoGiangVien.LastUpdateFullName = creatorFullName?.Trim();
			infoGiangVien.LastUpdate = DateTime.Now;
			infoGiangVien.Type = tygvhd;
			
			//if (infoGiangVien == null)
			//	return new ActionResultResponese<string>(-12, "Dữ liệu trống.", "Giảng viên hướng dẫn theo kỳ.");
			var result = await _giangVienHuongDanRepository.UpdatetAsync(infoGiangVien);
			if (result <= 0)
				return new ActionResultResponese<string>(result, "Sửa thất bại.", "Giảng viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Sửa thành công.", "Giảng viên hướng dẫn theo kỳ.");
		}

		public async Task<ActionResultResponese<string>> DeleteAsync(string idgvhdTheoky, string deleteUserId, string deleteFullName)
        {

			var checkGVHDTheoKy = await _giangVienHuongDanRepository.CheckExits(idgvhdTheoky);
			if (!checkGVHDTheoKy)
				return new ActionResultResponese<string>(-13, "Bản ghi không tồn tại.", "Giang viên hướng dẫn theo kỳ.");
			var ngayxoa = DateTime.Now;
			var result = await _giangVienHuongDanRepository.DeleteByIdAsync(idgvhdTheoky,deleteUserId,deleteFullName,ngayxoa);
			if (result <= 0)
				return new ActionResultResponese<string>(result, "Xóa thất bại.", "Giang viên hướng dẫn theo kỳ.");
			return new ActionResultResponese<string>(result, "Xóa thành công.", "Giang viên hướng dẫn theo kỳ.");
		}

		
	}
}
