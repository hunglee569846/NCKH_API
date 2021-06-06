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
        Task<ActionResultResponese<string>> InsertByHk(PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName);
        Task<ActionResultResponese<string>> InsertListPBHk(List<PhanBienlistMeta> phanbienListMeta, string iddetai, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName);
        Task<ActionResultResponese<string>> Update(PhanBienUpdateMeta phanbienUpdateMeta, string idGVPB, string iddetai, string idhocky, string idmonhoc, string idPhanBien, string lastUpdateUserId, string lastUpdateFullName);
        Task<ActionResultResponese<string>> UpdateDiemAsync(string idphanbien, string idhocKy, string idmonhoc, float Diem, NoteMeta note, string iddetai);
        Task<ActionResultResponese<string>> DeleteAsync(string idphanbien,string idhocky,string idmonhoc);
    }
}
