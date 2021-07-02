using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface INhapDiemService
    {
        Task<ActionResultResponese<List<XuatDiemPhanBienViewModel>>> InsertListExcelAsync(string idfile, string idBoMon, string lastUpdateUserId, string lastUpdateFullName);
        Task<ActionResultResponese<List<XuatDiemHoiDongViewModel>>> InsertDiemHoiDongExcelAsync(string idfile, string idmonhoc, string idBoMon, string lastUpdateUserId, string lastUpdateFullName);
        Task<ActionResultResponese<string>> ChungBinhDiem(string idhocky, string idMonHoc, string idmonhoc, string lastUpdateUserId, string lastUpdateFullName);


    }
}
