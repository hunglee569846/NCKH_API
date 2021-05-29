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
        Task<List<GiangVienHuongDanViewModel>> SelectAllAsync();
        Task<SearchResult<GiangVienHuongDanViewModel>> GetByIdHocKyAsync(string idhocky);
        Task<ActionResultResponese<string>> InsertAsync(GiangVienHDMeta gvhdkyMeta,string idhocky,string idmonhoc, TypeGVHD tygvhd);
        Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta,string idGVHD,string idGvhdTheoKy, TypeGVHD tygvhd);
        Task<ActionResultResponese<string>> DeleteAsync(string idGHVHDTheoKy);
    }
}
