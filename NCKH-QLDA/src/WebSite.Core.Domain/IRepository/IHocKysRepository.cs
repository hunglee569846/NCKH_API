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
    public interface IHocKysRepository
    {
        Task<SearchResult<HocKySearchViewModel>> SelectAll(string idbomon);
        Task<HocKy> SearchInfo(string idhocky);
        Task<int> InsertAsync(HocKy hocky);
        Task<int> DeleteAsync(string idhocky);
        Task<int> UpdateAsync(HocKy hocKy);
       // Task<int> LockData(HocKy hocKy);
        //Task<int> UpdateAsync(string idhocky, string mahocky, string tenhocky, DateTime? LastUpdate, string userId, string fullName);
        Task<bool> CheckExistAsync(string idHocKy,string maHocky);
        Task<bool> CheckExisIsActivetAsync(string idHocKy);
        Task<bool> CheckLockDataAsync(string idHocKy);
        Task<bool> CheckExisMaHocKy(string mahocky, string idbomon);
    }
}
