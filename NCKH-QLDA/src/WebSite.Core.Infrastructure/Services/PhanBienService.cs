using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class PhanBienService : IPhanBienServicve
    {
        private readonly IPhanBienRepository _phanbienRepository;
        private readonly IHocKysRepository _hocKysRepository;
        private readonly IGiangVienHuongDanRepository _giangVienHuongDanRepository;
        private readonly IDeTaiRepository _deTaiRepository;
        private readonly IMonHocRepository _monhocRepository;
        private readonly IChiTietDeTaiRepository _chiTietDeTaiRepository;
        public PhanBienService(IPhanBienRepository phanbienRepository,
                               IHocKysRepository hocKysRepository,
                               IGiangVienHuongDanRepository giangVienHuongDanRepository,
                               IDeTaiRepository deTaiRepository,
                               IMonHocRepository monhocRepository,
                               IChiTietDeTaiRepository chiTietDeTaiRepository)
        {
            _phanbienRepository = phanbienRepository;
            _hocKysRepository = hocKysRepository;
            _giangVienHuongDanRepository = giangVienHuongDanRepository;
            _deTaiRepository = deTaiRepository;
            _monhocRepository = monhocRepository;
            _chiTietDeTaiRepository = chiTietDeTaiRepository;
        }
        public async Task<SearchResult<PhanBienSearchViewModel>> GetAllByIdHK(string idhocky,string idBoMon)
        {
            var checkExit = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (checkExit == false)
                return new SearchResult<PhanBienSearchViewModel>() { Code = -1, Data = null, Message = "Học kỳ không tồn tại." };
            return await _phanbienRepository.SelectAllByHk(idhocky,idBoMon);
        }
       public async Task<ActionResultResponese<string>> InsertByHk(PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky,string idmonhoc,string creatorUserId,string creatorFullName)
        {
            var checkPhanBien = await _phanbienRepository.CheckExisPhanBien(idGVPB, iddetai, idhocky, idmonhoc );
            if (checkPhanBien)
                return new ActionResultResponese<string>(-21, "Giảng viên đã phản biện đề tài này.", "Phản biện.");
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-5, "Học kỳ không tồn tại.", "Học kỳ.");
            var checExitsDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checExitsDeTai)
                return new ActionResultResponese<string>(-4, "Đề tài không tồn tại.", "Đề tài.");
            //var detaiInfo = await _deTaiRepository.GetInfo(iddetai, idhocky, idmonhoc);
            string id = Guid.NewGuid().ToString();
            //xử lý thông tin giảng viên ngoài học kỳ
            var phanBien = new PhanBien()
            {
                IdPhanBien = id,
                IdGVPB = idGVPB?.Trim(),
                IdDetai = iddetai?.Trim(),
                Diem = 0,
                IdHocKy = idhocky,
                IdMonHoc = idmonhoc,
                CreateTime = DateTime.Now,
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName =creatorFullName?.Trim(),
            };
            if (phanBien == null)
                return new ActionResultResponese<string>(-3, "Thêm mới thất bại.", "Phản biện.");
            var result = await _phanbienRepository.InsertByHk(phanBien);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Phản biện.");

        }

        public async Task<ActionResultResponese<string>> InsertListPBHk(List<PhanBienlistMeta> phanbienListMeta, string iddetai, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName)
        {
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-32, "Học kỳ không tồn tại.", "Học kỳ.");
            var checExitsDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checExitsDeTai)
                return new ActionResultResponese<string>(-33, "Đề tài không tồn tại.", "Đề tài.");
            List<PhanBienlistMeta> listGiangVien = phanbienListMeta.GroupBy(p => p.idGVPB).Select(g => g.First()).ToList();
            if (listGiangVien.Count() != phanbienListMeta.Count())
                return new ActionResultResponese<string>(-34, "Trùng lặp giảng viên.", "Giảng viên.");
            
           
            foreach (var giangvien in phanbienListMeta)
            {
                var checkPhanBien = await _phanbienRepository.CheckExisPhanBien(giangvien.idGVPB, iddetai, idhocky, idmonhoc);
                if (checkPhanBien)
                    return new ActionResultResponese<string>(-31, "Giảng viên đã phản biện đề tài này.", "Phản biện.");
                
            }
            List<PhanBien> listPhanBien = new List<PhanBien>();
            
            foreach (var giangvien in phanbienListMeta)
            {
                //var checkExitsGVHDinHocKy = await _giangVienHuongDanRepository.CheckExitsActive(idhocky, giangvien.IdGVHD);
                //if (checkExitsGVHDinHocKy)
                //    return new ActionResultResponese<string>(-16, "Giảng viên đã có trong kỳ.", "Giang vien hướng dẫn theo kỳ.");
                var giangvienInfo = await _giangVienHuongDanRepository.GetInfoByMaGVHD(idhocky, giangvien.idGVPB);
                var id = Guid.NewGuid().ToString();
                listPhanBien.Add(new PhanBien
                {
                    IdPhanBien = id?.Trim(),
                    IdGVPB = giangvienInfo.IdGVHD?.Trim(),
                    IdDetai = iddetai?.Trim(),
                    IdHocKy = idhocky?.Trim(),
                    IdMonHoc = idmonhoc?.Trim(),
                    Diem = 0,
                    CreateTime = DateTime.Now,
                    CreatorUserId = creatorUserId?.Trim(),
                    CreatorFullName = creatorFullName?.Trim(),
                    IsActive = true,
                    IsDelete = false
                }) ; 
            }
            if (listPhanBien.Count() == 0)
                return new ActionResultResponese<string>(-35, "Vui Chọn giảng viên.", "Giảng viên.");
            foreach (var giangvien in listPhanBien)
            {
                await _phanbienRepository.InsertByHk(giangvien);
            }

            //  return new ActionResultResponese<string>(result, "Thêm mới chi tiết đề tài không thành công", "Chi tiết đề tài.");
            return new ActionResultResponese<string>(1, "Thêm mới thành công.", "Phản biện.");
        }
        public async Task<ActionResultResponese<string>> Update(PhanBienUpdateMeta phanbienUpdateMeta, string idGVPB, string iddetai, string idhocky,string idmonhoc, string idPhanBien,string lastUpdateUserId, string lastUpdateFullName)
        {
            var checExitsPB = await _phanbienRepository.CheckExisPhanBien(idGVPB, idhocky,idmonhoc,iddetai);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-6, "Phản biện không có trong kỳ.", "Học kỳ.");
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-7, "Học kỳ không tồn tại.", "Học kỳ.");
            var checExitsDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checExitsDeTai)
                return new ActionResultResponese<string>(-8, "Đề tài không tồn tại.", "Đề tài.");
           // var detaiInfo = await _deTaiRepository.GetInfo(iddetai);
            //xử lý thông tin giảng viên ngoài học kỳ
            //var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(iddetai);
            //if (!checExitsHK)
            //    return new ActionResultResponese<string>(-5, "Học kỳ tồn tại.", "Học kỳ.");
            var phanBien = new PhanBien()
            {
                IdPhanBien = idPhanBien,
                IdGVPB = idGVPB?.Trim(),
                IdDetai = iddetai?.Trim(),
                Note = phanbienUpdateMeta.Note?.Trim(),
                IdHocKy = idhocky,
                LastUpdate = DateTime.Now,
                lastUpdateUserId = lastUpdateUserId?.Trim(),
                LastUpdateFullName = lastUpdateFullName?.Trim(),
            };
            if (phanBien == null)
                return new ActionResultResponese<string>(-9, "Sửa thất bại.", "Phản biện.");
            var result = await _phanbienRepository.Update(phanBien);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(result, "Sửa thành công.", "Phản biện.");
        }

        public async Task<ActionResultResponese<string>> UpdateDiemAsync(string idphanbien, NoteMeta note)
        {
            var checExitsPB = await _phanbienRepository.CheckExis(idphanbien);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-11, "Phản biện không có trong kỳ.", "Học kỳ.");
            if(10< note.Diem || note.Diem < 0)
                return new ActionResultResponese<string>(-12, "Nhập sai!", "điểm phản biện.");
            var result = await _phanbienRepository.UpdateDiem(note, idphanbien);
            if(result <=0 )
                return new ActionResultResponese<string>(-1, "Nhập điểm thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(1, "Nhập điểm thành công.", "Phản biện.");
        }

        public async Task<ActionResultResponese<string>> DeleteAsync(string idphanbien, string idhocky,string idmonhoc)
        {
            var checExitsPB = await _phanbienRepository.CheckExisActive(idphanbien);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-15, "Phản biện không có trong kỳ.", "Học kỳ.");

            var result = await _phanbienRepository.DeleteAsync(idphanbien);
            if (result <= 0)
                return new ActionResultResponese<string>(-1, "Xóa thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(1, "Xóa thành công.", "Phản biện.");
        }

        public async Task<ActionResultResponese<string>> InsertListDeTaiInPhanBien(List<DeTaiListMeta> lisDeTai, string idGiangVien, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon)
        {
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-41, "Học kỳ không tồn tại.", "Học kỳ.");
            
            List<DeTaiListMeta> listDeTai = lisDeTai.GroupBy(p => p.IdDeTai).Select(g => g.First()).ToList();
            if (lisDeTai.Count() != listDeTai.Count())
                return new ActionResultResponese<string>(-42, "Trùng lặp đề tài trong danh sách.", "Giảng viên.");

            var checkGV = await _giangVienHuongDanRepository.CheckExitsActive(idGiangVien,idhocky);
            if (checkGV)
                return new ActionResultResponese<string>(-43, "Giảng viên đã phản biện đề tài này.", "Phản biện.");

            var infoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if (infoMonHoc == null)
                return new ActionResultResponese<string>(-48, "Môn học không tồn tại", "Môn học.");
           

            foreach (var idDeTai in listDeTai)
            {
                var checExitsDeTai = await _deTaiRepository.CheckExits(idDeTai.IdDeTai);
                if (!checExitsDeTai)
                    return new ActionResultResponese<string>(-44, "Đề tài không tồn tại.", "Đề tài.");

            }
            List<PhanBien> listPhanBien = new List<PhanBien>();

            foreach (var idDeTai in listDeTai)
            {
                List<ChiTietDeTaiViewModel> listCTDT = await _chiTietDeTaiRepository.GetCheckGVHDnotPB(idDeTai.IdDeTai?.Trim());

                bool check = listCTDT.Any(item => item.IdGVHD?.Trim() == idGiangVien?.Trim());
                if (check)
                    continue;
                //int count = 0;
                var checkPhanBien = await _phanbienRepository.CheckExisPhanBien(idGiangVien, idDeTai.IdDeTai, idhocky, idmonhoc);
                if (checkPhanBien)
                    continue;

                var countPhanBien = await _phanbienRepository.CoutPhanBien(idDeTai.IdDeTai?.Trim());
                if (infoMonHoc.SoLuongPhanBien <= countPhanBien)
                    continue;
                
                var id = Guid.NewGuid().ToString();
                listPhanBien.Add(new PhanBien
                {
                    IdPhanBien = id?.Trim(),
                    IdGVPB = idGiangVien?.Trim(),
                    IdBoMon = idBoMon?.Trim(),
                    IdDetai = idDeTai.IdDeTai?.Trim(),
                    IdHocKy = idhocky?.Trim(),
                    IdMonHoc = idmonhoc?.Trim(),
                    Diem = 0,
                    CreateTime = DateTime.Now,
                    CreatorUserId = creatorUserId?.Trim(),
                    CreatorFullName = creatorFullName?.Trim(),
                    IsActive = true,
                    IsDelete = false
                });
            }
            if (listPhanBien.Count() == 0 && listDeTai.Count() !=0)
                return new ActionResultResponese<string>(-45, "Giảng viên đã được phân phản biện hoặc không được phép phản biện đề tài đã hướng dẫn.");
            else if (listPhanBien.Count() == 0 && listDeTai.Count() == 0)
                return new ActionResultResponese<string>(-46, "Vui lòng chọn đề tài");

            foreach (var giangvien in listPhanBien)
            {
                await _phanbienRepository.InsertByHk(giangvien);
            }

            //  return new ActionResultResponese<string>(result, "Thêm mới chi tiết đề tài không thành công", "Chi tiết đề tài.");
            return new ActionResultResponese<string>(1, "Thêm mới thành công.", "Phản biện.");
        }
    }
     
}
