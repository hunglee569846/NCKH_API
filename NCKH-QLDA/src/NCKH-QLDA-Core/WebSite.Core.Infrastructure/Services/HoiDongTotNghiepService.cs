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
    public class HoiDongTotNghiepService : IHoiDongTotNghiepService
    {
        private readonly IHoiDongTotNghiepRepository _hoiDongTotNghiepRepository;
        private readonly IHocKysRepository _hocKysRepository;
        private readonly IMonHocRepository _monhocRepository;
        private readonly IDeTaiRepository _detaiRepository;
        public HoiDongTotNghiepService(IHoiDongTotNghiepRepository hhoiDongTotNghiepRepository,
                                        IHocKysRepository hocKysRepository,
                                        IMonHocRepository monhocRepository,
                                        IDeTaiRepository detaiRepository)
        {
            _hoiDongTotNghiepRepository = hhoiDongTotNghiepRepository;
            _hocKysRepository = hocKysRepository;
            _monhocRepository = monhocRepository;
            _detaiRepository = detaiRepository;
        }

        public async Task<SearchResult<HoiDongTotNghiepViewModel>> GetByIdHocKy(string idhocky)
        {
            var checkExit = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (checkExit == false)
                return new SearchResult<HoiDongTotNghiepViewModel>() { Code = -1, Data = null, Message = "Học kỳ không tồn tại." };
            return await _hoiDongTotNghiepRepository.SelectAll(idhocky);
        }

       public async Task<ActionResultResponese<string>> InsertAsync(HoiDongTotNghiepMeta hoidongMeta, string idhocky, string idmonhoc)
        {
            string id = Guid.NewGuid().ToString();

            var checkhoidong = await _hoiDongTotNghiepRepository.CheckExit(id, idhocky);
            if (checkhoidong)
                return new ActionResultResponese<string>(-21, "Hội đồng đã tồn tại.", "Hội đồng.");

            var infoMonHoc = await _monhocRepository.SearchInfo(idmonhoc);
            if (infoMonHoc == null)
                return new ActionResultResponese<string>(-5, "Môn học không tồn tại.", "Môn học.");

            if (infoMonHoc.TypeApprover == 0)
                return new ActionResultResponese<string>(-9, "Môn học không được phép tạo."+" "+ infoMonHoc.TypeApprover.ToString(), "Môn học.");

            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-3, "Học kỳ không tồn tại.", "Học kỳ.");

            var infoHocKy = await _hocKysRepository.SearchInfo(idhocky);
            if (infoHocKy == null)
                return new ActionResultResponese<string>(-4, "Học kỳ không tồn tại.", "Học kỳ.");


            var hoidong = new HoiDongTotNghiep()
            {
                IdHoiDong = id?.Trim(),
                MaHoiDong = hoidongMeta.MaHoiDong?.Trim(),
                TenHoiDong = hoidongMeta.TenHoiDong?.Trim(),
                IdHocKy = idhocky?.Trim(),
                TenHocKy = infoHocKy.TenHocKy?.Trim(),
                IdMonHoc = idmonhoc?.Trim(),
                TenMonHoc = infoMonHoc.TenMonHoc?.Trim(),
                NgayTao = DateTime.Now,
                NgayBaoVe = hoidongMeta.NgayBaoVe,
                NgaySua = DateTime.Now
            };
            if (hoidong == null)
                return new ActionResultResponese<string>(-6, "Nhập sai dữ liệu","Hội đồng.");
            var result = await _hoiDongTotNghiepRepository.InsertAsync(hoidong);
            if(result <= 0)
                return new ActionResultResponese<string>(-7, "Thêm mới thất bại.", "Hội đồng.");
            return new ActionResultResponese<string>(1, "Thêm mới thành công", "Hội đồng.");

        }
        
       public async Task<ActionResultResponese<string>> UpdateAsync(HoiDongTotNghiepMeta hoidongMeta, string idhoidong,string idhockky)
        {
            var checkhoidong = await _hoiDongTotNghiepRepository.CheckExit(idhoidong, idhockky);
            if (!checkhoidong)
                return new ActionResultResponese<string>(-14, "Hội đồng không tồn tại.", "Hội đồng.");

            var hoidong = new HoiDongTotNghiep()
            {
                IdHoiDong = idhoidong?.Trim(),
                MaHoiDong = hoidongMeta.MaHoiDong?.Trim(),
                TenHoiDong = hoidongMeta.TenHoiDong?.Trim(),
                NgayBaoVe = hoidongMeta.NgayBaoVe,
                NgaySua = DateTime.Now
            };
            if (hoidong == null)
                return new ActionResultResponese<string>(-16, "Nhập sai dữ liệu", "Hội đồng.");
            var result = await _hoiDongTotNghiepRepository.UpdateAsync(hoidong);
            if (result <= 0)
                return new ActionResultResponese<string>(-17, "Sửa mới thất bại.", "Hội đồng.");
            return new ActionResultResponese<string>(1, "Sửa mới thành công", "Hội đồng.");
        }
    }
}
