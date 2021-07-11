using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IDeTaiRepository
    {
        Task<SearchResult<DeTaiSearchViewModel>> SelectByIdHocKy(string idhocky);
        Task<List<DeTai>> SelectList(string idhocky,string idMonHoc, string idBoMon);
        Task<SearchResult<DeTaiSearchViewModel>> SelectByIdMonHocInHocKy(string idhocky,string idmonhoc);
        Task<SearchResult<DeTaiPhanBienViewModel>> DeTaiPhanBien(string idhocky,string idmonhoc, string IdBoMon, string IdGVHD);
        Task<SearchResult<DeTaiSearchViewModel>> SelectChuaPhanHD(string idhocky,string idmonhoc,string idBoMon);
        Task<DeTai> GetInfo(string iddetai);
        Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky, bool isApprove);
        Task<int> InsertAsync(DeTai detai);
        Task<int> UpdateAsync(DeTai detai);
        Task<int> UpdateApproveAsync(string iddetai,bool isApprove);
        Task<int> DeleteAsync(string iddetai, string deleteUserId, string deleteFullName, DateTime deteteTime);
        Task<bool> CheckIsDat(string idmonhoc,string maSinhVien); //kiem tra ban ghi ton tai
        Task<bool> CheckExits(string iddetai); //kiem tra ban ghi ton tai
        Task<bool> CheckApprove(string iddetai); //kiem tra de tai duoc duyet
        Task<bool> CheckMaDeTai(string madetai); //kiem tra ton tai ma de tai
        Task<bool> CheckExitsActive(string idhocky, string idmonhoc); //kiem tra tồn tại của mon hoc trong hoc kỳ
        Task<bool> CheckExitsKyHoc(string idhocky); //kiem tra tồn tại của mon hoc trong hoc kỳ
        Task<bool> CheckExitsSinhVien(string idhocky,string idmonhoc,string idsinhvien); //kiem tra tồn tại của sinh vien trong hoc ky mon hoc
        Task<bool> CheckDeTaiVsMonHoc(string idhocky,string idmonhoc,string idDeTai, string idBoMon); //Kiem tra đề tài trong mon hoc cung de tai khác môn học
    }
}
