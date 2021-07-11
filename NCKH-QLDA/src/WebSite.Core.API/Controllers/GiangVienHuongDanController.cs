using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
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
    public class GiangVienHuongDanController : CoreApiControllerBase
    {
        private readonly IGiangVienHuongDanService _iGiangVienHuongDanService;

        public GiangVienHuongDanController(IGiangVienHuongDanService iGiangVienHuongDanService)
        {
            _iGiangVienHuongDanService = iGiangVienHuongDanService;

        }
        [AcceptVerbs("GET"), Route("GetAllGiangVienHuongDan")]
        [SwaggerOperation(Summary = "Danh sách giảng viên all", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "GetAllGiangVienHuongDan", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iGiangVienHuongDanService.SelectAllAsync(CurrentUser.IdBoMon);
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetAllGiangVienHuongDan/{idhocky}")]
        [SwaggerOperation(Summary = "Danh sách giảng viên theo học kỳ.", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "GetAllGiangVienHuongDanByHK", Tags = new[] { "GiangVienHuongDan" })]    
        public async Task<IActionResult> GetByIdAsync(string idhocky)
        {
            var result = await _iGiangVienHuongDanService.GetByIdHocKyAsync(idhocky,CurrentUser.IdBoMon);
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("{idhocky}/{typegvhd}")]
        [SwaggerOperation(Summary = "thêm mới một giảng viên", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "InsertGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> InsertAsync([FromBody]GiangVienHDMeta gvhdMeta,string idhocky, TypeGVHD typegvhd)
        {
            var result = await _iGiangVienHuongDanService.InsertAsync(gvhdMeta,idhocky, typegvhd,CurrentUser.MaGiangVien,CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Insert GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("{idhocky}")]
        [SwaggerOperation(Summary = "Thêm mới danh sách giảng viên.", Description = "TypeGVHD: 0 - NgoaiTruong,1 - trongTruong", OperationId = "InsertListGVHDTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> InsertListAsync([FromBody] List<GiangVienListMeta> listgvhdMeta, string idhocky)
        {
            var result = await _iGiangVienHuongDanService.InsertListGVHDAsync(listgvhdMeta, idhocky, CurrentUser.MaGiangVien, CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Insert GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("UpDate/{idGvhdTheoKy}/{tygvhd}")]
        [SwaggerOperation(Summary = "Sửa thông tin giảng viên.", Description = "Requires login verification!", OperationId = "UpdateGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> UpdateAsync([FromBody] GVHDupdateMeta gvhdkyUpdateMeta, string idGvhdTheoKy, TypeGVHD tygvhd)
        {
            var result = await _iGiangVienHuongDanService.UpdateAsync(gvhdkyUpdateMeta, idGvhdTheoKy, tygvhd,CurrentUser.MaGiangVien,CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Update GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("DELETE"), Route("Delete/{idGvhdTheoKy}")]
        [SwaggerOperation(Summary = "xóa giảng viên", Description = "Requires login verification!", OperationId = "DeleteGiangVienHuongDanTheoKy", Tags = new[] { "GiangVienHuongDan" })]
        public async Task<IActionResult> DeleteAsync(string idGvhdTheoKy)
        {
            var result = await _iGiangVienHuongDanService.DeleteAsync(idGvhdTheoKy,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //  _logger.LogError("Delete GiangVienHuongDan controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
