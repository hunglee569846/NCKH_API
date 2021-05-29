using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDA.Core.API.Controllers
{
	
	[ApiController]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[SwaggerTag("Insert, Update, Delete, Get Detail, Search SinhViens")]
    public class SinhVienController : ControllerBase
	{
		private readonly ISinhVienService _sinhVienService;
		private readonly ILogger<SinhVienController> _logger;

		public SinhVienController(ISinhVienService sinhVienService, ILogger<SinhVienController> logger)
		{
			_sinhVienService = sinhVienService;
			_logger = logger;
		}

		//[SwaggerOperation(Summary = "Search information sinhVien.", Description = "Requires login verification!", OperationId = "SearchSinhVien", Tags = new[] { "SinhVien" })]
		//[AcceptVerbs("GET")]
		//public async Task<IActionResult> SearchByIdLopAsync(string id, int page = 1, int pageSize = 20)
		//{
		//	var result = await _sinhVienService.SearchAsync(id,page, pageSize);
		//	if (result.Code <= 0)
		//	{
		//		_logger.LogError("Search sinhVien controller error " + result.Code);
		//		return BadRequest(result);
		//	}
		//	return Ok(result);
		//}

		[SwaggerOperation(Summary = "Get all information sinhVien.", Description = "Requires login verification!", OperationId = "GetAllSinhVien", Tags = new[] { "SinhVien" })]
		[Route("get-all"), AcceptVerbs("GET")]
		public async Task<IActionResult> SelectAllAsync()
		{
			var result = await _sinhVienService.SelectAllAsync();
			return Ok(result);
		}

        [SwaggerOperation(Summary = "Get information sinhVien.", Description = "Requires login verification!", OperationId = "GetInfoSinhVien", Tags = new[] { "SinhVien" })]
        [Route("get-thongtin_sinhvien/{id}"), AcceptVerbs("GET")]
        public async Task<IActionResult> ThongTinSinhVienAsync(string id)
        {
            var result = await _sinhVienService.GetDetailAsync(id);
            return Ok(result);
        }

		[SwaggerOperation(Summary = "Get information sinhVien by maSinhVien.", Description = "Requires login verification!", OperationId = "GetInfoByMaSinhVien", Tags = new[] { "SinhVien" })]
		[Route("get-thongtin_sinhvien_byMaSinhVien/{maSinhVien}"), AcceptVerbs("GET")]
		public async Task<IActionResult> ThongTinSinhVienByMaSinhVienAsync(string maSinhVien)
		{
			var result = await _sinhVienService.GetInfoByMaSinhVienAsync(maSinhVien);
			return Ok(result);
		}

		[SwaggerOperation(Summary = "Get information sinhVien by IdChuyenNganh.", Description = "Requires login verification!", OperationId = "GetSinhVienByIdChuyenNganh", Tags = new[] { "SinhVien" })]
		[Route("get-thongtin_sinhvien_byIdChuyenNganh/{IdChuyenNganh}"), AcceptVerbs("GET")]
		public async Task<IActionResult> SinhVienChuyenNganhAsync(string IdChuyenNganh)
		{
			var result = await _sinhVienService.SearchSinhVienByIdChuyenNganhAsync(IdChuyenNganh);
			return Ok(result);
		}

	}
}
