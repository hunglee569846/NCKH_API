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
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly IHocKysRepository _HocKysRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SinhVienService(ISinhVienRepository sinhVienRepository,
                              IHocKysRepository hocyysRepository,
                              IFileRepository fileRepository,
                              IWebHostEnvironment webHostEnvironment)
        {

            _sinhVienRepository = sinhVienRepository;
            _HocKysRepository = hocyysRepository;
            _fileRepository = fileRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<SearchResult<SinhVienSearchViewModel>> GetByIdAsync(string idsinhvien)
        {
            return await _sinhVienRepository.SearchById(idsinhvien);
        }

        public async Task<SearchResult<SinhVienSearchViewModel>> GetChuaDeTai(string idhocky, string idmonhoc, string idBoMon)
        {
            return await _sinhVienRepository.SelectChuaCoDeTai(idhocky, idmonhoc, idBoMon);
        }
        public async Task<ActionResultResponese<string>> InsertAsync(SinhVienMeta sinhvienMeta, string idhocky, string creatorUserId, string creatorFullName, string idBoMon)
        {
            var checkHocKy = await _HocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new ActionResultResponese<string>(-6, "Học kỳ không tồn tại.", "Học kỳ.");
            var checkMaSinhvien = await _sinhVienRepository.CheckExits(idhocky, sinhvienMeta.MaSinhVien);
            if (checkMaSinhvien)
                return new ActionResultResponese<string>(-3, "Sinh viên đã có trong học kỳ.", "Sinh viên.");
            var id = Guid.NewGuid().ToString();
            var checkIdSinhvien = await _sinhVienRepository.CheckExitsIdSinhVien(id);
            if (checkIdSinhvien)
                return new ActionResultResponese<string>(-4, "Sinh viên đã tồn tại.", "Sinh viên.");

            var sinhvien = new SinhVien()
            {
                IdSinhVien = id?.Trim(),
                IdBoMon = idBoMon?.Trim(),
                MaSinhVien = sinhvienMeta.MaSinhVien?.Trim(),
                TenSinhVien = sinhvienMeta.TenSinhVien?.Trim(),
                Email = sinhvienMeta.Email?.Trim(),
                DienThoai = sinhvienMeta.DienThoai?.Trim(),
                DonViThucTap = sinhvienMeta.DonViThucTap?.Trim(),
                MaLopHoc = sinhvienMeta.MaLopHoc?.Trim(),
                LopHoc = sinhvienMeta.LopHoc?.Trim(),
                IdHocKy = idhocky?.Trim(),
                MaChuyenNganh = sinhvienMeta.MaChuyenNganh?.Trim(),
                TenChuyenNganh = sinhvienMeta.TenChuyenNganh?.Trim(),
                CreateTime = DateTime.Now,
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                IsActive = true,
                IsDelete = false
            };
            if (sinhvien == null)
                return new ActionResultResponese<string>(-5, "Thông tin lỗi.", "Sinh viên.");
            var result = await _sinhVienRepository.InsertAsync(sinhvien);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới thất bại.", "Sinh viên.");
            return new ActionResultResponese<string>(result, "Thêm mới thành công.", "Sinh viên.");
        }


        public async Task<ActionResultResponese<string>> InsertListAsync(List<SinhVienMeta> sinhvienMeta, string idhocky, string creatorUserId, string creatorFullName, string idBoMon)
        {
            var checkHocKy = await _HocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new ActionResultResponese<string>(-6, "Học kỳ không tồn tại.", "Học kỳ.");
            List<SinhVienMeta> sinhvienlist = new List<SinhVienMeta>();
            sinhvienlist = sinhvienMeta.GroupBy(p => p.MaSinhVien).Select(g => g.First()).ToList();
            if (sinhvienMeta.Count() != sinhvienlist.Count())
                return new ActionResultResponese<string>(-7, "Trùng lặp sinh viên kiểm tra lại và gửi.", "Sinh viên.");
            var listSinhVien = new List<SinhVien>();
            foreach (var sinhvienInsert in sinhvienlist)
            {

                var checkMaSinhvien = await _sinhVienRepository.CheckExits(idhocky, sinhvienInsert.MaSinhVien);
                if (checkMaSinhvien)
                    return new ActionResultResponese<string>(-8, "Sinh viên đã có trong học kỳ.", "Sinh viên.");
                var id = Guid.NewGuid().ToString();
                var checkIdSinhvien = await _sinhVienRepository.CheckExitsIdSinhVien(id);
                if (checkIdSinhvien)
                    return new ActionResultResponese<string>(-9, "Sinh viên đã tồn tại.", "Sinh viên.");

                listSinhVien.Add(new SinhVien()
                {
                    IdSinhVien = id?.Trim(),
                    IdBoMon = idBoMon?.Trim(),
                    MaSinhVien = sinhvienInsert.MaSinhVien?.Trim(),
                    TenSinhVien = sinhvienInsert.TenSinhVien?.Trim(),
                    Email = sinhvienInsert.Email?.Trim(),
                    DienThoai = sinhvienInsert.DienThoai?.Trim(),
                    DonViThucTap = sinhvienInsert.DonViThucTap?.Trim(),
                    MaLopHoc = sinhvienInsert.MaLopHoc?.Trim(),
                    LopHoc = sinhvienInsert.LopHoc?.Trim(),
                    IdHocKy = idhocky?.Trim(),
                    MaChuyenNganh = sinhvienInsert.MaChuyenNganh?.Trim(),
                    TenChuyenNganh = sinhvienInsert.TenChuyenNganh?.Trim(),
                    CreateTime = DateTime.Now,
                    CreatorUserId = creatorUserId?.Trim(),
                    CreatorFullName = creatorFullName?.Trim(),
                    IsActive = true,
                    IsDelete = false
                });
            }

            if (listSinhVien.Count() == 0)
                return new ActionResultResponese<string>(-10, "Thông tin lỗi kiểm tra lại và gửi.", "Danh sách sinh viên.");
            foreach (var sinhvienItemInsert in listSinhVien)
            {
                await _sinhVienRepository.InsertAsync(sinhvienItemInsert);
            }
            return new ActionResultResponese<string>(1, "Thêm mới thành công.", "Sinh viên.");
        }
        public async Task<SearchResult<SinhVienSearchViewModel>> SelectAllAsync(string idhocky, string idbomon)
        {
            return await _sinhVienRepository.SelectAllByHocKyAsync(idhocky, idbomon);
        }

        public async Task<ActionResultResponese<string>> UpdateAsync(string lastUpdateUserId, string lastUpdateFullName, string idbomon, string idSinhVien, SinhVienMeta sinhVienMeta)
        {
            var info = await _sinhVienRepository.GetInfo(idSinhVien);
            if (info == null)
                return new ActionResultResponese<string>(-1, "Sinh viên không tồn tại", "Sinh viên");
            info.IdBoMon = idbomon?.Trim();
            info.DonViThucTap = sinhVienMeta.DonViThucTap?.Trim();
            info.LastUpdate = DateTime.Now;
            info.LastUpdateUserId = lastUpdateUserId;
            info.LastUpdateFullName = lastUpdateFullName;

            var result = await _sinhVienRepository.UpdateAsync(info);

            if (result <= 0)
                return new ActionResultResponese<string>(result, "Cập nhật thất bại", "sinh viên");

            return new ActionResultResponese<string>(result, "Cập nhật thành công", "sinh viên");
        }

        public async Task<ActionResultResponese<string>> UpdateDonViThucTap(List<UpDateDonViTTMeta> donViThucTapMeta, string LastUpdateUserId, string LastUpDateFullName)
        {
            int dem = 0;
            foreach (var item in donViThucTapMeta)
            {
                var infoSinhVien = await _sinhVienRepository.GetInfo(item.IdSinnhVien?.Trim());
                if (infoSinhVien == null)
                    return new ActionResultResponese<string>(-3, "Thông tin sinh viên không tồn tại", "sinh viên");

                infoSinhVien.DonViThucTap = item.DonViThucTap?.Trim();

                var result = await _sinhVienRepository.UpdateAsync(infoSinhVien);
                if (result >= 0)
                    dem++;
            }
            if (dem <= 0)
                return new ActionResultResponese<string>(-4, "Cập nhật đơn vị thực tập không thành công", "sinh viên");
            return new ActionResultResponese<string>(1, "cập nhâp thành công đơn vị thực tập " + dem + " sinh viên", "sinh viên");
        }


        public async Task<ActionResultResponese<string>> InsertFromExcelAsync(string idfile, string idhocky, string creatorUserId, string creatorFullName, string idBoMon)
        {
            var infofile = await _fileRepository.GetInfo(idfile);
            if (infofile == null)
                return new ActionResultResponese<string>(-6, "File điểm không tồn tại.", "File điểm.");


            List<SinhVien> _listSinhVien = new List<SinhVien>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
            {
                ExcelWorksheet worsheet = pakage.Workbook.Worksheets["SinhVien"];
                if (worsheet == null)
                    return new ActionResultResponese<string>(-9, "File sinh viên không đúng định dạng", "File danh sách sinh viên");
                for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
                {
                    if (worsheet.Cells[i, 1].Value != null && worsheet.Cells[i, 2].Value != null && worsheet.Cells[i, 5].Value != null
                        && worsheet.Cells[i, 6].Value != null && worsheet.Cells[i, 8].Value != null && worsheet.Cells[i, 10].Value != null)
                    {
                        //int j = 1;
                        string idbomon = worsheet.Cells[i, 1].Value.ToString();
                        string maSinhVien = worsheet.Cells[i, 2].Value.ToString();
                        string tenSinhVien = worsheet.Cells[i, 3].Value == null ? "" : worsheet.Cells[i, 3].Value.ToString();
                        string email = worsheet.Cells[i, 4].Value == null ? "" : worsheet.Cells[i, 4].Value.ToString();
                        string dienThoai = worsheet.Cells[i, 5].Value.ToString();
                        string donViThucTap = worsheet.Cells[i, 6].Value.ToString();
                        string malophoc = worsheet.Cells[i, 7].Value == null ? "" : worsheet.Cells[i, 7].Value.ToString();
                        string lopHoc = worsheet.Cells[i, 8].Value.ToString();
                        string maChuyenNganh = worsheet.Cells[i, 9].Value == null ? "" : worsheet.Cells[i, 9].Value.ToString();
                        string tenChuyenNganh = worsheet.Cells[i, 10].Value?.ToString();
                        string TenSinhVien = worsheet.Cells[i, 11].Value == null ? "" : worsheet.Cells[i, 11].Value.ToString();
                        SinhVien _sinhVien = new SinhVien()
                        {
                            IdSinhVien = Guid.NewGuid().ToString(),
                            IdBoMon = idbomon?.Trim(),
                            MaSinhVien = maSinhVien?.Trim(),
                            TenSinhVien = tenSinhVien?.Trim(),
                            Email = email?.Trim(),
                            DienThoai = dienThoai?.Trim(),
                            DonViThucTap = donViThucTap?.Trim(),
                            MaLopHoc = malophoc?.Trim(),
                            LopHoc = lopHoc?.Trim(),
                            IdHocKy = idhocky?.Trim(),
                            MaChuyenNganh = maChuyenNganh?.Trim(),
                            TenChuyenNganh = tenChuyenNganh?.Trim(),
                        };
                        _listSinhVien.Add(_sinhVien);
                    }
                    else break;
                }


                var checkHocKy = await _HocKysRepository.CheckExisIsActivetAsync(idhocky);
                if (!checkHocKy)
                    return new ActionResultResponese<string>(-6, "Học kỳ không tồn tại.", "Học kỳ.");
                List<SinhVien> sinhvienlist = new List<SinhVien>();
                sinhvienlist = _listSinhVien.GroupBy(p => p.MaSinhVien).Select(g => g.First()).ToList();
                if (sinhvienlist.Count() != _listSinhVien.Count())
                    return new ActionResultResponese<string>(-7, "Trùng lặp sinh viên kiểm tra lại và gửi.", "Sinh viên.");
                var listSinhVien = new List<SinhVien>();
                foreach (var sinhvienInsert in sinhvienlist)
                {

                    var checkMaSinhvien = await _sinhVienRepository.CheckExits(idhocky, sinhvienInsert.MaSinhVien);
                    if (checkMaSinhvien)
                        return new ActionResultResponese<string>(-8, "Sinh viên đã có trong học kỳ.", "Sinh viên.");
                    var id = Guid.NewGuid().ToString();
                    var checkIdSinhvien = await _sinhVienRepository.CheckExitsIdSinhVien(id);
                    if (checkIdSinhvien)
                        return new ActionResultResponese<string>(-9, "Sinh viên đã tồn tại.", "Sinh viên.");

                    listSinhVien.Add(new SinhVien()
                    {
                        IdSinhVien = sinhvienInsert.IdSinhVien?.Trim(),
                        IdBoMon = idBoMon?.Trim(),
                        MaSinhVien = sinhvienInsert.MaSinhVien?.Trim(),
                        TenSinhVien = sinhvienInsert.TenSinhVien?.Trim(),
                        Email = sinhvienInsert.Email?.Trim(),
                        DienThoai = sinhvienInsert.DienThoai?.Trim(),
                        DonViThucTap = sinhvienInsert.DonViThucTap?.Trim(),
                        MaLopHoc = sinhvienInsert.MaLopHoc?.Trim(),
                        LopHoc = sinhvienInsert.LopHoc?.Trim(),
                        IdHocKy = idhocky?.Trim(),
                        MaChuyenNganh = sinhvienInsert.MaChuyenNganh?.Trim(),
                        TenChuyenNganh = sinhvienInsert.TenChuyenNganh?.Trim(),
                        CreateTime = DateTime.Now,
                        CreatorUserId = creatorUserId?.Trim(),
                        CreatorFullName = creatorFullName?.Trim(),
                        IsActive = true,
                        IsDelete = false
                    });
                }

                if (listSinhVien.Count() == 0)
                    return new ActionResultResponese<string>(-10, "Thông tin lỗi kiểm tra lại và gửi.", "Danh sách sinh viên.");
                foreach (var sinhvienItemInsert in listSinhVien)
                {
                    await _sinhVienRepository.InsertAsync(sinhvienItemInsert);
                }
                return new ActionResultResponese<string>(1, "Thêm mới thành công.", "Sinh viên.");
            }
        }
    }
}
