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

       public async  Task<ActionResultResponese<string>> InsertAsync (string iddetai,string idGVHD,string idhoidong,string idhocky,string idmonhoc, string creatorUserId, string creatorFullName)
        {
            var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new ActionResultResponese<string>(-3, "Học kỳ không tồn tại", "Học kỳ");

            var checkMonHoc = await _monhocRepository.CheckMonHocInHocKyExits(idmonhoc,idhocky);
            if (!checkMonHoc)
                return new ActionResultResponese<string>(-4, "Môn học không tồn tại", "Môn học");

            var CheckDeTai = await _detaiRepository.CheckExits(iddetai);
            if (!CheckDeTai)
                return new ActionResultResponese<string>(-5, "Đề tài không tồn tại", "Đề tài");

            var detaiInfo = await _detaiRepository.GetInfo(iddetai,idhocky,idmonhoc);
            
            var checkHoiDong = await _hoidongtotnghiepRepository.CheckExitIsActive(idhoidong);
            if (!checkHoiDong)
                return new ActionResultResponese<string>(-6, "Hội đồng không tồn tại", "Hội đồng");

            var checkGiangVien = await _GiangVienHuongDanRepository.CheckExits(idGVHD);
            if (!checkGiangVien)
                return new ActionResultResponese<string>(-7, "Giảng viên không tồn tại", "Giảng viên");
            var id = Guid.NewGuid().ToString();

            var bangdiem = new BangDiem()
            {
                IdBangDien = id?.Trim(),
                IdDeTai = iddetai?.Trim(),
                IdHocKy = idhocky?.Trim(),
                IdMonHoc = idmonhoc?.Trim(),
                IdHoiDong = idhoidong?.Trim(),
                IdGiangVien = idGVHD?.Trim(),
                IdSinhVien = detaiInfo.IdSinhVien?.Trim(),
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                CreateTime = DateTime.Now
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
