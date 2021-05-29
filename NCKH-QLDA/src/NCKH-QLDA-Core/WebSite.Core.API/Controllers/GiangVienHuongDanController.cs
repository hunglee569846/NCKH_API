using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
    public class GiangVienHuongDanController : ControllerBase
    {
        private readonly IGiangVienHuongDanService _iGiangVienHuongDanService;

        public GiangVienHuongDanController(IGiangVienHuongDanService iGiangVienHuongDanService)
        {
            _iGiangVienHuongDanService = iGiangVienHuongDanService;

        }
        [AcceptVerbs("GET"), Route("GetAllGiangVienHuongDan")]
        [SwaggerOperation(Summary = "SelectAll GiangVienHuongDan", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "GetAllGiangVienHuongDan", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iGiangVienHuongDanService.SelectAllAsync();
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetAllGiangVienHuongDan/{idhocky}")]
        [SwaggerOperation(Summary = "SelectAll GiangVienHuongDan", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "GetAllGiangVienHuongDanByHK", Tags = new[] { "GiangVienHuongDan" })]    
        public async Task<IActionResult> GetByIdAsync(string idhocky)
        {
            var result = await _iGiangVienHuongDanService.GetByIdHocKyAsync(idhocky);
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("{idhocky}/{idmonhoc}/{typegvhd}")]
        [SwaggerOperation(Summary = "Insert GiangVienHuongDanTheoKy", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "InsertGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> InsertAsync([FromBody]GiangVienHDMeta gvhdMeta,string idhocky,string idmonhoc, TypeGVHD typegvhd)
        {
            var result = await _iGiangVienHuongDanService.InsertAsync(gvhdMeta,idhocky,idmonhoc, typegvhd);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Insert GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("UpDate/{idGVHD}/{idGvhdTheoKy}/{tygvhd}")]
        [SwaggerOperation(Summary = "Update GiangVienHuongDanTheoKy", Description = "Requires login verification!", OperationId = "UpdateGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> UpdateAsync([FromBody] GVHDupdateMeta gvhdkyUpdateMeta, string idGVHD, string idGvhdTheoKy, TypeGVHD tygvhd)
        {
            var result = await _iGiangVienHuongDanService.UpdateAsync(gvhdkyUpdateMeta, idGVHD, idGvhdTheoKy, tygvhd);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Update GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("DELETE"), Route("Delete/{idGvhdTheoKy}")]
        [SwaggerOperation(Summary = "Delete GiangVienHuongDanTheoKy", Description = "Requires login verification!", OperationId = "DeleteGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> DeleteAsync(string idGvhdTheoKy)
        {
            var result = await _iGiangVienHuongDanService.DeleteAsync(idGvhdTheoKy);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Delete GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
