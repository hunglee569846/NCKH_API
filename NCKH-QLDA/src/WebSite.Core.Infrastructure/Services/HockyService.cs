
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
        public async Task<ActionResultResponese<string>> InsertAsync(int hocky, string userId, string fullName,string idBoMon)
        {
            var idhocky = Guid.NewGuid().ToString();

            var nameHocKy = "Học kỳ " + hocky;
            var namHoc1 = DateTime.Now.Year.ToString() + " - " + (DateTime.Now.AddYears(1)).Year.ToString();
            var mahocky1 = "HK" + hocky.ToString() + DateTime.Now.Year.ToString() + (DateTime.Now.AddYears(1)).Year.ToString();
            var checExistMaHocKy = await _ihocKyRepository.CheckExisMaHocKy(mahocky1,idBoMon);
            if (checExistMaHocKy)
                return new ActionResultResponese<string>(-2, "Học kỳ đã tồn tại", "Học Kỳ");
            //var checExist = await _ihocKyRepository.CheckExistAsync(idhocky, mahocky1);
            //if (checExist)
            //    return new ActionResultResponese<string>(-2, "Mã học kỳ đã tồn tại", "Học Kỳ");
            var hockynew = new HocKy()
            {
                IdHocKy = idhocky?.Trim(),
                IdBoMon = idBoMon?.Trim(),
                MaHocKy = mahocky1?.Trim(),
                NamHoc = namHoc1?.Trim(),
                TenHocKy = nameHocKy?.Trim(),
                CreateTime = DateTime.Now,
                CreatetorId = userId?.Trim(),
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
            var checkMaHK = await _ihocKyRepository.CheckExisMaHocKy(mahocky,idbomon);
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

        public async Task<ActionResultResponese<string>> LockData(string idhocky, bool isLockData,string idbomon)
        {
            var infoHocKy = await _ihocKyRepository.SearchInfo(idhocky);

            if (infoHocKy == null)
                return new ActionResultResponese<string>(-51, "Học kỳ khồn tồn tại", "Học kỳ");
            if (infoHocKy.IdBoMon != idbomon?.Trim())
                return new ActionResultResponese<string>(-51, "Bạn không có quyền khóa dữ liệu bộ môn này", "Học kỳ");

            infoHocKy.IsLockData = isLockData;
            infoHocKy.IdBoMon = idbomon?.Trim();

            var result = await _ihocKyRepository.UpdateAsync(infoHocKy);
            if (result > 0 && isLockData == true)
                return new ActionResultResponese<string>(result, "Khóa dữ liệu thành công", "Học kỳ");
            if (result > 0 && isLockData == false)
                return new ActionResultResponese<string>(result, "Mở khóa dữ liệu thành công", "Học kỳ");

            return new ActionResultResponese<string>(result, "Khóa dữ liệu không thành công", "Học kỳ");
                    
        }
    }
}
