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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class LopController : Controller
    {
        private readonly ILopService _iLopService;
        private readonly ILogger<LopController> _logger;
        public LopController(ILopService ilopService, ILogger<LopController> logger)
        {
            _iLopService = ilopService;
            _logger = logger;
        }
        [AcceptVerbs("GET"), Route("GetAll")]
        [SwaggerOperation(Summary = "SelectAll LopHoc", Description = "Requires login verification!", OperationId = "GetAllLopHoc", Tags = new[] { "LopHoc" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iLopService.SelectAllAsync();
            return Ok(result);
        }

        [AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "SelectById LopHoc", Description = "Requires login verification!", OperationId = "GetByIdLopHoc", Tags = new[] { "LopHoc" })]
        [Route("{id}")]
        public async Task<IActionResult> SelectAllAsync(string id)
        {
            var result = await _iLopService.GetByIdLop(id);
            if (result.Code <= 0)
            {
                _logger.LogError("Get detail customer controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
