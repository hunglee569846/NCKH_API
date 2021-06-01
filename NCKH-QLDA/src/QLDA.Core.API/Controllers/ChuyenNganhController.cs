using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IServices;
using NCKH.Infrastruture.Binding.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDA.Core.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class ChuyenNganhController : ControllerBase
    {
        private readonly IChuyenNganhService _iChuyenNganhService;
        private readonly ILogger<ChuyenNganhController> _logger;
        public ChuyenNganhController(IChuyenNganhService ichuyenNganhService, ILogger<ChuyenNganhController> logger)
        {
            _iChuyenNganhService = ichuyenNganhService;
            _logger = logger;
        }
        [AcceptVerbs("GET"), Route("GetAll")]
        [SwaggerOperation(Summary = "SelectAll ChuyenNganh", Description = "Requires login verification!", OperationId = "GetAllChuyenNganh", Tags = new[] { "ChuyenNganh" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iChuyenNganhService.SelectAllAsync();
            return Ok(result);
        }

        [AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "SelectById ChuyenNganh", Description = "Requires login verification!", OperationId = "GetByIdChuyenNganh", Tags = new[] { "ChuyenNganh" })]
        [Route("{id}")]
        public async Task<IActionResult> SelectAllAsync(string id)
        {
            var result = await _iChuyenNganhService.ChiTietChuyenNganh(id);
            if (result.Code <= 0)
            {
                _logger.LogError("Get detail customer controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }

}

