using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
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
        public PhanBienService(IPhanBienRepository phanbienRepository,
                               IHocKysRepository hocKysRepository,
                               IGiangVienHuongDanRepository giangVienHuongDanRepository,
                               IDeTaiRepository deTaiRepository )
        {
            _phanbienRepository = phanbienRepository;
            _hocKysRepository = hocKysRepository;
            _giangVienHuongDanRepository = giangVienHuongDanRepository;
            _deTaiRepository = deTaiRepository;
        }
        public async Task<SearchResult<PhanBienSearchViewModel>> GetAllByIdHK(string idhocky)
        {
            var checkExit = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (checkExit == false)
                return new SearchResult<PhanBienSearchViewModel>() { Code = -1, Data = null, Message = "Học kỳ không tồn tại." };
            return await _phanbienRepository.SelectAllByHk(idhocky);
        }
       public async Task<ActionResultResponese<string>> InsertByHk(PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky)
        {
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-5, "Học kỳ không tồn tại.", "Học kỳ.");
            var checExitsDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checExitsDeTai)
                return new ActionResultResponese<string>(-4, "Đề tài không tồn tại.", "Đề tài.");
            var detaiInfo = await _deTaiRepository.GetInfo(iddetai);
            string id = Guid.NewGuid().ToString();
            //xử lý thông tin giảng viên ngoài học kỳ
            var phanBien = new PhanBien()
            {
                IdPhanBien = id,
                IdGVPB = idGVPB?.Trim(),
                TenGVPB = phanbienMeta.TenGVPB?.Trim(),
                MaGVPB = phanbienMeta.MaGVPB?.Trim(),
                IdDetai = iddetai?.Trim(),
                MaDeTai = detaiInfo.MaDeTai?.Trim(),
                Diem = 0,
                Note = phanbienMeta.Note?.Trim(),
                IdHocKy = idhocky,
                NgayTao = DateTime.Now,
            };
            if (phanBien == null)
                return new ActionResultResponese<string>(-3, "Thêm mới thất bại.", "Phản biện.");
            var result = await _phanbienRepository.InsertByHk(phanBien);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Phản biện.");

        }
        public async Task<ActionResultResponese<string>> Update(PhanBienUpdateMeta phanbienUpdateMeta, string idGVPB, string iddetai, string idhocky, string idPhanBien)
        {
            var checExitsPB = await _phanbienRepository.CheckExis(idPhanBien,idhocky);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-6, "Phản biện không có trong kỳ.", "Học kỳ.");
            var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitsHK)
                return new ActionResultResponese<string>(-7, "Học kỳ không tồn tại.", "Học kỳ.");
            var checExitsDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checExitsDeTai)
                return new ActionResultResponese<string>(-8, "Đề tài không tồn tại.", "Đề tài.");
            var detaiInfo = await _deTaiRepository.GetInfo(iddetai);
            //xử lý thông tin giảng viên ngoài học kỳ
            //var checExitsHK = await _hocKysRepository.CheckExisIsActivetAsync(iddetai);
            //if (!checExitsHK)
            //    return new ActionResultResponese<string>(-5, "Học kỳ tồn tại.", "Học kỳ.");
            var phanBien = new PhanBien()
            {
                IdPhanBien = idPhanBien,
                IdGVPB = idGVPB?.Trim(),
                TenGVPB = phanbienUpdateMeta.TenGVPB?.Trim(),
                MaGVPB = phanbienUpdateMeta.MaGVPB?.Trim(),
                IdDetai = iddetai?.Trim(),
                MaDeTai = detaiInfo.MaDeTai?.Trim(),
                Note = phanbienUpdateMeta.Note?.Trim(),
                IdHocKy = idhocky,
                NgaySua = DateTime.Now,
            };
            if (phanBien == null)
                return new ActionResultResponese<string>(-9, "Sửa thất bại.", "Phản biện.");
            var result = await _phanbienRepository.Update(phanBien);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(result, "Sửa thành công.", "Phản biện.");
        }

        public async Task<ActionResultResponese<string>> UpdateDiemAsync(string idphanbien,string idhocKy, float Diem, NoteMeta note)
        {
            var checExitsPB = await _phanbienRepository.CheckExis(idphanbien, idhocKy);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-11, "Phản biện không có trong kỳ.", "Học kỳ.");
            if(10< Diem || Diem < 0)
                return new ActionResultResponese<string>(-12, "Nhập sai!", "điểm phản biện.");
            var result = await _phanbienRepository.UpdateDiem(note, Diem, idphanbien);
            if(result <=0 )
                return new ActionResultResponese<string>(-1, "Nhập điểm thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(1, "Nhập điểm thành công.", "Phản biện.");
        }

        public async Task<ActionResultResponese<string>> DeleteAsync(string idphanbien, string idhocky)
        {
            var checExitsPB = await _phanbienRepository.CheckExis(idphanbien, idhocky);
            if (!checExitsPB)
                return new ActionResultResponese<string>(-15, "Phản biện không có trong kỳ.", "Học kỳ.");

            var result = await _phanbienRepository.DeleteAsync(idphanbien);
            if (result <= 0)
                return new ActionResultResponese<string>(-1, "Xóa thất bại.", "Phản biện.");
            return new ActionResultResponese<string>(1, "Xóa thành công.", "Phản biện.");
        }
    }
     
}
