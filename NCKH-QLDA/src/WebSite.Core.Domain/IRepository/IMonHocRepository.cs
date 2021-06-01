using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IMonHocRepository
    {
        Task<SearchResult<MonHocSearchViewModel>> SelectAllByIdHocKy(string idhocky);
        Task<int> InsertAsync(MonHoc monhoc);
        Task<int> UpdateAsync(MonHoc monhoc);
        Task<int> DeleteAsync(string idMonHoc,string idHocKy);
        Task<bool> CheckExits(string idmonhoc, string mamonhoc);
        Task<bool> CheckMonHocInHocKyExits(string idmonhoc, string idhocky);
        Task<bool> CheckExitsIsActvive(string idmonhoc);
        Task<bool> CheckExitsMaMonHoc(string mamonhoc);
        Task<MonHocSearchViewModel> SearchInfo(string idmonhoc);
    }
}
