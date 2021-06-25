using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IBangDiemRepository
    {
        Task<int> InsertAsync(BangDiem bangdiem);
        Task<int> UpdateDiemAsync(BangDiem bangdiem);
        Task<bool> CheckExit(string iddetai);
        Task<bool> CheckExitIdBangDiem(string idBangDiem);
        //xuất file mẫu điểm phản biện
        Task<SearchResult<XuatDiemPhanBienViewModel>> XuatDiemPhanBien(string idhocky, string idmonhoc, string idbomon);
        //xuất file mẫu điểm phản biện Excel
        Task<List<XuatDiemPhanBienViewModel>> XuatDiemPhanBienExcel(string idhocky, string idmonhoc, string idbomon);

        //xuất file mẫu điểm hoi dong Excel
        Task<List<XuatDiemHoiDongViewModel>> XuatDiemHoiDongExcel(string idhocky, string idmonhoc, string idbomon);
        //xuất file mẫu điểm hoi dong
        Task<SearchResult<XuatDiemHoiDongViewModel>> XuatDiemHoiDong(string idhocky, string idmonhocs, string idbomon);
    }
}
