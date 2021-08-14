using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IBangDiemService
    {
        Task<ActionResultResponese<string>> InsertAsync(string iddetai, string idGVHD, string idhoidong, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> InsertListDetaiAsync(List<BangDiemlistMeta> listdetai,string idhoidong, string idhocky, string idmonhoc,string creatorUserId, string creatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> UpdateDiemAsync(string idBangDiem, float diemmso, string nhanxetGV,string creatorUserId, string creatorFullName, string idBoMon);
        //Xuat diem phan bien
        Task<SearchResult<XuatDiemPhanBienViewModel>> XuatDiemPhanBien(string idhocky, string idmonhoc,string idBoMon);

        //Xuat diem phan bien dowload Excel
        Task<Stream> XuatBangDiemExcel(string idhocky, string idmonhoc,string idBoMon);
        //Xuat diem Hoi Dong dowload Excel
        Task<Stream> XuatHoiDongExcel(string idhocky, string idmonhoc, string idBoMonc);
        //Xuat diem hoi dong
        Task<SearchResult<XuatDiemHoiDongViewModel>> XuatDiemHoiDong(string idhocky, string idmonhoc, string idBoMon);

        // xuất dữ liệu sinh viên khởi tạo đề tài
        Task<Stream> XuatSinhVienExcel(string idhocky, string idBoMon);


    }
}
