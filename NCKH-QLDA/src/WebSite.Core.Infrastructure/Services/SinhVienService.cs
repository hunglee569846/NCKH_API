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
    public class SinhVienService : ISinhVienService
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly IHocKysRepository _HocKysRepository;
        public SinhVienService(ISinhVienRepository sinhVienRepository,
                              IHocKysRepository hocyysRepository)
        {

            _sinhVienRepository = sinhVienRepository;
            _HocKysRepository = hocyysRepository;
        }

        public async Task<SearchResult<SinhVienSearchViewModel>> GetByIdAsync(string idsinhvien)
        {
            return await _sinhVienRepository.SearchById(idsinhvien);
        }
        public async Task<ActionResultResponese<string>> InsertAsync(SinhVienMeta sinhvienMeta,string idhocky,string creatorUserId,string creatorFullName, string idBoMon)
        {
            var checkHocKy = await _HocKysRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new ActionResultResponese<string>(-6, "Học kỳ không tồn tại.", "Học kỳ.");
            var checkMaSinhvien = await _sinhVienRepository.CheckExits(idhocky,sinhvienMeta.MaSinhVien);
            if (checkMaSinhvien)
                return new ActionResultResponese<string>(-3,"Sinh viên đã có trong học kỳ.","Sinh viên.");
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
                CreateTime = DateTime.Now,
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                IsActive = true,
                IsDelete = false
            };
            if (sinhvien == null)
                return new ActionResultResponese<string>(-5, "Thông tin lỗi.", "Sinh viên.");
            var result = await _sinhVienRepository.InsertAsync(sinhvien);
            if(result<=0)
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
        public async Task<SearchResult<SinhVienSearchViewModel>> SelectAllAsync(string idhocky,string idbomon)
        {
            return await _sinhVienRepository.SelectAllByHocKyAsync(idhocky,idbomon);
        }
    }
}
