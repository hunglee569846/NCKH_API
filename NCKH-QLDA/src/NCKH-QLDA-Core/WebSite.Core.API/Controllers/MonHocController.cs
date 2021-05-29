using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.Constansts;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class MonHocController : CoreApiControllerBase
    {
        
        private readonly IMonHocService _imonhocService;
        public MonHocController(IMonHocService imonhocService)
        {
            _imonhocService = imonhocService;
        }
        /// <summary>
        /// TypeApprover: 
        /// 0 - GangVien,
        /// 1 - HoiDong,
        /// 2 - PhanBienvsPhanBien
        /// </summary>
        /// <param name="idhocky"></param>
        /// <returns></returns>
        [SwaggerOperation(Summary = "GetAllMonHoc", Description = "TypeApprover: 0 - GangVien,1 - HoiDong,2 - PhanBienvsPhanBien", OperationId = "GetAllMonHocAsync", Tags = new[] { "MonHoc" })]
        [AcceptVerbs("GET"), Route("{idhocky}")]
        public async Task<IActionResult> GetAllAsync(string idhocky)
        {
            var result = await _imonhocService.GetAllAsyncByIdHocKy(idhocky);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search MonHoc controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "InsertAsyncMonHoc", Description = "TypeApprover: 0 - GangVien,1 - HoiDong,2 - PhanBienvsPhanBien" , OperationId = "InsertAsyncMonHoc", Tags = new[] { "MonHoc" })]
        [AcceptVerbs("POST"), Route("{mamonhoc}/{tenmonhoc}/{idhocky}/{typeApprover}")]
        public async Task<IActionResult> InsertAsync([FromBody]MonHocMeta monHocMeta, string idhocky, TypeDataApprover typeApprover ,string mamonhoc,string tenmonhoc)
        {
            var result = await _imonhocService.InsertAsync(monHocMeta,idhocky, typeApprover,CurrentUser.MaGiangVien,CurrentUser.FullName, mamonhoc, tenmonhoc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Insert MonHocs controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateAsyncMonHoc", Description = "TypeApprover: 0 - GangVien,1 - HoiDong,2 - PhanBienvsPhanBien", OperationId = "UpdateAsyncMonHoc", Tags = new[] { "MonHoc" })]
        [AcceptVerbs("PUT"), Route("{mamonhoc}/{tenmonhoc}/{idmonhoc}/{typeApprover}")]
        public async Task<IActionResult> UpdateAsync([FromBody] MonHocMeta monhocmeta, string idmonhoc, string idhocky, TypeDataApprover typeApprover, string mamonhoc, string tenmonhoc)
        {
            var result = await _imonhocService.UpdateAsync(monhocmeta, idhocky, idmonhoc, typeApprover,CurrentUser.MaGiangVien,CurrentUser.FullName,mamonhoc,tenmonhoc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Insert MonHocs controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

