


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.Resources;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Constans;
using NCKH.Infrastruture.Binding.IServices;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;

namespace GHM.NailSpa.Infrastructure.Services
{
    public class NganhService : INganhService
		{
			private readonly INganhRepository _nganhRepository;
			//private readonly IResourceService<APINCKHResource> _NCKHSpaResource;
			public NganhService(INganhRepository nganhRepository)
			{
				_nganhRepository = nganhRepository;
			//_NCKHSpaResource = nckhResource;
			}


			//public async Task<SearchResult<NganhSearchViewModel>> SearchAsync(int page, int pageSize)
			//{
			//	return await _nganhRepository.SearchAsync(page, pageSize);
			//}


        public async Task<List<NganhSearchViewModel>> SelectAllAsync()
        {
            return await _nganhRepository.SelectAllAsync();
        }

        public async Task<ActionResultResponese<NganhDetailViewModel>> GetDetailAsync(string id)
			{
				var info = await _nganhRepository.GetInfoAsync(id);
				if (info == null)
					return new ActionResultResponese<NganhDetailViewModel>(-1,"loi he thong.","");

				var nganhDetail = new NganhDetailViewModel
				{
					Id = info.Id,
					MaNganh = info.MaNganh,
					TenNganh = info.TenNganh,
					IdBoMon = info.IdBoMon,
					NgayTao = info.NgayTao,
					IsActive = info.IsActive,
					NgayCapNhat = info.NgayCapNhat,
					NgayXoa = info.NgayXoa,
				};
				return new ActionResultResponese<NganhDetailViewModel>
				{
					Code = 1,
					Data = nganhDetail
				};
			}


		}
	}


