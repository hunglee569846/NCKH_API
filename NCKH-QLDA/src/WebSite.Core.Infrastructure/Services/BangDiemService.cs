using Microsoft.AspNetCore.Hosting;
using NCKH.Infrastruture.Binding.Extensions;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
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
    public class BangDiemService : IBangDiemService
    {
        private readonly IBangDiemRepository _bangdiemRepository;
        private readonly IHocKysRepository _hockyRepository;
        private readonly IGiangVienHuongDanRepository _GiangVienHuongDanRepository;
        private readonly IMonHocRepository _monhocRepository;
        private readonly IDeTaiRepository _detaiRepository;
        private readonly IHoiDongTotNghiepRepository _hoidongtotnghiepRepository;
        private readonly IChiTietHoiDongRepository _chitiethoidongRepository;
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BangDiemService(IBangDiemRepository bangdiemRepository,
                               IHocKysRepository hockyRepository,
                               IGiangVienHuongDanRepository GiangVienHuongDanRepository,
                               IMonHocRepository monhocRepository,
                               IDeTaiRepository detaiRepository,
                               IHoiDongTotNghiepRepository hoidongtotnghiepRepository,
                               IChiTietHoiDongRepository chitiethoidongRepository,
                               ISinhVienRepository sinhVienRepository,
                               IWebHostEnvironment webHostEnvironment)
        {
            _bangdiemRepository = bangdiemRepository;
            _hockyRepository = hockyRepository;
            _GiangVienHuongDanRepository = GiangVienHuongDanRepository;
            _monhocRepository = monhocRepository;
            _detaiRepository = detaiRepository;
            _hoidongtotnghiepRepository = hoidongtotnghiepRepository;
            _chitiethoidongRepository = chitiethoidongRepository;
            _sinhVienRepository = sinhVienRepository;
            _webHostEnvironment = webHostEnvironment;
        }

       public async  Task<ActionResultResponese<string>> InsertAsync (string iddetai,string idGVHD,string idhoidong,string idhocky,string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon)
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

            var detaiInfo = await _detaiRepository.GetInfo(iddetai);
            
            var checkHoiDong = await _hoidongtotnghiepRepository.CheckExitIsActive(idhoidong);
            if (!checkHoiDong)
                return new ActionResultResponese<string>(-6, "Hội đồng không tồn tại", "Hội đồng");

            var checkGiangVien = await _GiangVienHuongDanRepository.CheckExits(idGVHD);
            if (!checkGiangVien)
                return new ActionResultResponese<string>(-7, "Giảng viên không tồn tại", "Giảng viên");
            var id = Guid.NewGuid().ToString();

            var bangdiem = new BangDiem()
            {
                IdBangDiem = id?.Trim(),
                IdBoMon = idBoMon?.Trim(),
                IdDeTai = iddetai?.Trim(),
                IdHocKy = idhocky?.Trim(),
                IdMonHoc = idmonhoc?.Trim(),
                IdHoiDong = idhoidong?.Trim(),
                IdGiangVien = idGVHD?.Trim(),
                DiemSo = 0,
                IdSinhVien = detaiInfo.IdSinhVien?.Trim(),
                CreatorUserId = creatorUserId?.Trim(),
                CreatorFullName = creatorFullName?.Trim(),
                CreateTime = DateTime.Now,
                IsActive = true,
                IsDelete = false,
            };
            if (bangdiem == null)
                return new ActionResultResponese<string>(-6, "Thông tin nhập không hợp lệ.", "Bảng điểm");
            var result = await _bangdiemRepository.InsertAsync(bangdiem);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Thêm mới bảng điểm không thành công", "Bảng điểm");
            return new ActionResultResponese<string>(result, "Thêm mới bảng điểm thành công.", "Bảng điểm");

        }
        /// <summary>
        /// Insert vào bảng điểm với idMonHoc là đồ án
        /// kiểm tra môn học với type Aprover ==1 và ==2
        /// =1 ko insert id gv
        /// =2 insert  cả thành viên hd vào bảng điểm
        /// </summary>
        /// <param name="listDetaiMeta"></param>
        /// <param name="idhoidong"> hội đồng thuộc môn đồ án</param>
        /// <param name="idhocky"></param>
        /// <param name="idmonhoc"></param>
        /// <param name="creatorUserId"></param>
        /// <param name="creatorFullName"></param>
        /// <param name="idBoMon"></param>
        /// <returns></returns>
        public async Task<ActionResultResponese<string>> InsertListDetaiAsync(List<BangDiemlistMeta> listDetaiMeta,string idhoidong, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon)
        {

            var listdetai = listDetaiMeta.GroupBy(p => p.IdDeTai).Select(g => g.First()).ToList();
            if (listDetaiMeta.Count() != listdetai.Count())
                return new ActionResultResponese<string>(-12, "Trùng lặp đề tài.", "Danh sách đề tài.");

            var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new ActionResultResponese<string>(-7, "Học kỳ không tồn tại", "Học kỳ");

            var checkMonHoc = await _monhocRepository.CheckMonHocInHocKyExits(idmonhoc, idhocky);
            if (!checkMonHoc)
                return new ActionResultResponese<string>(-8, "Môn học không có trong học kỳ.", "Môn học");

            var infoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if (infoMonHoc == null)
                return new ActionResultResponese<string>(-15, "Môn học không có trong học kỳ.", "Môn học");

            var listbangdiem = new List<BangDiem>();
            var infoHoiDong = await _hoidongtotnghiepRepository.GetInfo(idhoidong);
            if (infoHoiDong == null)
                return new ActionResultResponese<string>(-10, "Hội đồng không tồn tại", "Hội đồng");
            if (infoHoiDong.IdMonHoc?.Trim() != idmonhoc?.Trim())
                return new ActionResultResponese<string>(-11, "Hội đồng không thuộc môn học này", "Hội đồng");

            if (infoMonHoc.TypeApprover.GetHashCode() == 2)
            {
                
                var listTVHD = await _chitiethoidongRepository.GetListThanhVien(idhoidong);
                if (listTVHD == null || listTVHD.Count() == 0)
                    return new ActionResultResponese<string>(-14, "Hội đồng chưa khởi tạo hoặc chưa có thành viên.", "Hội đồng");

               
                foreach (var itemdetai in listdetai)
                {
                    //var checkGiangVien = await _GiangVienHuongDanRepository.CheckExits(infoHoiDong.idgv);
                    //if (!checkGiangVien)
                    //    return new ActionResultResponese<string>(-12, "Giảng viên không tồn tại", "Giảng viên");

                    var getInfo = await _detaiRepository.GetInfo(itemdetai.IdDeTai);
                    if (getInfo == null)
                        return new ActionResultResponese<string>(-9, "Đề tài không tồn tại.", "Đề tài");
                    if (getInfo.IdMonHoc != idmonhoc )
                        return new ActionResultResponese<string>(-17, "Đề tài không thuộc môn học này.", "Đề tài");

                    var checkExits = await _bangdiemRepository.CheckExit(itemdetai.IdDeTai);
                    if(checkExits)
                        return new ActionResultResponese<string>(-21, "Đề tài đã được phân công hội đồng.", "Danh sach đề tài.");

                    foreach (var itemgiangvien in listTVHD)
                    {
                        var id = Guid.NewGuid().ToString();
                        var checkGV = await _GiangVienHuongDanRepository.CheckExits(itemgiangvien.IdGVHDTheoKy);
                        if (!checkGV)
                            return new ActionResultResponese<string>(-19, "Giảng viên không có trong học kỳ.", "Giảng viên.");
                        listbangdiem.Add(new BangDiem()
                        {
                             IdBangDiem = id?.Trim(),
                             IdBoMon = idBoMon?.Trim(),
                             IdDeTai = itemdetai.IdDeTai?.Trim(),
                             IdHocKy = idhocky?.Trim(),
                             IdMonHoc = idmonhoc?.Trim(),
                             IdGiangVien = itemgiangvien.IdGiangVien?.Trim(),
                             IdHoiDong = idhoidong?.Trim(),
                             IdSinhVien = getInfo.IdSinhVien?.Trim(),
                             CreateTime = DateTime.Now,
                             CreatorUserId = creatorUserId?.Trim(),
                             CreatorFullName = creatorFullName?.Trim(),
                             IsActive = true,
                             IsDelete = false,
                             DiemSo = 0,
                        });
                    }
                    
                }
                if(listbangdiem.Count == 0)
                   return new ActionResultResponese<string>(-18, "Thông tin lỗi vui lòng liên hệ quản trị viên.", "Danh sách đề tài.");

                foreach (var itemBangDiem in listbangdiem)
                {
                    await _bangdiemRepository.InsertAsync(itemBangDiem);
                }
                return new ActionResultResponese<string>(1, "Thêm mới bảng điểm thành công.", "Bảng điểm");
            }
            else if (infoMonHoc.TypeApprover.GetHashCode() == 1)
            {
                foreach (var itemdetai in listdetai)
                {
                    //var checkGiangVien = await _GiangVienHuongDanRepository.CheckExits(infoHoiDong.idgv);
                    //if (!checkGiangVien)
                    //    return new ActionResultResponese<string>(-12, "Giảng viên không tồn tại", "Giảng viên");

                    var infoDeTai = await _detaiRepository.GetInfo(itemdetai.IdDeTai);
                    if (infoDeTai == null)
                        return new ActionResultResponese<string>(-9, "Đề tài không tồn tại.", "Đề tài");
                    if (infoDeTai.IdMonHoc != idmonhoc)
                        return new ActionResultResponese<string>(-17, "Đề tài không thuộc môn học này.", "Đề tài");

                    var checkExits = await _bangdiemRepository.CheckExit(itemdetai.IdDeTai);
                    if (checkExits)
                        return new ActionResultResponese<string>(-21, "Đề tài đã được phân công hội đồng.", "Danh sach đề tài.");

                    var id = Guid.NewGuid().ToString();
                  
                    listbangdiem.Add(new BangDiem()
                    {
                        IdBangDiem = id?.Trim(),
                        IdBoMon = idBoMon?.Trim(),
                        IdDeTai = itemdetai.IdDeTai?.Trim(),
                        IdHocKy = idhocky?.Trim(),
                        IdMonHoc = idmonhoc?.Trim(),
                        // IdGiangVien = itemgiangvien.IdGiangVien?.Trim(),
                        IdHoiDong = idhoidong?.Trim(),
                        IdSinhVien = infoDeTai.IdSinhVien?.Trim(),
                        CreateTime = DateTime.Now,
                        CreatorUserId = creatorUserId?.Trim(),
                        CreatorFullName = creatorFullName?.Trim(),
                        IsActive = true,
                        IsDelete = false,
                        DiemSo = 0,
                    });

                }

                if (listbangdiem.Count == 0)
                    return new ActionResultResponese<string>(-18, "Thông tin lỗi vui lòng liên hệ quản trị viên.", "Danh sách đề tài.");

                foreach (var itemBangDiem in listbangdiem)
                {
                    await _bangdiemRepository.InsertAsync(itemBangDiem);
                }
                return new ActionResultResponese<string>(1, "Thêm mới bảng điểm thành công.", "Bảng điểm");
            }
            else
                return new ActionResultResponese<string>(-16, "Môn học không được phân hội đồng đánh giá.", "Môn học.");
               
        }
        public async Task<ActionResultResponese<string>> UpdateDiemAsync(string idBangDiem, float diemmso, string nhanxetGV, string creatorUserId, string creatorFullName, string idBoMon)
        {
            var checkBanDiem = await _bangdiemRepository.CheckExitIdBangDiem(idBangDiem);
            if(!checkBanDiem)
                return new ActionResultResponese<string>(-31, "Điểm thành phần không tồn tại.", "Bảng điểm.");
            if (10 < diemmso || diemmso < 0)
                return new ActionResultResponese<string>(-32, "Nhập sai!", "Điểm phản biện.");
            var bangdiem = new BangDiem()
            {
                IdBangDiem = idBangDiem?.Trim(),
                IdBoMon = idBoMon?.Trim(),
                DiemSo = diemmso,
                NhanXetGV = nhanxetGV?.Trim(),
                NgayVaoDiem = DateTime.Now,
                CreatorPointUserId = creatorUserId?.Trim(),
                CreatorPointFullName = creatorFullName?.Trim()
                
            };
            if (bangdiem == null)
                return new ActionResultResponese<string>(-34, "Thông tin nhập không hợp lệ.", "Bảng điểm");
            var result = await _bangdiemRepository.UpdateDiemAsync(bangdiem);
            if (result <= 0)
                return new ActionResultResponese<string>(result, "Nhập điểm không thành công", "Bảng điểm");
            return new ActionResultResponese<string>(result, "Nhập điểm thành công.", "Bảng điểm");
        }

        // Xuat diem phan bien
        public async Task<SearchResult<XuatDiemPhanBienViewModel>> XuatDiemPhanBien(string idhocky, string idmonhoc, string idBoMon)
        {
            var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new SearchResult<XuatDiemPhanBienViewModel> { Code = -43, Data = null, Message ="Học kỳ không tồn tại."};

            var checkMonHoc = await _monhocRepository.CheckMonHocInHocKyExits(idmonhoc, idhocky);
            if (!checkMonHoc)
                return new SearchResult<XuatDiemPhanBienViewModel> { Code = -44, Data = null, Message = "Môn học không tồn tại." };
            var getInfoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if(getInfoMonHoc.TypeApprover.GetHashCode() == 0)
                return new SearchResult<XuatDiemPhanBienViewModel> { Code = -45, Data = null, Message = "Môn học không có đánh giá phản biện." };
            return await _bangdiemRepository.XuatDiemPhanBien(idhocky, idmonhoc, idBoMon);
        }

        // Xuat diem phan bien dowload Excel
        public async Task<Stream> XuatBangDiemExcel(string idhocky, string idmonhoc, string idBoMon)
        {
            
            //if (getInfoMonHoc.TypeApprover.GetHashCode() == 0)
            //    return new ActionResultResponese<string>(-46, "Nhập điểm không thành công", "Bảng điểm");

            List<XuatDiemPhanBienViewModel> diemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc,idBoMon);

            var createEx = new CreateExcelExtensions();
            var stream = createEx.CreateExcel(diemphanbien,"DiemPhanBien");
            // return new ActionResultResponese<string>(1, "Nhập điểm không thành công", "Bảng điểm", stream.ToString());
            return stream;
        }
        // Xuat diem phan bien dowload Excel
        public async Task<Stream> XuatHoiDongExcel(string idhocky, string idmonhoc, string idBoMon)
        {
            var InfoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if (InfoMonHoc.TypeApprover.GetHashCode() == 1)
            {
                List<XuatDiemHoiDongViewModel> diemHoiDongTTTN = await _bangdiemRepository.XuatDiemHoiDongTTTNExcel(idhocky, idmonhoc, idBoMon);
                var createEx = new CreateExcelExtensions();
                var stream = createEx.CreateExcel(diemHoiDongTTTN, "DiemHoiDong");
                return stream;
            }

            if (InfoMonHoc.TypeApprover.GetHashCode() == 2)
            {
                List<XuatDiemHoiDongViewModel> diemHoiDong = await _bangdiemRepository.XuatDiemHoiDongExcel(idhocky, idmonhoc, idBoMon);
                var createEx = new CreateExcelExtensions();
                var stream = createEx.CreateExcel(diemHoiDong, "DiemHoiDong");
                return stream;
            }
            // return new ActionResultResponese<string>(1, "Nhập điểm không thành công", "Bảng điểm", stream.ToString());
            return null;
        }
        //Xuat diem hoi dong
        public async Task<SearchResult<XuatDiemHoiDongViewModel>> XuatDiemHoiDong(string idhocky, string idmonhoc, string idBoMon)
        {
            var checkHocKy = await _hockyRepository.CheckExisIsActivetAsync(idhocky);
            if (!checkHocKy)
                return new SearchResult<XuatDiemHoiDongViewModel> { Code = -53, Data = null, Message = "Học kỳ không tồn tại." };

            var checkMonHoc = await _monhocRepository.CheckMonHocInHocKyExits(idmonhoc, idhocky);
            if (!checkMonHoc)
                return new SearchResult<XuatDiemHoiDongViewModel> { Code = -54, Data = null, Message = "Môn học không tồn tại." };
            var getInfoMonHoc = await _monhocRepository.GetInfoAsync(idmonhoc);
            if (getInfoMonHoc.TypeApprover.GetHashCode() == 2)
                return new SearchResult<XuatDiemHoiDongViewModel> { Code = -55, Data = null, Message = "Môn học không có đánh giá phản biện." };
            return await _bangdiemRepository.XuatDiemHoiDong(idhocky, idmonhoc, idBoMon);
        }

        public async Task<Stream> XuatSinhVienExcel(string idhocky, string idBoMon)
        {
            List<DataSinhVienVewModel> dataSinhVien = await _sinhVienRepository.DataSinhVienByMonHoc(idhocky, idBoMon);

            var createEx = new CreateExcelExtensions();
            var stream = createEx.CreateExcel(dataSinhVien, "DeTaiSinhVien");
            return stream;
        }
    }
}
