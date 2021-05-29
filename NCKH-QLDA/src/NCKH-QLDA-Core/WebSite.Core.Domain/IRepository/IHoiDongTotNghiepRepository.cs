using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IHoiDongTotNghiepRepository
    {
        Task<SearchResult<HoiDongTotNghiepViewModel>> SelectAll(string idhocky);
        Task<int> InsertAsync(HoiDongTotNghiep hoidong);
        Task<int> UpdateAsync(HoiDongTotNghiep hoidong);
        Task<bool> CheckExit(string idhoidong, string idhocky);
    }
}
