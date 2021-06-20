using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Constansts;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Services
{
    public class MonHocService : IMonHocService
    {
        
        private readonly IMonHocRepository _imonhocRepository;
        private readonly IHocKysRepository _ihocKyscRepository;
        public MonHocService(IMonHocRepository imonhocRepository,
                             IHocKysRepository ihocKyscRepository)
        {
            _imonhocRepository = imonhocRepository;
            _ihocKyscRepository = ihocKyscRepository;
        }

        public async Task<SearchResult<MonHocSearchViewModel>> GetAllAsyncByIdHocKy(string idhocky)
        {
            var result = await _ihocKyscRepository.CheckExisIsActivetAsync(idhocky);
            if(result == false)
                return new SearchResult<MonHocSearchViewModel> { TotalRows = 0, Data = null,Code = -1 ,Message="Học kỳ không tồn tại."};
            return await _imonhocRepository.SelectAllByIdHocKy(idhocky);
        }
        //Khoi tao mon hoc tien quyet
        public async Task<ActionResultResponese<string>> InsertAsync(MonHocMeta monHocMeta, string idhocky,TypeDataApprover typeApprover, string creatorUserId, string creatorFullName,string mamonhoc,string tenmonhoc)
        {
            var checkLockDataHK = await _ihocKyscRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkLockDataHK)
                return new ActionResultResponese<string>(-99, "Dữ liệu đã khóa.", "Học kỳ");
            var checExits = await _ihocKyscRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExits)
                return new ActionResultResponese<string>(-5, "Học kỳ không tồn tại.", "Học kỳ");
            var idmonhoc = Guid.NewGuid().ToString();
            var checkExitsInMonHoc = await _imonhocRepository.CheckExits(idmonhoc, mamonhoc);
            if (checkExitsInMonHoc)
                return new ActionResultResponese<string>(-3, "Môn học đã tồn tại.", "Môn học");

            if (monHocMeta.IdMonTienQuyet != "0")
            {
                var checkExitsMonHoc = await _imonhocRepository.CheckMonHocInHocKyExits(monHocMeta.IdMonTienQuyet, mamonhoc);
                if (!checkExitsMonHoc)
                    return new ActionResultResponese<string>(-11, "Môn học không tồn tại.", "Môn tiên quyết.");
            }

            var checkExitsMaMonHoc = await _imonhocRepository.CheckExitsMaMonHoc(mamonhoc);
            if (checkExitsMaMonHoc)
                return new ActionResultResponese<string>(-9, "Mã đã tồn tại.", "Môn học");

            var getInfo = await _imonhocRepository.SearchInfo(monHocMeta.IdMonTienQuyet);
            string montienquyet = "0";
            var monhoc = new MonHoc()
            {
                IdMonHoc = idmonhoc,
                MaMonHoc = mamonhoc?.Trim(),
                IdHocKy = idhocky?.Trim(),
                TenMonHoc = tenmonhoc?.Trim(),
                NgayTao = DateTime.Now,
                TypeApprover = typeApprover,
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                IdMonTienQuyet = getInfo == null ? montienquyet.ToString(): getInfo.IdMonHoc?.Trim(),//getInfo.IdMonHoc?.Trim(),//
                NameMonTienQuyet = getInfo == null ? montienquyet.ToString(): getInfo.TenMonHoc?.Trim() //getInfo.TenMonHoc?.Trim() //
            };
            if (monhoc == null)
                return new ActionResultResponese<string>(-4, "Dữ liệu rỗng", "Môn học");
            var result = await _imonhocRepository.InsertAsync(monhoc);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới thất bại", "Môn học");
            return new ActionResultResponese<string>(result, "Thêm mới thành công", "Môn học");
            
        }

        public async Task<ActionResultResponese<string>> UpdateAsync(MonHocMeta monhocmeta, string idmonhoc,string idhocky, TypeDataApprover typeApprover, string lastUpdateUserId, string lastUpdateFullName, string mamonhoc, string tenmonhoc)
        {
            var checkLockDataHK = await _ihocKyscRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkLockDataHK)
                return new ActionResultResponese<string>(-99, "Dữ liệu đã khóa.", "Học kỳ");
            var checExits = await _imonhocRepository.CheckExitsIsActvive(idmonhoc);
            if (!checExits)
                return new ActionResultResponese<string>(-5, "Mã không tồn tại.", "Môn học");

            if (monhocmeta.IdMonTienQuyet != "0")
            {
                var checkExitsMonHoc = await _imonhocRepository.CheckMonHocInHocKyExits(monhocmeta.IdMonTienQuyet, mamonhoc);
                if (!checkExitsMonHoc)
                    return new ActionResultResponese<string>(-11, "Môn học không tồn tại.", "Môn tiên quyết.");
            }

            var getInfo = await _imonhocRepository.SearchInfo(monhocmeta.IdMonTienQuyet);
            string montienquyet = "0";
            var monhoc = new MonHoc()
            {
                IdMonHoc = idmonhoc,
                MaMonHoc = mamonhoc?.Trim(),
                IdHocKy = idhocky?.Trim(),
                TenMonHoc = tenmonhoc?.Trim(),
                IdMonTienQuyet = getInfo == null ? montienquyet.ToString() : getInfo.IdMonHoc?.Trim(),//getInfo.IdMonHoc?.Trim(),//
                NameMonTienQuyet = getInfo == null ? montienquyet.ToString() : getInfo.TenMonHoc?.Trim(), //getInfo.TenMonHoc?.Trim() //
                TypeApprover = typeApprover,
                LastUpdateUserId = lastUpdateUserId,
                LastUpdateFullName = lastUpdateFullName,
                NgaySua = DateTime.Now
            };
            if (monhoc == null)
                return new ActionResultResponese<string>(-6, "Dữ liệu rỗng", "Môn học");
            var result = await _imonhocRepository.UpdateAsync(monhoc);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại", "Môn học");
            return new ActionResultResponese<string>(result, "Sửa thành công", "Môn học");
        }

       public async Task<ActionResultResponese<string>> DeleteAsync(string idMonHoc, string idHocKy)
        {
            var checExits = await _imonhocRepository.CheckMonHocInHocKyExits(idMonHoc, idHocKy);
            if (!checExits)
                return new ActionResultResponese<string>(-8, "Môn học không có trong kỳ.", "Môn học");
            var result = await _imonhocRepository.DeleteAsync(idMonHoc, idHocKy);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Xóa thất bại", "Môn học");
            return new ActionResultResponese<string>(result, "Xóa thành công", "Môn học");
        }
    }
}
