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
        Task<SearchResult<MonHocSearchViewModel>> SelectAllByIdHocKy(string idhocky,string idbomon);
        Task<int> InsertAsync(MonHoc monhoc);
        Task<int> UpdateAsync(MonHoc monhoc);
        Task<int> DeleteAsync(MonHoc monhoc);
        Task<bool> CheckExits(string idHocKy, string maMonHoc);
        Task<bool> CheckMonHocInHocKyExits(string idmonhoc, string idhocky);
        Task<bool> CheckExitsIsActvive(string idmonhoc);
        Task<bool> CheckExitsMaMonHoc(string mamonhoc);
        Task<MonHoc> GetInfoAsync(string idmonhoc);
    }
}
