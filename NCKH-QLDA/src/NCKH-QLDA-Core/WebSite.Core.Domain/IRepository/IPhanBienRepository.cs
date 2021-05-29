using NCKH.Infrastruture.Binding.ViewModel;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IPhanBienRepository
    {
        Task<SearchResult<PhanBienSearchViewModel>> SelectAllByHk(string idhocky);
        Task<int> InsertByHk(PhanBien phanbien);
        Task<int> Update(PhanBien phanbien);
        Task<int> UpdateDiem(NoteMeta note,float diem,string idPhanBien);
        Task<bool> CheckExis(string idphanbien,string idhocky);
        Task<int> DeleteAsync(string idphanbien);
    }
}
