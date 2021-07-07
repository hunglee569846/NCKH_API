using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IHocvKysService
    {
        Task<SearchResult<HocKySearchViewModel>> GetAll(string IdBoMon);
        Task<ActionResultResponese<string>> InsertAsync(int hocky, string userId, string fullName, string idBoMon);
        Task<ActionResultResponese<string>> DeleteAsync(string idhocky);
        Task<ActionResultResponese<string>> LockData(string idhocky, bool isLockData,string idbomon);
        Task<ActionResultResponese<string>> UpDateAsync(string idhocky, string mahocky, string tenhocky,string namHoc, string userId, string fullName,string idbomon);
    }
}
