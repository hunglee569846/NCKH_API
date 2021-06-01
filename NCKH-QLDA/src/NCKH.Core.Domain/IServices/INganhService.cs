
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface INganhService
    {
		//Task<SearchResult<NganhSearchViewModel>> SearchAsync(int page, int pageSize);
		Task<List<NganhSearchViewModel>> SelectAllAsync();
		//Task<int> InsertAsync(Nganh nganh);
		//Task<int> UpdateAsync(Nganh nganh);
		//Task<int> DeleteAsync(Nganh nganh);
		//Task<int> ForceDeleteAsync(string id);
		//Task<Nganh> GetInfoAsync(string id);
		//Task<bool> CheckExistsAsync(string id);
		//Task<bool> CheckExistsNameAsync(string id, string name);
	}
}
