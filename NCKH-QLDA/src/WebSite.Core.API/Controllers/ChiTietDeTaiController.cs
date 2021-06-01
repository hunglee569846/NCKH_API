using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
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
    public class ChiTietDeTaiController : CoreApiControllerBase
    {
        private readonly IChiTietDeTaiService _chitietdetaiService;
        public ChiTietDeTaiController(IChiTietDeTaiService chitietdetaiService)
        {
            _chitietdetaiService = chitietdetaiService;
        }
        
        [SwaggerOperation(Summary = "InsertAsyncChiTietDeTai", Description = "Requires login verification!", OperationId = "InsertAsyncChiTietDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("POST"), Route("ChiTietDeTai/{iddetai}/{idGVHD}")]
        public async Task<IActionResult> InsertAsync(ChiTietDeTaiMeta chitietdetai,string iddetai,string idGVHD)
        {
            var result = await _chitietdetaiService.InserAsync(chitietdetai, iddetai, idGVHD,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if(result.Code <= 0)
            {
               return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "InsertAsyncListChiTietDeTai", Description = "Requires login verification!", OperationId = "InsertAsyncListChiTietDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("POST"), Route("ListChiTietDeTai/{idGVHD}")]
        public async Task<IActionResult> InsertListChitietDTAsync([FromBody]List<ChiTietDeTaiListDeTaiMeta> listchitietdetai,string idGVHD)
        {
            var result = await _chitietdetaiService.InserListDeTaiAsync(listchitietdetai, idGVHD, CurrentUser.MaGiangVien, CurrentUser.FullName);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [SwaggerOperation(Summary = "SerchByIdDeTai", Description = "Requires login verification!", OperationId = "SerchByIdDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("GET"), Route("SerchByIdDeTai/{iddetai}")]
        public async Task<IActionResult> SearchAsync(string iddetai)
        {
            var result = await _chitietdetaiService.SelectByDeTaiAsync(iddetai);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [SwaggerOperation(Summary = "DeleteIdDeTai", Description = "Requires login verification!", OperationId = "DeleteIdDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("DELETE"), Route("Delete/{idChiTietDeTai}")]
        public async Task<IActionResult> DeleteAsync(string idChiTietDeTai)
        {
            var result = await _chitietdetaiService.DeleteAsync(idChiTietDeTai);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
    }
}
