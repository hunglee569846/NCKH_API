using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IGiangVienHuongDanRepository
    {
        Task<List<GiangVienHuongDanViewModel>> SelectAllAsync();
        Task<SearchResult<GiangVienHuongDanViewModel>> SelectByIdHocKyAsync(string idhocky);
        Task<GVHDTheoKy> GetInfo(string idGVHD);
        Task<int> InsertAsync(GVHDTheoKy gvhdky);
        Task<int> UpdatetAsync(GVHDTheoKy gvhdky);
        Task<int> DeleteByIdAsync(string idgvhdTheoky);
        Task<bool> CheckExits(string idGVHDTheoKy); //kiem tra ban ghi ton tai
        Task<bool> CheckExitsActive(string idhocky,string idGVHD,string idMonHoc); //kiem tra tồn tại của GVHD trong hoc kỳk, Môn học không có 2 GV giống nhau
        Task<bool> CheckExitsGVHD(string idGVHD); //kiem tra tồn tại của GVHD trong hoc kỳ
    }
}
