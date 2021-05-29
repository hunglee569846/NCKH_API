using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface IBoMonService
    {
        Task<List<BoMonSearchViewModel>> SelectAllAsync();
        Task<SearchResult<BoMonSearchViewModel>> SearchByIdBoMon(string idBoMon);
        Task<SearchResult<BoMonSearchViewModel>> SearchByIdKhoa(string idKhoa);
    }
}
