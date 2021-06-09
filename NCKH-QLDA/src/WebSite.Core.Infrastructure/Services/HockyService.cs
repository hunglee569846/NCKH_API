
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

        public async Task<SearchResult<HocKySearchViewModel>> GetAll() 
        {
            return await _ihocKyRepository.SelectAll();
        }
        public async Task<ActionResultResponese<string>> InsertAsync(string mahocky, string tenhocky, string userId, string fullName)
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
                IdHocKy = idhocky,
                MaHocKy = mahocky,
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
        
        public async Task<ActionResultResponese<string>> UpDateAsync(string idhocky, string mahocky, string tenhocky, string userId, string fullName)
        {
            var checkLockDataHK = await _ihocKyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkLockDataHK)
                return new ActionResultResponese<string>(-99, "Dữ liệu đã khóa.", "Học kỳ");
            var checExist = await _ihocKyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExist)
                return new ActionResultResponese<string>(-2, "Mã học kỳ không tồn tại", "Học Kỳ");
            //var hockynew = new HocKyMeta()
            //{
            //    MaHocKy = mahocky,
            //    TenHocKy = tenhocky
            //};
            //if (hockynew == null)
            //    return new ActionResultResponese<string>(-3, "Dữ liệu rỗng", "Học Kỳ");
            var ngaysua = DateTime.Now;
            var result = await _ihocKyRepository.UpdateAsync(idhocky, mahocky, tenhocky, ngaysua, userId, fullName);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa chữa thất bại.", "Học kỳ");
            return new ActionResultResponese<string>(result, "Sửa chữa thành công.", "Học kỳ");

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
