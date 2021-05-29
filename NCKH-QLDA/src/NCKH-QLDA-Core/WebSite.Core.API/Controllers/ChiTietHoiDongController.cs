using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class ChiTietHoiDongController : ControllerBase
    {
        //private readonly IDeTaiService _ideTaiService;

        //public DeTaiController(IDeTaiService ideTaiService)
        //{
        //    _ideTaiService = ideTaiService;

        //}
        //[AcceptVerbs("GET"), Route("GetAllByHocKy/{idhocky}")]
        //[SwaggerOperation(Summary = "SearchByHocKy Detai", Description = "Requires login verification!", OperationId = "SearchByHocKy", Tags = new[] { "DeTai" })]
        //public async Task<IActionResult> GetAllByHocKyAsync(string idhocky)
        //{
        //    var result = await _ideTaiService.GetByIdHocKyAsync(idhocky);
        //    if (result.Code <= 0)
        //    {
        //        //_logger.LogError("Search DeTai controller error " + result.Code);
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}
    }
}
