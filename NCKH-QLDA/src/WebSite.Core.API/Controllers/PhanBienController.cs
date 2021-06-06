using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using NCKH.Infrastruture.Binding;
using System.Collections.Generic;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class PhanBienController : CoreApiControllerBase
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
        [AcceptVerbs("POST"), Route("{idGVPB}/{iddetai}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync([FromBody]PhanBienMeta phanbienMeta, string idGVPB, string iddetai, string idhocky,string idmonhoc)
        {
            var result = await _phanbiencService.InsertByHk(phanbienMeta, idGVPB, iddetai, idhocky,idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "InsertListPhanBien", Description = "Requires login verification!", OperationId = "InsertListPhanBienAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("POST"), Route("ListPhanBien/{iddetai}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertListAsync([FromBody] List<PhanBienlistMeta> listphanbienMeta , string iddetai, string idhocky, string idmonhoc)
        {
            var result = await _phanbiencService.InsertListPBHk(listphanbienMeta, iddetai, idhocky, idmonhoc, CurrentUser.MaGiangVien, CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateAsyncPhanBien", Description = "Requires login verification!", OperationId = "UpdateAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("PUT"), Route("{idGVPB}/{iddetai}/{idhocky}/{idmonhoc}/{idPhanBien}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PhanBienUpdateMeta phanbienupdateMeta, string idGVPB, string iddetai, string idhocky,string idmonhoc, string idPhanBien)
        {
            var result = await _phanbiencService.Update(phanbienupdateMeta, idGVPB, iddetai, idhocky,idmonhoc, idPhanBien,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateDiemPhanBien", Description = "Requires login verification!", OperationId = "UpdateDiemAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("PUT"), Route("{idPhanBien}/{idhocky}/{idmonhoc}/{Diem}/{iddetai}")]
        public async Task<IActionResult> UpdateDiemAsync([FromBody] NoteMeta note, float Diem, string idhocky, string idmonhoc, string idPhanBien,string iddetai)
        {
            var result = await _phanbiencService.UpdateDiemAsync(idPhanBien, idhocky,idmonhoc, Diem, note,iddetai);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "DeletePhanBien", Description = "Requires login verification!", OperationId = "DeletePhanBienAsync", Tags = new[] { "PhanBien" })]
        [AcceptVerbs("DELETE"), Route("{idPhanBien}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> DeleteAsync(string idPhanBien, string idhocky,string idmonhoc)
        {
            var result = await _phanbiencService.DeleteAsync(idPhanBien, idhocky,idmonhoc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
