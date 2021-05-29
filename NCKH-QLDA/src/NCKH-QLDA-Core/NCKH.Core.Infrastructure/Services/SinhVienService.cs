using GHM.NailSpa.Domain.ViewModels;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly ISinhVienRepository _sinhVienRepository;
       
        public SinhVienService(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;

        }


        //public async Task<ActionResultResponese<ThongTinSinhVienViewModel>> GetDetailAsync(string id)
        //{
        //    return await _sinhVienRepository.GetInfoAsync(id);
        //}


        public async Task<List<SinhVienSearchViewModel>> SelectAllAsync()
        {
            return await _sinhVienRepository.SelectAllAsync();
        }
        public async Task<ActionResultResponese<ThongTinSinhVienViewModel>> GetDetailAsync(string id)
        {
            
            var info = await _sinhVienRepository.GetInfoAsync(id);
            if (info == null)
                return new ActionResultResponese<ThongTinSinhVienViewModel>(-1, "Không tồn tại.", "SinhVien");

            var sinhVienDetail = new ThongTinSinhVienViewModel
            {
                Id = info.Id,
                MaSinhVien = info.MaSinhVien,
                HoDem = info.HoDem,
                Ten = info.Ten,
                HoTen = info.HoTen,
                HomThu = info.HomThu,
                IdLop = info.IdLop,
                MaLop = info.MaLop,
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
            return new ActionResultResponese<ThongTinSinhVienViewModel>
            {
                Code = 1,
                Data = sinhVienDetail
            };
        }

       public async Task<ActionResultResponese<ThongTinSinhVienViewModel>> GetInfoByMaSinhVienAsync(string maSinhVien)
        {
            
            var info = await _sinhVienRepository.GetInfoByMaSinhVienAsync(maSinhVien);
            if (info == null)
                return new ActionResultResponese<ThongTinSinhVienViewModel>(-1, "Không tồn tại.", "SinhVien");

            var sinhVienDetail = new ThongTinSinhVienViewModel
            {
                Id = info.Id,
                MaSinhVien = info.MaSinhVien,
                HoDem = info.HoDem,
                Ten = info.Ten,
                HoTen = info.HoTen,
                HomThu = info.HomThu,
                IdLop = info.IdLop,
                MaLop = info.MaLop,
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
            return new ActionResultResponese<ThongTinSinhVienViewModel>
            {
                Code = 1,
                Data = sinhVienDetail
            };
        }

        public async Task<SearchResult<SinhVienChuyenNganhViewModel>> SearchSinhVienByIdChuyenNganhAsync(string idChuyenNganh)
        {
            return await _sinhVienRepository.SearchSinhVienByIdChuyenNganhAsync(idChuyenNganh);
        }
    }

}

