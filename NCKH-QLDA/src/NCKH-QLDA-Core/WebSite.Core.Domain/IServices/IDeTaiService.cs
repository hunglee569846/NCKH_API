using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IDeTaiService
    {
        //Task<List<GiangVienHuongDanViewModel>> SelectAllAsync();
        Task<SearchResult<DeTaiSearchViewModel>> GetByIdHocKyAsync(string idhocky);
        Task<SearchResult<DeTaiSearchViewModel>> GetByIdMonHocInHocKyAsync(string idhocky,string idmonhoc);
        Task<ActionResultResponese<string>> InsertAsync(DeTaiInsertMeta detaiInsertMeta, string madetai, string idhocky, string idmonhoc, string idsinhvien, string tensinhvien, string masinhvien, string maNguoiTao, string tenNguoiTao);
        Task<ActionResultResponese<string>> UpdateAsync(DeTaiUpdateMeta detaiUpdateMeta, string iddetai, string maNguoiSua, string tenNguoisua);
        // hien thi nhung de tai duoc phe duyet hoac chua phe duyet
        Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky, bool isApprove);
        Task<ActionResultResponese<string>> DeleteAsync(string iddetai);
        Task<ActionResultResponese<string>> UpdateAproveAsync(string iddetai,bool isApprove);
    }
}
