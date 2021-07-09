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
    public interface IHoiDongTotNghiepService
    {
        Task<SearchResult<HoiDongTotNghiepViewModel>> GetByIdHocKy(string idhocky,string idbomon); 
        Task<SearchResult<HoiDongTotNghiepViewModel>> GetByIdMonHoc(string idhocky,string idmonhoc,string idbomon); 
        Task<ActionResultResponese<string>> InsertAsync(HoiDongTotNghiepMeta hoidongMeta, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName,string idBoMon); 
        Task<ActionResultResponese<string>> UpdateAsync(HoiDongTotNghiepMeta hoidongMeta, string idhoidong,string idhocky, string idMonHoc, string LastUpdateUserId, string LastUpdateFullName, string idBoMon); 
        Task<ActionResultResponese<string>> DeleteAsync(string idhoidong);

        //Search Hoi dong tu ngay den ngay (ngay bao ve)
        Task<SearchResult<HoiDongSearchViewModel>> SearchHoiDongNgayBaoVe(string idBoMon, DateTime? ngayBatDau, DateTime? ngayKetThuc);
       
    }
}
