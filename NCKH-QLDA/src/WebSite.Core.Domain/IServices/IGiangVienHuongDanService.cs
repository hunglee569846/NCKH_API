using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Constansts;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
   public interface IGiangVienHuongDanService
    {
        Task<SearchResult<GiangVienHuongDanViewModel>> SelectAllAsync(string idbomon);
        Task<SearchResult<GiangVienHuongDanViewModel>> GetByIdHocKyAsync(string idhocky,string idbomon);
        Task<ActionResultResponese<string>> InsertAsync(GiangVienHDMeta gvhdkyMeta,string idhocky , TypeGVHD tygvhd,string CreatorUserId, string CreatorFullName,string idbomon);
        Task<ActionResultResponese<string>> InsertListGVHDAsync(List<GiangVienListMeta> gvhdlistMeta,string idhocky, string CreatorUserId, string CreatorFullName, string idbomon);
        Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta, string idGvhdTheoKy, TypeGVHD tygvhd, string CreatorUserId, string creatorFullName, string idbomon);
        Task<ActionResultResponese<string>> DeleteAsync(string idgvhdTheoky, string deleteUserId, string deleteFullName);

       
    }
}
