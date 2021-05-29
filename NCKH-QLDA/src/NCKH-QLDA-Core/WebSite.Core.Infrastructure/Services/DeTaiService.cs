using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class DeTaiService : IDeTaiService
    {
        private readonly IDeTaiRepository _deTaiRepository;
        private readonly IMonHocRepository _monhocRepository;
        private readonly IHocKysRepository _hockyRepository;
        private readonly IChiTietDeTaiRepository _chiTietDeTaiRepository;
        public DeTaiService(IDeTaiRepository deTaiRepository,
                            IMonHocRepository monhocRepository,
                            IHocKysRepository hockyRepository,
                            IChiTietDeTaiRepository chiTietDeTaiRepository) 
        {
            _deTaiRepository = deTaiRepository;
            _monhocRepository = monhocRepository;
            _hockyRepository = hockyRepository;
            _chiTietDeTaiRepository = chiTietDeTaiRepository;
        }

        public async Task<SearchResult<DeTaiSearchViewModel>> GetByIdHocKyAsync(string idhocky)
        {
            var checkIdKy = await _deTaiRepository.CheckExitsKyHoc(idhocky);
            if (!checkIdKy)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -1,
                    Message = "Học kỳ không tồn tại.",
                    Data = null
                };
            return await _deTaiRepository.SelectByIdHocKy(idhocky);
        }
        public async Task<SearchResult<DeTaiSearchViewModel>> GetByIdMonHocInHocKyAsync(string idhocky,string idmonhoc)
        {
            var checkIdKy = await _deTaiRepository.CheckExitsKyHoc(idhocky);
            if (!checkIdKy)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -3,
                    Message = "Kỳ học không tồn tại.",
                    Data = null
                };
            var CheckeExist = await _deTaiRepository.CheckExitsActive(idhocky, idmonhoc);
            if (!CheckeExist)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -2,
                    Message = "Môn học không có trong kỳ này.",
                    Data = null
                };
            return await _deTaiRepository.SelectByIdHocKy(idhocky);
        }
        public async Task<ActionResultResponese<string>> InsertAsync(DeTaiInsertMeta detaiInsertMeta, string madetai, string idhocky, string idmonhoc, string idsinhvien, string tensinhvien,string masinhvien, string maNguoiTao,string tenNguoiTao)
        {
            var id = Guid.NewGuid().ToString();
            var checExitHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitHocKy)
                return new ActionResultResponese<string>(-4, "Học kỳ không tồn tại.", "Học kỳ.");
            var hockyInfo = await _hockyRepository.SearchInfo(idhocky);
            var checExistMonHoc = await _monhocRepository.CheckExitsIsActvive(idmonhoc);
            if (!checExistMonHoc)
                return new ActionResultResponese<string>(-5, "Môn học không tồn tại.", "Môn học.");
            var monhocInfo = await _monhocRepository.SearchInfo(idhocky);

            var checkIsDat = await _deTaiRepository.CheckIsDat(idmonhoc, idsinhvien);
            if (!checkIsDat)
                return new ActionResultResponese<string>(-21, "Sinh viên chưa hoàn thành môn "+ monhocInfo.TenMonHoc + " là môn tiên quyết.", "Môn học.");

            var checkExits = await _deTaiRepository.CheckExits(id);
            if (checkExits)
                return new ActionResultResponese<string>(-6, "IdDeTai đã tồn tại.", "Đề tài.");
            var checkExitsMaDeTai = await _deTaiRepository.CheckExits(madetai);
            if (checkExitsMaDeTai)
                return new ActionResultResponese<string>(-7, "Mã đề tài đã tồn tại.", "Đề tài.");
            var detai = new DeTai()
            {
                IdDeTai = id?.Trim(),
                MaDeTai = madetai?.Trim(),
                TenDeTai = detaiInsertMeta.TenDeTai?.Trim(),
                IdSinhVien = idsinhvien?.Trim(),
                TenSinhVien = tensinhvien?.Trim(),
                IdHocKy = idhocky?.Trim(),
                TenHocKy = hockyInfo.TenHocKy?.Trim(),
                IdMonHoc = idmonhoc?.Trim(),
                TenMonHoc = monhocInfo.TenMonHoc?.Trim(),
                DonViThucTap = detaiInsertMeta.DonViThucTap?.Trim(),
                Email = detaiInsertMeta.Email?.Trim(),
                DiemTrungBinh = 0,
                IsDat = false,
                NgayTao = DateTime.Now,
                MaNguoiTao = maNguoiTao?.Trim(),
                TenNguoiTao = tenNguoiTao?.Trim(),
                MaSinhVien = masinhvien?.Trim()
            };
            if (detai == null)
                return new ActionResultResponese<string>(-8, "Dữ liệu trống", "Đề tài.");
            var result = await _deTaiRepository.InsertAsync(detai);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm  mới thất bại.", "Đề tài.");
            return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Đề tài.");

        }
        public async Task<ActionResultResponese<string>> UpdateAsync(DeTaiUpdateMeta detaiUpdateMeta, string iddetai,string maNguoiSua,string tenNguoisua)
        {
            
            var checkExits = await _deTaiRepository.CheckExits(iddetai);
            if (!checkExits)
                return new ActionResultResponese<string>(-12, "Đề tài không tồn tại.", "Đề tài.");
          
            var detai = new DeTai()
            {
                IdDeTai = iddetai?.Trim(),
                TenDeTai = detaiUpdateMeta.TenDeTai?.Trim(),
                NgaySua = DateTime.Now,
                MaNguoiSua = maNguoiSua?.Trim(),
                TenNguoisua = tenNguoisua?.Trim()
            };
            if (detai == null)
                return new ActionResultResponese<string>(-13, "Dữ liệu trống", "Đề tài.");
            var result = await _deTaiRepository.UpdateAsync(detai);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại.", "Đề tài.");
            return new ActionResultResponese<string>(result, "Sửa thành công.", "Đề tài.");
        }
        public async Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky,bool isApprove)
        {

            var checkExits = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkExits)
                return new SearchResult<DeTaivsCTDTViewModel> { Code = -2, Data=null };
            return await _deTaiRepository.SelectByIdCTDTAsync(idhocky, isApprove);
            
        }

        public async Task<ActionResultResponese<string>> DeleteAsync(string iddetai)
        {
            //var checExitDeTai = await _chiTietDeTaiRepository.CheckExits(iddetai);
            //if (!checExitDeTai)
            //    return new ActionResultResponese<string>(-4, "Chi tiết đề tài không tồn tại.", "Chi tiết đề tài.");
            var checkDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checkDeTai)
                return new ActionResultResponese<string>(-8, "Đề tài không tồn tại.", "Môn học.");
            var result = await _deTaiRepository.DeleteAsync(iddetai);
            if (result <= 0)
                return new ActionResultResponese<string>(-9, "Xóa không thành công.", "Đề tài.");
            return new ActionResultResponese<string>(1, "Xóa thành công.", "Đề tài.");
        }

        public async Task<ActionResultResponese<string>> UpdateAproveAsync(string iddetai,bool isApprove)
        {
            var checkDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checkDeTai)
                return new ActionResultResponese<string>(-11, "Đề tài không tồn tại.", "Môn học.");
            var result = await _deTaiRepository.UpdateApproveAsync(iddetai, isApprove);
            if (result <= 0)
                return new ActionResultResponese<string>(-12, "Phê duyệt không thành công.", "Đề tài.");
            return new ActionResultResponese<string>(1, "Phê duyệt thành công.", "Đề tài.");
        }
    }
}
