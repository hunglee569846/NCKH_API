using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Infrastructure.Services
{
    public class ChiTietHoiDongService : IChiTietHoiDongService
    {
        private readonly IHoiDongTotNghiepRepository _hoidongtotnghiepRepository;
        private readonly IChiTietHoiDongRepository _chitiethoidongRepository;
        private readonly IGiangVienHuongDanRepository _giangVienHuongDanRepository;
        public ChiTietHoiDongService(IHoiDongTotNghiepRepository hoidongRepository,
                                      IGiangVienHuongDanRepository giangVienHuongDanRepository,
                                      IChiTietHoiDongRepository chitiethoidongRepository)
        {
            _hoidongtotnghiepRepository = hoidongRepository;
            _giangVienHuongDanRepository = giangVienHuongDanRepository;
            _chitiethoidongRepository = chitiethoidongRepository;

        }
        public async Task<ActionResultResponese<string>> InserListDeTaiAsync(List<ChiTietHoiDongMeta> listChiTietHoiDongmeta, string idhoidong,string idhocky,string idmonhoc, string creartorUserId, string creartorFullName)
        {
            //thông tin hội đồng
            var getinfoHoiDong = await _hoidongtotnghiepRepository.GetInfo(idhoidong);
            if (getinfoHoiDong == null)
                return new ActionResultResponese<string>(-2, "Thông tin hội đồng không tồn tại.", "Hội đồng");

            List<ChiTietHoiDongMeta> listidgiangvien = listChiTietHoiDongmeta.GroupBy(p => p.IdGiangVien).Select(g => g.First()).ToList();
           // if(listidgiangvien.Count() != listChiTietHoiDongmeta.Count())
               // return new ActionResultResponese<string>(-3, "Trùng lặp giảng viên trong hội đồng.", "Giảng viên");
            var listChiTietHoiDong = new List<ChiTietHoiDong>();
            var listHoiDong = new List<ChiTietHoiDong>();
            foreach (var idgiangvien in listidgiangvien)
            {
                var getinfoGVHD = await _giangVienHuongDanRepository.GetInfo(idgiangvien.IdGiangVien,idhocky,idmonhoc);
                if (getinfoGVHD == null)
                    return new ActionResultResponese<string>(-4, "Giảng viên không tồn tại", "Giảng viên");

                var id = Guid.NewGuid().ToString();
                listChiTietHoiDong.Add(new ChiTietHoiDong
                {
                    IdChiTietHD = id,
                    IdHoiDong = getinfoHoiDong.IdHoiDong?.Trim(),
                    MaHoiDong = getinfoHoiDong.MaHoiDong?.Trim(),
                    TenHoiDong = getinfoHoiDong.TenHoiDong?.Trim(),
                    IdGiangVien = getinfoGVHD.IdGVHD?.Trim(),
                    TenGiangVien = getinfoGVHD.TenGVHD?.Trim(),
                    MaGiangVien = getinfoGVHD.MaGVHD?.Trim(),
                    NgayTao = DateTime.Now,
                    CreatorUserId = creartorUserId?.Trim(),
                    CreatorUserFullName = creartorFullName?.Trim(),
                    IsActive = true,
                    IsDelete = false
                });
            }

            if (listChiTietHoiDong.Count == 0)
            {
                return new ActionResultResponese<string>(-4,"Vui lòng chọn giảng viên","Giảng viên");
            }
            foreach (var chitietHD in listChiTietHoiDong)
            {
                await _chitiethoidongRepository.InserAsync(chitietHD);
            }

            return new ActionResultResponese<string>(1, "Thêm mới chi tiết hội đồng tốt nghiệp thành công", "Chi tiết hội đồng tốt nghiệp");

        }

        public async Task<ActionResultResponese<string>> InserAsync(string idhoidong, string idgvhd,string idhocky,string idmonhoc, string creartorUserId, string creartorFullName)
        {
            //thông tin hội đồng
            var getinfoHoiDong = await _hoidongtotnghiepRepository.GetInfo(idhoidong);
            if (getinfoHoiDong == null)
                return new ActionResultResponese<string>(-2, "Thông tin hội đồng không tồn tại.", "Hội đồng");

             var getinfoGVHD = await _giangVienHuongDanRepository.GetInfo(idgvhd, idhocky, idmonhoc);
             if (getinfoGVHD == null)
                 return new ActionResultResponese<string>(-4, "Giảng viên không tồn tại", "Giảng viên");

                var id = Guid.NewGuid().ToString();
                var chitietHD = new ChiTietHoiDong()
                {
                    IdChiTietHD = id,
                    IdHoiDong = getinfoHoiDong.IdHoiDong?.Trim(),
                    MaHoiDong = getinfoHoiDong.MaHoiDong?.Trim(),
                    TenHoiDong = getinfoHoiDong.TenHoiDong?.Trim(),
                    IdGiangVien = getinfoGVHD.IdGVHD?.Trim(),
                    TenGiangVien = getinfoGVHD.TenGVHD?.Trim(),
                    MaGiangVien = getinfoGVHD.MaGVHD?.Trim(),
                    NgayTao = DateTime.Now,
                    CreatorUserId = creartorUserId?.Trim(),
                    CreatorUserFullName = creartorFullName?.Trim(),
                    IsActive = true,
                    IsDelete = false
                };
            var result = await _chitiethoidongRepository.InserAsync(chitietHD);
            if(result <= 0)
                return new ActionResultResponese<string>(1, "Thêm mới chi tiết hội đồng tốt nghiệp không thành công", "Chi tiết hội đồng tốt nghiệp");
            return new ActionResultResponese<string>(1, "Thêm mới chi tiết hội đồng tốt nghiệp thành công", "Chi tiết hội đồng tốt nghiệp");
        }

        public async Task<ActionResultResponese<string>> DeleteAsync(string idchitietHD)
        {
            var checkchitietHD = await _chitiethoidongRepository.CheckExits(idchitietHD);
            if (!checkchitietHD)
                return new ActionResultResponese<string>(-5, "Chi tiết hội đồng không tồn tại", "Chi tiết hội đồng");
            var result = await _chitiethoidongRepository.DeleteByIdAsync(idchitietHD);
            if (result <= 0)
                return new ActionResultResponese<string>(-1, "Xóa chi tiết hội đồng không thành công", "Chi tiết hội đông");
            return new ActionResultResponese<string>(1, "Xóa chi tiết hội đồng thành công", "Chi tiết hội đông");
        }
    }
}
