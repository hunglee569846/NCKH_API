using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class PhanBienController : ControllerBase
    {
        private readonly IPhanBienServicve _phanbiencService;
        public PhanBienController(IPhanBienServicve phanbiencService)
        {
            _phanbiencService = phanbiencService;
        }
        
        [SwaggerOperation(Summary = "GetAllPhanBien", Description = "Requires login verification!", OperationId = "GetAllPhanBienAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("GET"), Route("{idhocky}")]
        public async Task<IActionResult> GetAllAsync(string idhocky)
        {
            var result = await _phanbiencService.GetAllByIdHK(idhocky);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "InsertPhanBien", Description = "Requires login verification!", OperationId = "InsertPhanBienAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("POST"), Route("{idGVPB}/{iddetai}/{idhocky}")]
        public async Task<IActionResult> GetAllAsync([FromBody]PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky)
        {
            var result = await _phanbiencService.InsertByHk(phanbienMeta, idGVPB, iddetai, idhocky);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateAsyncPhanBien", Description = "Requires login verification!", OperationId = "UpdateAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("PUT"), Route("{idGVPB}/{iddetai}/{idhocky}/{idPhanBien}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PhanBienUpdateMeta phanbienupdateMeta, string idGVPB, string iddetai, string idhocky,string idPhanBien)
        {
            var result = await _phanbiencService.Update(phanbienupdateMeta, idGVPB, iddetai, idhocky, idPhanBien);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateDiemPhanBien", Description = "Requires login verification!", OperationId = "UpdateDiemAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("PUT"), Route("{idPhanBien}/{idhocky}/{Diem}")]
        public async Task<IActionResult> UpdateDiemAsync([FromBody] NoteMeta note, float Diem, string idhocky, string idPhanBien)
        {
            var result = await _phanbiencService.UpdateDiemAsync(idPhanBien, idhocky, Diem, note);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "DeletePhanBien", Description = "Requires login verification!", OperationId = "DeletePhanBienAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("DELETE"), Route("{idPhanBien}/{idhocky}")]
        public async Task<IActionResult> DeleteAsync(string idhocky, string idPhanBien)
        {
            var result = await _phanbiencService.DeleteAsync(idPhanBien, idhocky);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
