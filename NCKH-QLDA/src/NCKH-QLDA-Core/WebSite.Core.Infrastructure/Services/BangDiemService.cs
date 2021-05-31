using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Infrastructure.Services
{
    public class BangDiemService : IBangDiemService
    {
        private readonly IBangDiemRepository _bangdiemRepository;
        private readonly IHocKysRepository _hockyRepository;
        private readonly IGiangVienHuongDanRepository _GiangVienHuongDanRepository;
        private readonly IMonHocRepository _monhocRepository;
        private readonly IDeTaiRepository _detaiRepository;
        private readonly IHoiDongTotNghiepRepository _hoidongtotnghiepRepository;
        public BangDiemService(IBangDiemRepository bangdiemRepository,
                               IHocKysRepository hockyRepository,
                               IGiangVienHuongDanRepository GiangVienHuongDanRepository,
                               IMonHocRepository monhocRepository,
                               IDeTaiRepository detaiRepository,
                               IHoiDongTotNghiepRepository hoidongtotnghiepRepository)
        {
            _bangdiemRepository = bangdiemRepository;
            _hockyRepository = hockyRepository;
            _GiangVienHuongDanRepository = GiangVienHuongDanRepository;
            _monhocRepository = monhocRepository;
            _detaiRepository = detaiRepository;
            _hoidongtotnghiepRepository = hoidongtotnghiepRepository;
        }

       public async  Task<ActionResultResponese<string>> InsertAsync (BangDiemMeta bangdiemMeta, string creatorUserId, string creatorFullName)
        {
            var getInfoHocKy = await _hockyRepository.SearchInfo(bangdiemMeta.IdHocKy);
            if (getInfoHocKy == null)
                return new ActionResultResponese<string>(-3, "Học kỳ không tồn tại", "Học kỳ");

            var getInfoMonHoc = await _monhocRepository.SearchInfo(bangdiemMeta.IdMonHoc);
            if (getInfoMonHoc == null)
                return new ActionResultResponese<string>(-4, "Môn học không tồn tại", "Môn học");

            var getInfoDeTai = await _detaiRepository.GetInfo(bangdiemMeta.IdDeTai);
            if (getInfoDeTai == null)
                return new ActionResultResponese<string>(-5, "Đề tài không tồn tại", "Đề tài");
            
            var getInfokHoiDong = await _hoidongtotnghiepRepository.GetInfo(bangdiemMeta.IdHoiDong);
            if (getInfokHoiDong == null)
                return new ActionResultResponese<string>(-6, "Hội đồng không tồn tại", "Hội đồng");

            var getInfoGiangVien = await _GiangVienHuongDanRepository.GetInfo(bangdiemMeta.IdGiangVien);
            if (getInfoGiangVien == null)
                return new ActionResultResponese<string>(-7, "Giảng viên không tồn tại", "Giảng viên");
            var id = Guid.NewGuid().ToString();

            var bangdiem = new BangDiem()
            {
                IdBangDien = id?.Trim(),
                IdDeTai = getInfoDeTai.IdDeTai?.Trim(),
                TenDeTai = getInfoDeTai.TenDeTai?.Trim(),
                MaDeTai = getInfoDeTai.MaDeTai?.Trim(),
                IdHocKy = getInfoHocKy.IdHocKy?.Trim(),
                TenHocKy = getInfoHocKy.TenHocKy?.Trim(),
                IdMonHoc = getInfoMonHoc.IdMonHoc?.Trim(),
                TenMonHoc = getInfoMonHoc.TenMonHoc?.Trim(),
                IdHoiDong = getInfokHoiDong.IdHoiDong?.Trim(),
                TenHoiDong = getInfokHoiDong.TenHoiDong?.Trim(),
                MaHoiDong = getInfokHoiDong.MaHoiDong?.Trim(),
                IdGiangVien = getInfoGiangVien.IdGVHD?.Trim(),
                IdSinhVien = getInfoDeTai.IdSinhVien?.Trim(),
                MaGiangVien = getInfoGiangVien.MaGVHD?.Trim(),
                TenGiangVien =getInfoGiangVien.TenGVHD?.Trim(),
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                NgayTao = DateTime.Now
            };
            if (bangdiem == null)
                return new ActionResultResponese<string>(-6, "Thông tin nhập không hợp lệ.", "Bảng điểm");
            var result = await _bangdiemRepository.InsertAsync(bangdiem);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới bảng điểm không thành công", "Bảng điểm");
            return new ActionResultResponese<string>(result, "Thêm mới bảng điểm thành công.", "Bảng điểm");

        }
    }
}
