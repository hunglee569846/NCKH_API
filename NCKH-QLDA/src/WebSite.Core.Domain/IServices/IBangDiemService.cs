using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IBangDiemService
    {
        Task<ActionResultResponese<string>> InsertAsync(string iddetai, string idGVHD, string idhoidong, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName);
        Task<ActionResultResponese<string>> InsertListDetaiAsync(List<BangDiemlistMeta> listdetai,string idhoidong, string idhocky, string idmonhoc,string creatorUserId, string creatorFullName);
        Task<ActionResultResponese<string>> UpdateDiemAsync(string idBangDiem, float? diemmso, string nhanxetGV,string creatorUserId, string creatorFullName);
        //Xuat diem phan bien
        Task<SearchResult<XuatDiemPhanBienViewModel>> XuatDiemPhanBien(string idhocky, string idmonhoc);
        //Xuat diem hoi dong
        Task<SearchResult<XuatDiemHoiDongViewModel>> XuatDiemHoiDong(string idhocky, string idmonhoc);
    }
}
