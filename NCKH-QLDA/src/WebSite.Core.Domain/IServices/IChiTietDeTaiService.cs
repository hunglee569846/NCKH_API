using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IChiTietDeTaiService
    {
        //Task<ChiTietDeTaiViewModel> SearchById(string iddetai);
        Task<ActionResultResponese<string>> InserAsync(ChiTietDeTaiMeta chitietdetaimeta, string iddetai, string idgvhd, string idhocky, string idmonhoc, string CreatorId, string CreatorFullName,string idBoMon);
        Task<ActionResultResponese<string>> InserListDeTaiAsync(List<ChiTietDeTaiListDeTaiMeta> listdetaimeta, string idgvhd, string idhocky, string idmonhoc, string CreatorId, string CreatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> DeleteAsync(string idchitietdetai);
        Task<SearchResult<DeTaivsCTDTViewModel>> SelectByDeTaiAsync(string iddetai);
    }
}
