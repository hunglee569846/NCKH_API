using GHM.NailSpa.Domain.ViewModels;
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
    public class ChuyenNganhService : IChuyenNganhService
    {
        private readonly IChuyenNganhRepository _ichuyenNganhRepository;
        public ChuyenNganhService(IChuyenNganhRepository chuyenNganhRepository)
        {
            _ichuyenNganhRepository = chuyenNganhRepository;
        }
        public async Task<ActionResultResponese<ChuyenNganhSearchViewModel>> ChiTietChuyenNganh(string Id) 
        {
            var info = await _ichuyenNganhRepository.ChiTietChuyenNganh(Id);
            if (info == null)
                return new ActionResultResponese<ChuyenNganhSearchViewModel>(-1, "Chuyên ngành không tồn tại.","Chuyên Ngành");

            var chuyenNganhDtail = new ChuyenNganhSearchViewModel
            {
                Id = info.Id,
                MaChuyenNganh = info.MaChuyenNganh,
                TenChuyenNganh = info.TenChuyenNganh,
                VanPhong = info.VanPhong,
                HopThu = info.HopThu,
                DienThoai = info.DienThoai,
                DiaChi = info.DiaChi,
                GhiChu = info.GhiChu,
                NgayTao = info.NgayTao,
                IsActive = info.IsActive,
            };
            return new ActionResultResponese<ChuyenNganhSearchViewModel>
            {
                Code = 1,
                Data = chuyenNganhDtail
            };

        }
        public async Task<List<ChuyenNganhViewModel>> SelectAllAsync() 
        {
            return await _ichuyenNganhRepository.SelectAllAsync();
        }

    }
}
