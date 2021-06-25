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
    public interface ISinhVienService
    {
        Task<ActionResultResponese<string>> InsertAsync(SinhVienMeta sinhvienMeta,string idhocky, string creatorUserId, string creatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> InsertListAsync(List<SinhVienMeta> sinhvienMeta,string idhocky, string creatorUserId, string creatorFullName,string idBoMon);
        Task<SearchResult<SinhVienSearchViewModel>> SelectAllAsync(string idhocky, string idBoMon);
        Task<SearchResult<SinhVienSearchViewModel>> GetByIdAsync(string idsinhvien);
        //Task<ActionResultResponese<string>> InsertAsync(GiangVienHDMeta gvhdkyMeta, string idhocky, TypeGVHD tygvhd, string CreatorUserId, string CreatorFullName);
        //Task<ActionResultResponese<string>> InsertListGVHDAsync(List<GiangVienListMeta> gvhdlistMeta, string idhocky, string CreatorUserId, string CreatorFullName);
        //Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta, string idGVHD, string idGvhdTheoKy, TypeGVHD tygvhd, string LastUpdateUserId, string LastUpdateFullName);
        //Task<ActionResultResponese<string>> DeleteAsync(string idgvhdTheoky, string deleteUserId, string deleteFullName);
    }
}
