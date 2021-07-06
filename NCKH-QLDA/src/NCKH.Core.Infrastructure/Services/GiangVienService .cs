using Microsoft.AspNetCore.Mvc;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
	public class GiangVienService : IGiangVienService
	{
		private readonly IGiangVienRepository _giangVienRepository;
		public GiangVienService(IGiangVienRepository giangVienRepository)
		{
			_giangVienRepository = giangVienRepository;
		}


		//public async Task<SearchResult<GiangVienSearchViewModel>> SearchAsync(string keyword, int page, int pageSize)
		//{
		//	return await _giangVienRepository.SearchAsync(keyword, page, pageSize);
		//}


		public async Task<List<GiangVienSearchViewModel>> SelectAllAsync()
		{
			return await _giangVienRepository.SelectAllAsync();
		}

        public async Task<SearchResult<ThongTinGiangVienViewModel>> GetDetailAsync(string id)
        {
			return await _giangVienRepository.GetInfoAsync(id);
			
		}
    } 
}
