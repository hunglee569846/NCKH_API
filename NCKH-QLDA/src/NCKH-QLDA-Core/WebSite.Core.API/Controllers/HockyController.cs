using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class HockyController : CoreApiControllerBase
    {
        private readonly IHocvKysService _ihockyService;
        public HockyController(IHocvKysService ihockyService)
        {
            _ihockyService = ihockyService;
        }

        [AcceptVerbs("GET"), Route("GetAllHocKy")]
        [SwaggerOperation(Summary = "GetAllHocKy", Description = "Requires login verification!", OperationId = "GetAllHocKyAsync", Tags = new[] { "Hocky" })]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ihockyService.GetAll();
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("InsertAsyncHocKy")]
        [SwaggerOperation(Summary = "InsertAsyncHocKy", Description = "Requires login verification!", OperationId = "InsertAsyncHocKy", Tags = new[] { "Hocky" })]
        public async Task<IActionResult> InsertAsync(HocKyMeta hockymeta)
        {
            var result = await _ihockyService.InsertAsync(hockymeta,CurrentUser.IdAcount,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                // _logger.LogError("Insert Hockys controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Delete information Hocky.", Description = "Requires login verification!", OperationId = "DeleteAsyncHocKy", Tags = new[] { "Hocky" })]
        [Route("{idHocKy}"), AcceptVerbs("DELETE")]
        public async Task<IActionResult> UpdateAsync(string idHocKy)
        {
            var result = await _ihockyService.DeleteAsync(idHocKy);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Delete Hockys controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("{idHocKy}/{mahocky}/{tenhocky}")]
        [SwaggerOperation(Summary = "UpdateAsyncHocKy", Description = "Requires login verification!", OperationId = "UpdateAsyncHocKy", Tags = new[] { "Hocky" })]
        public async Task<IActionResult> UpdateAsync(string idHocKy,string mahocky,string tenhocky) //[FromBody]HocKyMeta hockymeta
        {
            var result = await _ihockyService.UpDateAsync(idHocKy,mahocky, tenhocky,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                // _logger.LogError("Insert Hockys controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
