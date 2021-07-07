using Microsoft.AspNetCore.Hosting;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class NhapDiemService : INhapDiemService
    {

        private readonly IPhanBienRepository _phanBienRepository;
        private readonly IBangDiemRepository _bangdiemRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IDeTaiRepository _deTaiRepository;
        private readonly IMonHocRepository _monHocRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NhapDiemService(IPhanBienRepository phanBienRepository,
                               IBangDiemRepository bangdiemRepository,
                               IFileRepository fileRepository,
                               IWebHostEnvironment webHostEnvironment,
                               IDeTaiRepository deTaiRepository,
                               IMonHocRepository monHocRepository)
        {
            _phanBienRepository = phanBienRepository;
            _bangdiemRepository = bangdiemRepository;
            _fileRepository = fileRepository;
            _deTaiRepository = deTaiRepository;
            _monHocRepository = monHocRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// chu y duong dan lay file excel la lay tu upload cua API upFile
        /// Insert phan bien
        /// </summary>
        /// <param name="NhapDiemService"></param>
        /// <returns></returns>
        public async Task<ActionResultResponese<List<XuatDiemPhanBienViewModel>>> InsertListExcelAsync(string idfile, string idBoMon, string lastUpdateUserId, string lastUpdateFullName)
        {
            var infofile = await _fileRepository.GetInfo(idfile);
            if (infofile == null)
                return new ActionResultResponese<List<XuatDiemPhanBienViewModel>>(-2, "File điểm không tồn tại.", "File điểm.");

            List<XuatDiemPhanBienViewModel> phanbien = new List<XuatDiemPhanBienViewModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
            {
                //var worsheet = pakage.Workbook.Worksheets.First()
                
                ExcelWorksheet worsheet = pakage.Workbook.Worksheets["DiemPhanBien"];
                if(worsheet == null)
                    return new ActionResultResponese<List<XuatDiemPhanBienViewModel>>(-9, "File điểm không đúng định dạng", "File điểm phản biện");

                for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
                {
                    if (worsheet.Cells[i, 1].Value != null && worsheet.Cells[i, 2].Value != null && worsheet.Cells[i, 3].Value != null)
                    {
                        //int j = 1;
                        string idPhanBien = worsheet.Cells[i, 1].Value.ToString();
                        string diem = worsheet.Cells[i, 2].Value.ToString();
                        string note = worsheet.Cells[i, 3].Value.ToString();
                        float diemphanbien = float.Parse(diem);
                        string maGVHD = worsheet.Cells[i, 4].Value.ToString();
                        string tenGVHD = worsheet.Cells[i, 5].Value == null ? "" : worsheet.Cells[i, 5].Value.ToString();
                        string maDeTai = worsheet.Cells[i, 6].Value.ToString();
                        string tenDeTai = worsheet.Cells[i, 7].Value == null ? "" : worsheet.Cells[i, 7].Value.ToString();
                        string maSinhVien = worsheet.Cells[i, 9].Value?.ToString();
                        string TenSinhVien = worsheet.Cells[i, 8].Value == null ? "" : worsheet.Cells[i, 8].Value.ToString();
                        XuatDiemPhanBienViewModel _phanbienlist = new XuatDiemPhanBienViewModel()
                        {
                            IdPhanBien = idPhanBien?.Trim(),
                            Diem = diemphanbien,
                            Note = note?.Trim(),
                            MaGVHD = maGVHD?.Trim(),
                            TenGVHD = tenGVHD?.Trim(),
                            MaDeTai = maDeTai?.Trim(),
                            TenDeTai = tenDeTai?.Trim(),
                            MaSinhVien = maSinhVien?.Trim(),
                            TenSinhVien = TenSinhVien?.Trim()
                        };
                        phanbien.Add(_phanbienlist);
                    } 
                    else break;
                }
            }

            
          //  List<XuatDiemPhanBienViewModel> dbdiemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc, idBoMon);
            //if(dbdiemphanbien.Count() != phanbien.Count())
            int dem = 0;
            List<XuatDiemPhanBienViewModel> diemPhanBienFail = new List<XuatDiemPhanBienViewModel>();
            foreach (var item in phanbien)
            {
                var info = await _phanBienRepository.GetInfoAsync(item.IdPhanBien?.Trim());
                if (info == null || item.Diem < 0 || item.Diem > 10 || info.IdBoMon?.Trim() != idBoMon?.Trim())
                {
                    dem++;
                    diemPhanBienFail.Add(new XuatDiemPhanBienViewModel()
                    {
                        IdPhanBien = item.IdPhanBien?.Trim(),
                        Diem = item.Diem,
                        Note = item.Note?.Trim(),
                        MaGVHD = item.MaGVHD?.Trim(),
                        TenGVHD = item.TenGVHD?.Trim(),
                        MaDeTai = item.MaDeTai?.Trim(),
                        TenDeTai = item.TenDeTai?.Trim(),
                        MaSinhVien = item.MaSinhVien?.Trim(),
                        TenSinhVien = item.TenSinhVien?.Trim()
                    });
                    continue;
                }
                info.Diem = item.Diem;
                info.Note = item.Note?.Trim();
                info.IdPhanBien = item.IdPhanBien?.Trim();
                info.lastUpdateUserId = lastUpdateUserId?.Trim();
                info.LastUpdateFullName = lastUpdateFullName?.Trim();
                info.LastUpdate = DateTime.Now;

                await _phanBienRepository.Update(info);

            }
            if (dem > 0)
                return new ActionResultResponese<List<XuatDiemPhanBienViewModel>>(-2, "Có lỗi khi vào điểm có " + dem + " giảng viên không vào được điểm", "Điểm phản biện",diemPhanBienFail);
            else if (dem == phanbien.Count())
                return new ActionResultResponese<List<XuatDiemPhanBienViewModel>>(-3, "File điểm lỗi không thển vào điểm, vui lòng liên hệ quản trị viên", "File điểm phản biện.");
            else
                return new ActionResultResponese<List<XuatDiemPhanBienViewModel>>(1, "Vào điểm thành công", "Điểm phản biện");
        }

        /// <summary>
        ///    Vao điểm hội đồng
        /// Insert điểm hội đồng
        /// </summary>
        /// <param name="NhapDiemService"></param>
        /// <returns></returns>
        public async Task<ActionResultResponese<List<XuatDiemHoiDongViewModel>>> InsertDiemHoiDongExcelAsync(string idfile, string idmonhoc, string idBoMon, string lastUpdateUserId, string lastUpdateFullName)
        {

            var infofile = await _fileRepository.GetInfo(idfile);
            if (infofile == null)
                return new ActionResultResponese<List< XuatDiemHoiDongViewModel>> (-6, "File điểm không tồn tại.", "File điểm.");

            var infoMonHoc = await _monHocRepository.GetInfoAsync(idmonhoc);
            if(infoMonHoc == null )
                return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-14, "môn học không tồn tại.", "Môn học");

            if (infoMonHoc.TypeApprover == 2)
            {
                List<XuatDiemHoiDongViewModel> hoidong = new List<XuatDiemHoiDongViewModel>();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
                {
                    //var worsheet = pakage.Workbook.Worksheets.First()

                    ExcelWorksheet worsheet = pakage.Workbook.Worksheets["DiemHoiDong"];
                    if (worsheet == null)
                        return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-9, "File điểm không đúng định dạng", "File điểm phản biện");
                    for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
                    {
                        if (worsheet.Cells[i, 1].Value != null && worsheet.Cells[i, 2].Value != null && worsheet.Cells[i, 5].Value != null
                            && worsheet.Cells[i, 6].Value != null && worsheet.Cells[i, 8].Value != null && worsheet.Cells[i, 10].Value != null)
                        {
                            //int j = 1;
                            string idBangDiem = worsheet.Cells[i, 1].Value.ToString();
                            string diemSo = worsheet.Cells[i, 2].Value.ToString();
                            string nhanXet = worsheet.Cells[i, 3].Value == null ? "" : worsheet.Cells[i, 3].Value.ToString();
                            float diemtvHD = float.Parse(diemSo);
                            string maHoiDong = worsheet.Cells[i, 4].Value == null ? "" : worsheet.Cells[i, 4].Value.ToString();
                            string tenHoiDong = worsheet.Cells[i, 5].Value.ToString();
                            string maGVHD = worsheet.Cells[i, 6].Value.ToString();
                            string tenGVHD = worsheet.Cells[i, 7].Value == null ? "" : worsheet.Cells[i, 7].Value.ToString();
                            string maDeTai = worsheet.Cells[i, 8].Value.ToString();
                            string tenDeTai = worsheet.Cells[i, 9].Value == null ? "" : worsheet.Cells[i, 9].Value.ToString();
                            string maSinhVien = worsheet.Cells[i, 10].Value?.ToString();
                            string TenSinhVien = worsheet.Cells[i, 11].Value == null ? "" : worsheet.Cells[i, 11].Value.ToString();
                            XuatDiemHoiDongViewModel _hoidong = new XuatDiemHoiDongViewModel()
                            {
                                IdBangDiem = idBangDiem?.Trim(),
                                DiemSo = diemtvHD,
                                NhanXetGV = nhanXet?.Trim(),
                                MaGVHD = maGVHD?.Trim(),
                                TenGVHD = tenGVHD?.Trim(),
                                MaDeTai = maDeTai?.Trim(),
                                TenDeTai = tenDeTai?.Trim(),
                                MaSinhVien = maSinhVien?.Trim(),
                                TenSinhVien = TenSinhVien?.Trim(),
                                MaHoiDong = maHoiDong?.Trim(),
                                TenHoiDong = tenHoiDong?.Trim(),
                            };
                            hoidong.Add(_hoidong);
                        }
                        else break;
                    }
                }


                //  List<XuatDiemPhanBienViewModel> dbdiemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc, idBoMon);
                //if(dbdiemphanbien.Count() != phanbien.Count())
                int dem = 0;
                List<XuatDiemHoiDongViewModel> listUpdateFail = new List<XuatDiemHoiDongViewModel>();
                foreach (var item in hoidong)
                {
                    var info = await _bangdiemRepository.GetInfo(item.IdBangDiem?.Trim());
                    if (info == null || item.DiemSo < 0 || item.DiemSo > 10 || info.IdBoMon?.Trim() != idBoMon?.Trim())
                    {
                        dem++;
                        listUpdateFail.Add(new XuatDiemHoiDongViewModel()
                        {
                            IdBangDiem = item.IdBangDiem?.Trim(),
                            DiemSo = item.DiemSo,
                            MaGVHD = item.MaGVHD?.Trim(),
                            TenGVHD = item.TenGVHD?.Trim(),
                            MaSinhVien = item.MaSinhVien?.Trim(),
                            TenSinhVien = item.TenSinhVien?.Trim(),
                            MaDeTai = item.MaDeTai?.Trim(),
                            TenDeTai = item.TenDeTai?.Trim(),
                            MaHoiDong = item.MaHoiDong?.Trim(),
                            TenHoiDong = item.TenHoiDong?.Trim(),

                        });
                        continue;
                    }
                    info.DiemSo = item.DiemSo;
                    info.NhanXetGV = item.NhanXetGV?.Trim();
                    info.IdBangDiem = item.IdBangDiem?.Trim();
                    info.CreatorPointUserId = lastUpdateUserId?.Trim();
                    info.CreatorPointFullName = lastUpdateFullName?.Trim();
                    info.NgayVaoDiem = DateTime.Now;

                    await _bangdiemRepository.UpdateDiemAsync(info);

                }
                if (dem > 0)
                {
                    return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-7, "Có lỗi khi vào điểm có " + dem + " giảng viên không vào được điểm", "Điểm hội đồng", listUpdateFail);
                }
                else if (dem == hoidong.Count())
                    return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-8, "File điểm lỗi không thển vào điểm, vui lòng liên hệ quản trị viên", "File điểm hội đồng.");
            }
            else if (infoMonHoc.TypeApprover == 1)
            {
                List<XuatDiemHoiDongViewModel> hoidong = new List<XuatDiemHoiDongViewModel>();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
                {
                    //var worsheet = pakage.Workbook.Worksheets.First()

                    ExcelWorksheet worsheet = pakage.Workbook.Worksheets["DiemHoiDong"];
                    if (worsheet == null)
                        return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-9, "File điểm không đúng định dạng", "File điểm phản biện");
                    for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
                    {
                        if (worsheet.Cells[i, 1].Value != null && worsheet.Cells[i, 2].Value != null && worsheet.Cells[i, 5].Value != null && worsheet.Cells[i, 8].Value != null && worsheet.Cells[i, 10].Value != null)
                        {
                            //int j = 1;
                            string idBangDiem = worsheet.Cells[i, 1].Value.ToString();
                            string diemSo = worsheet.Cells[i, 2].Value.ToString();
                            string nhanXet = worsheet.Cells[i, 3].Value == null ? "" : worsheet.Cells[i, 3].Value.ToString();
                            float diemtvHD = float.Parse(diemSo);
                            string maHoiDong = worsheet.Cells[i, 4].Value == null ? "" : worsheet.Cells[i, 10].Value.ToString();
                            string tenHoiDong = worsheet.Cells[i, 5].Value.ToString();
                            string maDeTai = worsheet.Cells[i, 8].Value.ToString();
                            string tenDeTai = worsheet.Cells[i, 9].Value == null ? "" : worsheet.Cells[i, 10].Value.ToString();
                            string maSinhVien = worsheet.Cells[i, 10].Value?.ToString();
                            string TenSinhVien = worsheet.Cells[i, 11].Value == null ? "" : worsheet.Cells[i, 11].Value.ToString();
                            XuatDiemHoiDongViewModel _hoidong = new XuatDiemHoiDongViewModel()
                            {
                                IdBangDiem = idBangDiem?.Trim(),
                                DiemSo = diemtvHD,
                                NhanXetGV = nhanXet?.Trim(),
                                MaDeTai = maDeTai?.Trim(),
                                TenDeTai = tenDeTai?.Trim(),
                                MaSinhVien = maSinhVien?.Trim(),
                                TenSinhVien = TenSinhVien?.Trim(),
                                MaHoiDong = maHoiDong?.Trim(),
                                TenHoiDong = tenHoiDong?.Trim(),
                            };
                            hoidong.Add(_hoidong);
                        }
                        else break;
                    }
                }


                //  List<XuatDiemPhanBienViewModel> dbdiemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc, idBoMon);
                //if(dbdiemphanbien.Count() != phanbien.Count())
                int dem = 0;
                List<XuatDiemHoiDongViewModel> listUpdateFail = new List<XuatDiemHoiDongViewModel>();
                foreach (var item in hoidong)
                {
                    var info = await _bangdiemRepository.GetInfo(item.IdBangDiem?.Trim());
                    if (info == null || item.DiemSo < 0 || item.DiemSo > 10 || info.IdBoMon?.Trim() != idBoMon?.Trim())
                    {
                        dem++;
                        listUpdateFail.Add(new XuatDiemHoiDongViewModel()
                        {
                            IdBangDiem = item.IdBangDiem?.Trim(),
                            DiemSo = item.DiemSo,
                            MaSinhVien = item.MaSinhVien?.Trim(),
                            TenSinhVien = item.TenSinhVien?.Trim(),
                            MaDeTai = item.MaDeTai?.Trim(),
                            TenDeTai = item.TenDeTai?.Trim(),
                            MaHoiDong = item.MaHoiDong?.Trim(),
                            TenHoiDong = item.TenHoiDong?.Trim(),

                        });
                        continue;
                    }
                    info.DiemSo = item.DiemSo;
                    info.NhanXetGV = item.NhanXetGV?.Trim();
                    info.IdBangDiem = item.IdBangDiem?.Trim();
                    info.CreatorPointUserId = lastUpdateUserId?.Trim();
                    info.CreatorPointFullName = lastUpdateFullName?.Trim();
                    info.NgayVaoDiem = DateTime.Now;

                    await _bangdiemRepository.UpdateDiemAsync(info);

                }
                if (dem > 0)
                {
                    return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-21, "Có lỗi khi vào điểm có " + dem + " giảng viên không vào được điểm", "Điểm hội đồng", listUpdateFail);
                }
                else if (dem == hoidong.Count())
                    return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(-22, "File điểm lỗi không thển vào điểm, vui lòng liên hệ quản trị viên", "File điểm hội đồng.");  
                    
            }
            return new ActionResultResponese<List<XuatDiemHoiDongViewModel>>(1, "Vào điểm thành công", "Điểm hội đồng.");


        }


        public async Task<ActionResultResponese<string>> ChungBinhDiem(string idhocky, string idMonHoc, string idBoMon, string lastUpdateUserId, string lastUpdateFullName)
        {
            
            List<DeTai> detailist = await _deTaiRepository.SelectList(idhocky, idMonHoc, idBoMon);
            if (detailist == null)
                return new ActionResultResponese<string>(-14, "Không tìm thấy đề tài của môn học này ", "đề tài");
            var dem = 0;
            foreach (var item in detailist)
            {
                var listdiemHD = await _bangdiemRepository.DetailDiemHD(idBoMon,idhocky,idMonHoc,item.IdDeTai);
                var listPB = await _phanBienRepository.ListPhanBien(idBoMon, idhocky, idMonHoc, item.IdDeTai);
                if (listdiemHD != null && listPB != null)
                {
                    var DiemTBC = (listdiemHD.Sum(x => x.DiemSo) + listPB.Sum(y => y.Diem)) / (listdiemHD.Count() + listPB.Count());
                    ///var DiemTBC = MathF.Round(d,1,MidpointRounding.ToPositiveInfinity);
                    var infoDeTai = await _deTaiRepository.GetInfo(item.IdDeTai);
                    if (DiemTBC < 5 && DiemTBC >= 0)
                    {
                        infoDeTai.IsDat = false;
                    }
                    else if (DiemTBC >= 5 && DiemTBC <= 10)
                    {
                        infoDeTai.IsDat = true;
                    }
                    infoDeTai.DiemTrungBinh = DiemTBC;
                    infoDeTai.LastUpdate = DateTime.Now;
                    infoDeTai.lastUpdateUserId = lastUpdateUserId?.Trim();
                    infoDeTai.LastUpdateFullName = lastUpdateFullName?.Trim();

                    var result = await _deTaiRepository.UpdateAsync(infoDeTai);
                    if (result <= 0)
                        dem++;
                }
                else
                    dem++;
            }
            if (dem > 0)
                return new ActionResultResponese<string>(-11, "Có " + dem + " đề tài không cập nhật được điểm, vui lòng kiểm tra lại.");
            else if (dem == detailist.Count())
                return new ActionResultResponese<string>(-13, "Lỗi hệ thống không thể cập nhật điểm, liên hệ quản trị viên");
            else if(detailist.Count() - dem == 0)
                return new ActionResultResponese<string>(1, "Cập nhật điểm các đề tài thành công","điểm đề tài");
            return new ActionResultResponese<string>(1, "Cập nhật điểm các đề tài thành công", "điểm đề tài");

        }
    }
}
