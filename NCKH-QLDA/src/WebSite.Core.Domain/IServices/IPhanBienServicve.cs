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
    public interface IPhanBienServicve
    {
        Task<SearchResult<PhanBienSearchViewModel>> GetAllByIdHK(string idhocky);
        Task<ActionResultResponese<string>> InsertByHk(PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky);
        Task<ActionResultResponese<string>> Update(PhanBienUpdateMeta phanbienUpdateMeta, string idGVPB, string iddetai, string idhocky,string idPhanBien);
        Task<ActionResultResponese<string>> UpdateDiemAsync(string idphanbien,string idhocky, float Diem, NoteMeta note);
        Task<ActionResultResponese<string>> DeleteAsync(string idphanbien,string idhocky);
    }
}
