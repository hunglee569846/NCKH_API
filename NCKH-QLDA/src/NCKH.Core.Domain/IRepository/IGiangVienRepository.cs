using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
	public interface IGiangVienRepository
	{
		//Task<SearchResult<GiangVienSearchViewModel>> SearchAsync(string keyword, int page, int pageSize);
		Task<List<GiangVienSearchViewModel>> SelectAllAsync();
		//Task<int> InsertAsync(GiangVien giangVien);
		//Task<int> UpdateAsync(GiangVien giangVien);
		//Task<int> DeleteAsync(GiangVien giangVien);
		//Task<int> ForceDeleteAsync(string id);
		Task<SearchResult<ThongTinGiangVienViewModel>> GetInfoAsync(string idgiangvien);
		//Task<GiangVien> GetInfoAsync(string id);
		//Task<bool> CheckExistsAsync(string id);
		//Task<bool> CheckExistsNameAsync(string id, string name);
	}
}
