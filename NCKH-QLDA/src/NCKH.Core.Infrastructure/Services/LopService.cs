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
    public class LopService : ILopService
    {
        private readonly ILopRepository _ilopRepository;
        public LopService(ILopRepository ilopRepository)
        {
            _ilopRepository = ilopRepository;
        }
        public async Task<ActionResultResponese<LopSearchViewModel>> GetByIdLop(string id)
        {
            var info = await _ilopRepository.GetByIdLop(id);
            if (info == null)
                return new ActionResultResponese<LopSearchViewModel>(-1, "Lớp không tồn tại.", "Lớp học");

            var lopDtail = new LopSearchViewModel
            {
                MaLop = info.MaLop,
                TenLop = info.TenLop,
                IdChuyenNganh = info.IdChuyenNganh,
                IdChuongTrinhDaoTao = info.IdChuongTrinhDaoTao,
                MaChuongTrinhDaoTao = info.MaChuongTrinhDaoTao,
                NienKhoa = info.NienKhoa,
                MaChuyenNganh = info.MaChuyenNganh,
                NgayTao = info.NgayTao,
            };
            return new ActionResultResponese<LopSearchViewModel>
            {
                Code = 1,
                Data = lopDtail
            };

        }
        public async Task<List<LopSearchViewModel>> SelectAllAsync()
        {
            return await _ilopRepository.SelectAllAsync();
        }

    }
}
