using Microsoft.AspNetCore.Hosting;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly IChiTietDeTaiRepository _chiTietDeTaiRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DeTaiService(IDeTaiRepository deTaiRepository,
                            IMonHocRepository monhocRepository,
                            IHocKysRepository hockyRepository,
                            ISinhVienRepository sinhVienRepository,
                            IChiTietDeTaiRepository chiTietDeTaiRepository,
                            IFileRepository fileRepository,
                            IWebHostEnvironment webHostEnvironment) 
        {
            _deTaiRepository = deTaiRepository;
            _monhocRepository = monhocRepository;
            _hockyRepository = hockyRepository;
            _sinhVienRepository = sinhVienRepository;
            _chiTietDeTaiRepository = chiTietDeTaiRepository;
            _fileRepository = fileRepository;
            _webHostEnvironment = webHostEnvironment;
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
            return await _deTaiRepository.SelectByIdMonHocInHocKy(idhocky,idmonhoc);
        }

        public async Task<SearchResult<DeTaiSearchViewModel>> GetChuaPhanHDAsync(string idhocky, string idmonhoc,string idBoMon)
        {
            var checkIdKy = await _deTaiRepository.CheckExitsKyHoc(idhocky);
            if (!checkIdKy)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -21,
                    Message = "Kỳ học không tồn tại.",
                    Data = null
                };
            var CheckExist = await _deTaiRepository.CheckExitsActive(idhocky, idmonhoc);
            if (!CheckExist)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -22,
                    Message = "Môn học không có trong kỳ này.",
                    Data = null
                };
            var getInfoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if (getInfoMonHoc.TypeApprover.GetHashCode() == 0)
                return new SearchResult<DeTaiSearchViewModel>()
                {
                    Code = -23,
                    Message = "Môn học không có hội đồng.",
                    Data = null
                };
            return await _deTaiRepository.SelectChuaPhanHD(idhocky,idmonhoc,idBoMon);
        }
        public async Task<ActionResultResponese<string>> InsertAsync(DeTaiInsertMeta detaiInsertMeta, string idhocky, string idmonhoc, string idsinhvien, string creatorUserId,string creatorFullName,string idbomon)
        {
            var checkExitSV = await _sinhVienRepository.CheckExitsIdSinhVien(idsinhvien);
            if (!checkExitSV)
                return new ActionResultResponese<string>(-35, "Sinh viên không tồn tại.", "Sinh viên.");

            //var checkDeTai = await _deTaiRepository.CheckMaDeTai(madetai);
            //if (checkDeTai)
            //    return new ActionResultResponese<string>(-31, "Mã đề tài đã tồn tại.", "Đề tài.");

            var checkSinhVien = await _deTaiRepository.CheckExitsSinhVien(idhocky,idmonhoc,idsinhvien);
            if (checkSinhVien)
                return new ActionResultResponese<string>(-37, "Sinh viên đã có đề tài.", "Sinh viên.");

            var checExitHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checExitHocKy)
                return new ActionResultResponese<string>(-4, "Học kỳ không tồn tại.", "Học kỳ.");
          //  var hockyInfo = await _hockyRepository.SearchInfo(idhocky);
            var checExistMonHoc = await _monhocRepository.CheckExitsIsActvive(idmonhoc);
            if (!checExistMonHoc)
                return new ActionResultResponese<string>(-5, "Môn học không tồn tại.", "Môn học.");
           
            var monhocInfo = await _monhocRepository.GetInfoAsync(idmonhoc);
            var idTienQuyet = "0";
            if (monhocInfo.IdMonTienQuyet != idTienQuyet)
            {
                var checkIsDat = await _deTaiRepository.CheckIsDat(monhocInfo.IdMonTienQuyet, idsinhvien);
                if (!checkIsDat)
                    return new ActionResultResponese<string>(-21, "Sinh viên chưa hoàn thành môn " + monhocInfo.NameMonTienQuyet + " là môn tiên quyết.", "Môn học.");
            }
            var id = Guid.NewGuid().ToString();
            //var checkExits = await _deTaiRepository.CheckExits(id);
            //if (checkExits)
            //    return new ActionResultResponese<string>(-6, "IdDeTai đã tồn tại.", "Đề tài.");
            var checkExitsMaDeTai = await _deTaiRepository.CheckDeTaiVsMonHoc(idhocky,idmonhoc,id,idbomon);
            if (checkExitsMaDeTai)
                return new ActionResultResponese<string>(-7, "Mã đề tài đã tồn tại.", "Đề tài.");

            var infoSinhVien = await _sinhVienRepository.GetInfo(idsinhvien);
            if (infoSinhVien == null)
                return new ActionResultResponese<string>(-21, "Sinh viên không tồn tại", " Sinh viên.");
            
            var maDeTai = "DT" + infoSinhVien.MaSinhVien?.Trim();

            var detai = new DeTai()
            {
                IdDeTai = id?.Trim(),
                IdBoMon = idbomon?.Trim(),
                MaDeTai = maDeTai?.Trim(),
                TenDeTai = detaiInsertMeta.TenDeTai?.Trim(),
                IdSinhVien = idsinhvien?.Trim(),
                IdHocKy = idhocky?.Trim(),
                IdMonHoc = idmonhoc?.Trim(),
                DiemTrungBinh = 0,
                IsDat = false,
                CreateTime = DateTime.Now,
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
            };
            if (detai == null)
                return new ActionResultResponese<string>(-8, "Dữ liệu trống", "Đề tài.");
            var result = await _deTaiRepository.InsertAsync(detai);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm  mới thất bại.", "Đề tài.");
            return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Đề tài.");

        }
        public async Task<ActionResultResponese<string>> UpdateAsync(DeTaiUpdateMeta detaiUpdateMeta, string iddetai, string LastUpdateUserId, string LastUpdateFullName, string idBoMon)
        {
            
            var info = await _deTaiRepository.GetInfo(iddetai);
            if (info == null)
                return new ActionResultResponese<string>(-1, "Đề tài không tồn tại.", "Đề tài.");

            //var isNameExit = await _deTaiRepository.CheckMaDeTai(detaiUpdateMeta.TenDeTai?.Trim());
            //if (isNameExit)
            //    return new ActionResultResponese<string>(-4, "Mã đề tài đã tồn tại.", "Đề tài.");

            info.IdDeTai = iddetai?.Trim();
            info.TenDeTai = detaiUpdateMeta.TenDeTai?.Trim();
            info.LastUpdate = DateTime.Now;
            info.lastUpdateUserId = LastUpdateUserId?.Trim();
            info.LastUpdateFullName = LastUpdateFullName?.Trim();

            var result = await _deTaiRepository.UpdateAsync(info);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Sửa thất bại.", "Đề tài.");
            return new ActionResultResponese<string>(result, "Sửa thành công.", "Đề tài.");

        }
        public async Task<ActionResultResponese<string>> UpdateDiemSxAsync(string iddetai, float? diem, string LastUpdateUserId, string LastUpdateFullName, string idBoMon)
        {

            var info = await _deTaiRepository.GetInfo(iddetai);
            if (info == null)
                return new ActionResultResponese<string>(-1, "Đề tài không tồn tại.", "Đề tài.");

            if (diem < 0 || diem > 10)
                return new ActionResultResponese<string>(-1, "Nhập điểm không hợp lệ", "Đề tài.");

            //var isNameExit = await _deTaiRepository.CheckMaDeTai(detaiUpdateMeta.TenDeTai?.Trim());
            //if (isNameExit)
            //    return new ActionResultResponese<string>(-4, "Mã đề tài đã tồn tại.", "Đề tài.");
            if (diem > 0 && diem < 5)
            {
                info.IsDat = false;
            }
            else if (diem >= 5 && diem <= 10)
            {
                info.IsDat = true;
            }
            info.IdDeTai = iddetai?.Trim();
            info.DiemTrungBinh = diem;
            info.LastUpdate = DateTime.Now;
            info.lastUpdateUserId = LastUpdateUserId?.Trim();
            info.LastUpdateFullName = LastUpdateFullName?.Trim();

            var result = await _deTaiRepository.UpdateAsync(info);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Vào điểm thất bại.", "Đề tài.");
            return new ActionResultResponese<string>(result, "Vào điểm điểm thành công.", "Đề tài.");

        }
        public async Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky,bool isApprove)
        {

            var checkExits = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkExits)
                return new SearchResult<DeTaivsCTDTViewModel> { Code = -2, Data=null };
            return await _deTaiRepository.SelectByIdCTDTAsync(idhocky, isApprove);
            
        }

        public async Task<ActionResultResponese<string>> DeleteAsync(string iddetai, string deleteUserId, string deleteFullName)
        {
            //var checExitDeTai = await _chiTietDeTaiRepository.CheckExits(iddetai);
            //if (!checExitDeTai)
            //    return new ActionResultResponese<string>(-4, "Chi tiết đề tài không tồn tại.", "Chi tiết đề tài.");
            var checkDeTai = await _deTaiRepository.CheckExits(iddetai);
            if (!checkDeTai)
                return new ActionResultResponese<string>(-8, "Đề tài không tồn tại.", "Môn học.");
            var result = await _deTaiRepository.DeleteAsync(iddetai,deleteUserId,deleteFullName,DateTime.Now);
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

        public async Task<SearchResult<DeTaiPhanBienViewModel>> DeTaiPhanPhanBien(string idhocky, string idmonhoc, string idBoMon, string idGVHD)
        {
            return await _deTaiRepository.DeTaiPhanBien(idhocky, idmonhoc,idBoMon,idGVHD);
        }

        public async Task<ActionResultResponese<string>> InsertFromExcelAsync(string idfile, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon)
        {
            
            var checExistMonHoc = await _monhocRepository.CheckExitsIsActvive(idmonhoc);
            if (!checExistMonHoc)
                return new ActionResultResponese<string>(-5, "Môn học không tồn tại.", "Môn học.");
            var infofile = await _fileRepository.GetInfo(idfile);
            if (infofile == null)
                return new ActionResultResponese<string>(-6, "File điểm không tồn tại.", "File điểm.");


            List<DeTaiFromExcelMeta> _listDeTaiSinhVien = new List<DeTaiFromExcelMeta>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
            {
                ExcelWorksheet worsheet = pakage.Workbook.Worksheets["DeTaiSinhVien"];
                if (worsheet == null)
                    return new ActionResultResponese<string>(-9, "File sinh viên không đúng định dạng", "File danh sách sinh viên");
                for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
                {
                    if (worsheet.Cells[i, 1].Value != null && worsheet.Cells[i, 2].Value != null && worsheet.Cells[i, 5].Value != null
                        && worsheet.Cells[i, 6].Value != null && worsheet.Cells[i, 8].Value != null && worsheet.Cells[i, 10].Value != null)
                    {
                        //int j = 1;
                        string idsinhvien = worsheet.Cells[i, 1].Value.ToString();
                        string maSinhVien = worsheet.Cells[i, 2].Value.ToString();
                        string TenDeTai = worsheet.Cells[i, 3].Value == null ? "" : worsheet.Cells[i, 3].Value.ToString();
                        DeTaiFromExcelMeta _detaisinhVien = new DeTaiFromExcelMeta()
                        {
                            IdSinhVien = idsinhvien?.Trim(),
                            IdBoMon = idBoMon?.Trim(),
                            MaSinhVien = maSinhVien?.Trim(),
                            TenDeTai = TenDeTai?.Trim(),
                        };
                        _listDeTaiSinhVien.Add(_detaisinhVien);
                    }
                    else break;
                }

                var demsucess = 0;

                if (_listDeTaiSinhVien != null)
                {
                    var dem = 0;
                    foreach (var item in _listDeTaiSinhVien)
                    {
                        var infoSinhVien = await _sinhVienRepository.GetInfo(item.IdSinhVien);
                        if (infoSinhVien == null)
                        {
                            dem++;
                            continue;
                        }
                        var checkSinhVien = await _deTaiRepository.CheckExitsSinhVien(idhocky, idmonhoc, item.IdSinhVien);
                        if (checkSinhVien)
                        {
                            dem++;
                            continue;
                        }

                        var checExitHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
                        if (!checExitHocKy)
                        {
                            dem++;
                            continue;
                        }
                        
                        var monhocInfo = await _monhocRepository.GetInfoAsync(idmonhoc);
                        var idTienQuyet = "0";
                        if (monhocInfo.IdMonTienQuyet != idTienQuyet)
                        {
                            var checkIsDat = await _deTaiRepository.CheckIsDat(monhocInfo.IdMonTienQuyet, item.IdSinhVien);
                            if (!checkIsDat)
                                return new ActionResultResponese<string>(-21, "Sinh viên chưa hoàn thành môn " + monhocInfo.NameMonTienQuyet + " là môn tiên quyết.", "Môn học.");
                        }
                        var id = Guid.NewGuid().ToString();
                        //var checkExits = await _deTaiRepository.CheckExits(id);
                        //if (checkExits)
                        //    return new ActionResultResponese<string>(-6, "IdDeTai đã tồn tại.", "Đề tài.");
                        var checkExitsMaDeTai = await _deTaiRepository.CheckDeTaiVsMonHoc(idhocky, idmonhoc, id, idBoMon);
                        if (checkExitsMaDeTai)
                        {
                            dem++;
                            continue;
                        }

                        var maDeTai = "DT" + infoSinhVien.MaSinhVien?.Trim();

                        var detai = new DeTai()
                        {
                            IdDeTai = id?.Trim(),
                            IdBoMon = idBoMon?.Trim(),
                            MaDeTai = maDeTai?.Trim(),
                            TenDeTai = item.TenDeTai?.Trim(),
                            IdSinhVien = item.IdSinhVien?.Trim(),
                            IdHocKy = idhocky?.Trim(),
                            IdMonHoc = idmonhoc?.Trim(),
                            DiemTrungBinh = 0,
                            IsDat = false,
                            CreateTime = DateTime.Now,
                            CreatorUserId = creatorUserId?.Trim(),
                            CreatorFullName = creatorFullName?.Trim(),
                        };
                        if (detai == null)
                            return new ActionResultResponese<string>(-8, "Dữ liệu trống", "Đề tài.");
                        var result = await _deTaiRepository.InsertAsync(detai);
                        if (result > 0)
                        {
                            demsucess++;
                        }
                    }
                }
                if (demsucess > 0)
                    return new ActionResultResponese<string>(1,"Có "+ _listDeTaiSinhVien.Count() + "sinh viênn","","Khởi tạo thành công "+ demsucess +" đề tài.");
                else
                    return new ActionResultResponese<string>("Khởi tạo đề tài thất bại kiểm tra lại file và gửi lại");

            }
        }
    }
}
