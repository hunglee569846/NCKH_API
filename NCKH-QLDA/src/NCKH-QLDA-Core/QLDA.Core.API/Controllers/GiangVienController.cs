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
	//[Authorize]
	[Produces("application/json")]
	[Route("api/[controller]")]
	[SwaggerTag("Insert, Update, Delete, Get Detail, Search GiangViens")]
	public class GiangVienController : ControllerBase
	{
		private readonly IGiangVienService _giangVienService;
		private readonly ILogger<GiangVienController> _logger;

		public GiangVienController(IGiangVienService giangVienService, ILogger<GiangVienController> logger)
		{
			_giangVienService = giangVienService;
			_logger = logger;
		}

		//[SwaggerOperation(Summary = "Search information giangVien.", Description = "Requires login verification!", OperationId = "SearchGiangVien", Tags = new[] { "GiangVien" })]
		//[AcceptVerbs("GET")]
		//public async Task<IActionResult> SearchAsync(string keyword, int page = 1, int pageSize = 20)
		//{
		//	var result = await _giangVienService.SearchAsync(keyword, page, pageSize);
		//	if (result.Code <= 0)
		//	{
		//		_logger.LogError("Search giangVien controller error " + result.Code);
		//		return BadRequest(result);
		//	}
		//	return Ok(result);
		//}

		[SwaggerOperation(Summary = "Get all information giangVien.", Description = "Requires login verification!", OperationId = "GetAllGiangVien", Tags = new[] { "GiangVien" })]
		[Route("get-all"), AcceptVerbs("GET")]
		public async Task<IActionResult> SelectAllAsync()
		{
			var result = await _giangVienService.SelectAllAsync();
			return Ok(result);
		}

		[SwaggerOperation(Summary = "Get information GiangVien.", Description = "Requires login verification!", OperationId = "GetInfoGiangVien", Tags = new[] { "GiangVien" })]
		[Route("get-thongtin_giangvien/{id}"), AcceptVerbs("GET")]
		public async Task<IActionResult> ThongTinSinhVienAsync(string id)
		{
			var result = await _giangVienService.GetDetailAsync(id);
			return Ok(result);
		}
	}
}
