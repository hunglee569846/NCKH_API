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
        Task<SearchResult<DeTaiSearchViewModel>> GetChuaPhanHDAsync(string idhocky,string idmonhoc,string idBoMon);
        Task<SearchResult<DeTaiPhanBienViewModel>> DeTaiPhanPhanBien(string idhocky,string idmonhoc,string idBoMon,string idGVHD);
        Task<ActionResultResponese<string>> InsertAsync(DeTaiInsertMeta detaiInsertMeta , string idhocky, string idmonhoc, string idsinhvien, string creatorUserId, string creatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> UpdateAsync(DeTaiUpdateMeta detaiUpdateMeta, string iddetai, string creatorUserId, string creatorFullName, string idBoMon);
        //vào điên thực tập sản xuất
        Task<ActionResultResponese<string>> UpdateDiemSxAsync(string iddetai, float? diem, string LastUpdateUserId, string LastUpdateFullName, string idBoMon);
        // hien thi nhung de tai duoc phe duyet hoac chua phe duyet
        Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky, bool isApprove);
        Task<ActionResultResponese<string>> DeleteAsync(string iddetai, string deleteUserId, string deleteFullName);
        Task<ActionResultResponese<string>> UpdateAproveAsync(string iddetai,bool isApprove);

        ///them de taij ban file excel

        Task<ActionResultResponese<string>> InsertFromExcelAsync(string idfile, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName, string idBoMon);
    }
}
