﻿
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Services
{
    public class HockyService : IHocvKysService
    {
        private readonly IHocKysRepository _ihocKyRepository;
        public HockyService(IHocKysRepository ihocKyRepository)
        {
            _ihocKyRepository= ihocKyRepository;
        }

        public async Task<SearchResult<HocKySearchViewModel>> GetAll(string IdBoMon) 
        {
            return await _ihocKyRepository.SelectAll(IdBoMon);
        }
        public async Task<ActionResultResponese<string>> InsertAsync(string mahocky, string tenhocky,string namHoc, string userId, string fullName,string idBoMon)
        {
            var idhocky = Guid.NewGuid().ToString();
            var checExist = await _ihocKyRepository.CheckExistAsync(idhocky, mahocky);
            if (checExist)
                return new ActionResultResponese<string>(-2, "Mã học kỳ đã tồn tại", "Học Kỳ");

            var checExistMaHocKy = await _ihocKyRepository.CheckExisMaHocKy(mahocky);
            if (checExistMaHocKy)
                return new ActionResultResponese<string>(-2, "Mã học kỳ đã tồn tại", "Học Kỳ");

            var hockynew = new HocKy()
            {
                IdHocKy = idhocky?.Trim(),
                IdBoMon = idBoMon?.Trim(),
                MaHocKy = mahocky?.Trim(),
                NamHoc = namHoc?.Trim(),
                TenHocKy = tenhocky,
                CreateTime = DateTime.Now,
                CreatetorId = userId,
                CreatorFullName = fullName
            };
            if (hockynew == null)
                return new ActionResultResponese<string>(-3, "Dữ liệu rỗng", "Học Kỳ");
            var result = await _ihocKyRepository.InsertAsync(hockynew);
            if (result <= 0)
                return new ActionResultResponese<string>(result,"Thêm mới thất bại.","Học kỳ");
            return new ActionResultResponese<string>(result,"Thêm mới thành công.","Học kỳ");

        }
        
        public async Task<ActionResultResponese<string>> UpDateAsync(string idhocky, string mahocky, string tenhocky,string namHoc, string userId, string fullName,string idbomon)
        {
            var checkLockDataHK = await _ihocKyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkLockDataHK)
                return new ActionResultResponese<string>(-99, "Dữ liệu đã khóa.", "Học kỳ");
            var checkMaHK = await _ihocKyRepository.CheckExisMaHocKy(mahocky);
            if (checkMaHK)
                return new ActionResultResponese<string>(-98, "Mã học kỳ đã tồn tại.", "Học kỳ");
            var info = await _ihocKyRepository.SearchInfo(idhocky);
            if (info.IdBoMon != idbomon)
                return new ActionResultResponese<string>(-95, "Đã có lỗi vui lòng liên hệ quản trị viên.", "Học kỳ");
            info.IdHocKy = idhocky?.Trim();
            info.MaHocKy = mahocky?.Trim();
            info.TenHocKy = tenhocky?.Trim();
            info.NamHoc = namHoc?.Trim();
            info.LastUpdate = DateTime.Now; ;
            info.LastUpdateUserId = userId?.Trim();
            info.LastUpdateFullName = fullName?.Trim();
            var result = await _ihocKyRepository.UpdateAsync(info);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại.", "Học kỳ");
            return new ActionResultResponese<string>(result, "Sửa thành công.", "Học kỳ");

        }
        public async Task<ActionResultResponese<string>> DeleteAsync(string idhocky)
        {
            var checkLockDataHK = await _ihocKyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkLockDataHK)
                return new ActionResultResponese<string>(-99, "Dữ liệu đã khóa.", "Học kỳ");
            var checkExit = await _ihocKyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkExit)
                return new ActionResultResponese<string>(-4, "Thông tin không tồn tại", "Học kỳ");
            var result = await _ihocKyRepository.DeleteAsync(idhocky);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Xóa không thành công", "Học kỳ");
            return new ActionResultResponese<string>(result, "Xóa thành công", "Học kỳ");

        } 

    }
}
