using Microsoft.AspNetCore.Authorization;
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
	[Route("api/[controller]")]
	[ApiController]
    [Produces("application/json")]
   // [Route("api/v{version:1.0}/Nganhs")]
    [SwaggerTag("Insert, Update, Delete, Get Detail, Search Nganhs")]
    public class NganhController : ControllerBase
    {
		private readonly INganhService _nganhService;
		private readonly ILogger<NganhController> _logger;

		public NganhController(INganhService nganhService, ILogger<NganhController> logger)
		{
			_nganhService = nganhService;
			_logger = logger;
		}

		//[SwaggerOperation(Summary = "Search information nganh.", Description = "Requires login verification!", OperationId = "SearchNganh", Tags = new[] { "Nganh" })]
		//[AcceptVerbs("GET")]
		//public async Task<IActionResult> SearchAsync(string keyword, int page = 1, int pageSize = 20)
		//{
		//	var result = await _nganhService.SearchAsync(keyword, page, pageSize);
		//	if (result.Code <= 0)
		//	{
		//		_logger.LogError("Search nganh controller error " + result.Code);
		//		return BadRequest(result);
		//	}
		//	return Ok(result);
		//}

		[SwaggerOperation(Summary = "Get all information nganh.", Description = "Requires login verification!", OperationId = "GetAllNganh", Tags = new[] { "Nganh" })]
		[Route("get-all"), AcceptVerbs("GET")]
		public async Task<IActionResult> SelectAllAsync()
		{
			var result = await _nganhService.SelectAllAsync();
			return Ok(result);
		}

	}
}
