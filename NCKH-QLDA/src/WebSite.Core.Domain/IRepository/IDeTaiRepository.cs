using NCKH.Infrastruture.Binding.ViewModel;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IDeTaiRepository
    {
        Task<SearchResult<DeTaiSearchViewModel>> SelectByIdHocKy(string idhocky);
        Task<SearchResult<DeTaiSearchViewModel>> SelectByIdMonHocInHocKy(string idhocky,string idmonhoc);
        Task<DeTai> GetInfo(string iddetai);
        Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky, bool isApprove);
        Task<int> InsertAsync(DeTai detai);
        Task<int> UpdateAsync(DeTai detai);
        Task<int> UpdateApproveAsync(string iddetai,bool isApprove);
        Task<int> DeleteAsync(string iddetai);
        Task<bool> CheckIsDat(string idmonhoc,string maSinhVien); //kiem tra ban ghi ton tai
        Task<bool> CheckExits(string iddetai); //kiem tra ban ghi ton tai
        Task<bool> CheckApprove(string iddetai); //kiem tra de tai duoc duyet
        Task<bool> CheckMaDeTai(string madetai); //kiem tra ton tai ma de tai
        Task<bool> CheckExitsActive(string idhocky, string idmonhoc); //kiem tra tồn tại của mon hoc trong hoc kỳ
        Task<bool> CheckExitsKyHoc(string idhocky); //kiem tra tồn tại của mon hoc trong hoc kỳ
    }
}
