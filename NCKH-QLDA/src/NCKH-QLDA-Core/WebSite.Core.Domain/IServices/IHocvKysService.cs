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
        Task<SearchResult<HocKySearchViewModel>> GetAll();
        Task<ActionResultResponese<string>> InsertAsync(HocKyMeta hockymeta,string creatorId,string creatorFullName);
        Task<ActionResultResponese<string>> DeleteAsync(string idhocky);
        Task<ActionResultResponese<string>> UpDateAsync(string idhocky, string mahocky, string tenhocky, string userId, string fullName);
    }
}
