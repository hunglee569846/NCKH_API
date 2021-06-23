using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System.Threading.Tasks;
using WebSite.Core.Domain.Constansts;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IMonHocService
    {
        Task<SearchResult<MonHocSearchViewModel>> GetAllAsyncByIdHocKy(string idhocky,string idbomon);
        Task<ActionResultResponese<string>> InsertAsync(MonHocMeta monHocMeta, string idhocky, TypeDataApprover typeApprover, string creatorUserId, string creatorFullName,string mamonhoc,string tenmonhoc, string idbomon);
        Task<ActionResultResponese<string>> UpdateAsync(MonHocMeta monhocmeta, string idmonhoc, string idhocky, TypeDataApprover typeApprover, string lastUpdateUserId, string lastUpdateFullName, string mamonhoc, string tenmonhoc,string idbomon);
        Task<ActionResultResponese<string>> DeleteAsync(string deleteUserId, string deleteFullName, string idMonHoc);
    }
}
