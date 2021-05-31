using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Domain.IRepository
{
    public interface IChiTietHoiDongRepository
    {
        //Task<SearchResult<ChiTietDeTaiViewModel>> SearchById(string iddetai);
        Task<int> InserAsync(ChiTietHoiDong chitiethoidong);
        Task<int> DeleteByIdHoiDongAsync(string idhoidong);
        Task<int> DeleteByIdAsync(string idchitietHD);
        Task<bool> CheckExits(string idchitiethoidong);
        //Task<bool> CheckExitsDuplicate(string iddetai, string idGVHD);
        ////đề tài và chi tiết đề tài
        
    }
}
