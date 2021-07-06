using Microsoft.AspNetCore.Mvc;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
	public interface IGiangVienService
	{
		//Task<SearchResult<GiangVienSearchViewModel>> SearchAsync(string keyword, int page, int pageSize);
		Task<List<GiangVienSearchViewModel>> SelectAllAsync();
		Task<SearchResult<ThongTinGiangVienViewModel>> GetDetailAsync(string id);
		//Task<ActionResultResponse<string>> InsertAsync(string creatorId, string creatorFullName, string creatorAvatar, GiangVienMeta giangVienMeta);
		//Task<ActionResultResponse<string>> UpdateAsync(string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string id, GiangVienMeta giangVienMeta);
		//Task<ActionResultResponse> DeleteAsync(string deleteUserId, string deleteFullName, string deleteAvatar, string id);
		//Task<ActionResultResponse<GiangVienDetailViewModel>> GetDetailAsync(string id);
	}
}
