using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;

namespace WebSite.Core.Domain.IServices
{
    public interface IChiTietHoiDongService
    {
        Task<ActionResultResponese<string>> InserAsync(string idhoidong, string idgvhd, string creartorUserId, string creartorFullName);
        Task<ActionResultResponese<string>> InserListDeTaiAsync(List<ChiTietHoiDongMeta> listChiTietHoiDongmeta, string idhoidong, string creartorUserId, string creartorFullName);
        Task<ActionResultResponese<string>> DeleteAsync(string idchitietHD);
        //Task<SearchResult<DeTaivsCTDTViewModel>> SelectByDeTaiAsync(string iddetai);
    }
}
