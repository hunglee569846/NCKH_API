using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IHoiDongTotNghiepRepository
    {
        Task<SearchResult<HoiDongTotNghiepViewModel>> SelectAll(string idhocky,string idbomon);
        Task<SearchResult<HoiDongTotNghiepViewModel>> GetByMonHoc(string idhocky,string idMonHoc,string idbomon);
        Task<int> InsertAsync(HoiDongTotNghiep hoidong);
        Task<int> UpdateAsync(HoiDongTotNghiep hoidong);
        Task<int> DeleteAsync(string idhoidong);
        Task<bool> CheckExit(string idhoidong, string idhocky);
        Task<bool> CheckExitMaHD(string maHoiDong, string idhocky);
        Task<bool> CheckExitIsActive(string idhoidong);
        Task<HoiDongTotNghiep> GetInfo(string idhoidongtotnghiep);
        Task<string> GetCodeHoiDong(string maBoMon);

        ///Search Hoi Dong ngay bao ve tu ngay - den ngay

        Task<SearchResult<HoiDongSearchViewModel>> SearchHoiDongNgayBaoVe(string idBoMon, DateTime? ngayBatDau, DateTime? ngayKetThuc);

    }
}
