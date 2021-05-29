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
        Task<SearchResult<HocKySearchViewModel>> SelectAll();
        Task<HocKySearchViewModel> SearchInfo(string idhocky);
        Task<int> InsertAsync(HocKy hocky);
        Task<int> DeleteAsync(string idhocky);
        Task<int> UpdateAsync(string idhocky, string mahocky, string tenhocky, DateTime? ngaysua, string userId, string fullName);
        Task<bool> CheckExistAsync(string idHocKy,string maHocky);
        Task<bool> CheckExisIsActivetAsync(string idHocKy);
    }
}
