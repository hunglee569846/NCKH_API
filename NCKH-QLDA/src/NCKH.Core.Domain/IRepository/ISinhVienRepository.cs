using GHM.NailSpa.Domain.ViewModels;
using NCKH.Core.Domain.Models;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
    public interface ISinhVienRepository
    {
	//	Task<SearchResult<ThongTinSinhVienViewModel>> SearchAsync(string id, int page, int pageSize);
		Task<SearchResult<SinhVienChuyenNganhViewModel>> SearchSinhVienByIdChuyenNganhAsync(string idChuyenNganh);
		Task<List<SinhVienSearchViewModel>> SelectAllAsync();
		//Task<int> InsertAsync(SinhVien sinhVien);
		//Task<int> UpdateAsync(SinhVien sinhVien);
		//Task<int> DeleteAsync(SinhVien sinhVien);
		//Task<int> ForceDeleteAsync(string id);
		Task<ThongTinSinhVienViewModel> GetInfoAsync(string id);
		Task<ThongTinSinhVienViewModel> GetInfoByMaSinhVienAsync(string maSinhVien);
		Task<bool> CheckExistsAsync(string maSinhVien);
		//Task<bool> CheckExistsNameAsync(string id, string name);
	}
}
