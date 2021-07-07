using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IChiTietDeTaiRepository
    {
        Task<SearchResult<ChiTietDeTaiViewModel>> SearchById(string iddetai);
        Task<int> InserAsync(ChiTietDeTai chitietdetai);
        Task<int> DeleteAsync(string idchitietdetai);
        Task<bool> CheckExits(string iddetai);
        Task<bool> CheckExitsDuplicate(string iddetai,string idGVHD);
        Task<List<ChiTietDeTaiViewModel>> GetCheckGVHDnotPB(string iddetai);
        //đề tài và chi tiết đề tài
        Task<SearchResult<DeTaivsCTDTViewModel>> SearchByIdDetai(string iddetai);
        //số lượng GV đã hd đề tài
        Task<int> CountGiangVienHD(string idDeTai);
    }
}
