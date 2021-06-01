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
    public class DeTaiController : CoreApiControllerBase
    {
        private readonly IDeTaiService _ideTaiService;

        public DeTaiController(IDeTaiService ideTaiService)
        {
            _ideTaiService = ideTaiService;

        }
        [AcceptVerbs("GET"), Route("GetAllByHocKy/{idhocky}")]
        [SwaggerOperation(Summary = "SearchByHocKy Detai", Description = "Requires login verification!", OperationId = "SearchByHocKy", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> GetAllByHocKyAsync(string idhocky)
        {
            var result = await _ideTaiService.GetByIdHocKyAsync(idhocky);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetAllByMonHocInHocKy/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "SearchByMonHocInHocKy Detai", Description = "Requires login verification!", OperationId = "SearchByMonHocInHocKy", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> GetByMonHocInHocKyAsync(string idhocky, string idmonhoc)
        {
            var result = await _ideTaiService.GetByIdMonHocInHocKyAsync(idhocky, idmonhoc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
        // đề tài và chi tiết đề tài trong học kỳ getall
        [AcceptVerbs("GET"), Route("GetAllCT/{idhocky}/{isApprove}")]
        [SwaggerOperation(Summary = "SearchByMonHocInHocKy Detai", Description = "Requires login verification!", OperationId = "SearchByMonHocInHocKyCT", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> GetByInHocKyAsync(string idhocky, bool isApprove)
        {
            var result = await _ideTaiService.SelectByIdCTDTAsync(idhocky, isApprove);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("InsertDeTai/{madetai}/{idhocky}/{idmonhoc}/{idsinhvien}/{tensinhvien}/{masinhvien}")]
        [SwaggerOperation(Summary = "InsertAsync Detai", Description = "Requires login verification!", OperationId = "InsertAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertAsync([FromBody] DeTaiInsertMeta detaiInsertMeta, string madetai, string idhocky, string idmonhoc, string idsinhvien, string tensinhvien,string masinhvien)
        {
            var result = await _ideTaiService.InsertAsync(detaiInsertMeta, madetai, idhocky, idmonhoc, idsinhvien, tensinhvien,masinhvien,CurrentUser.IdAcount,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("Update/{iddetai}")]
        [SwaggerOperation(Summary = "UpdateAsync Detai", Description = "Requires login verification!", OperationId = "UpdateAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertAsync([FromBody] DeTaiUpdateMeta detaiUpdateMeta, string iddetai)
        {
            var result = await _ideTaiService.UpdateAsync(detaiUpdateMeta, iddetai,CurrentUser.IdAcount,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
        //phê duyệt đề tài
        [AcceptVerbs("PUT"), Route("Approve/{iddetai}/{isApprove}")]
        [SwaggerOperation(Summary = "UpdateApproveAsync Detai", Description = "Requires login verification!", OperationId = "UpdateApproveAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> UpdateApproveAsync(string iddetai, bool isApprove)
        {
            var result = await _ideTaiService.UpdateAproveAsync(iddetai, isApprove);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("DELETE"), Route("Delete/{iddetai}")]
        [SwaggerOperation(Summary = "DeleteAsync Detai", Description = "Requires login verification!", OperationId = "DeleteAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> DeleteAsync(string iddetai)
        {
            var result = await _ideTaiService.DeleteAsync(iddetai);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
