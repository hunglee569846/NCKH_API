using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using System;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using System.Collections.Generic;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class SinhVienController : CoreApiControllerBase
    {
        private readonly ISinhVienService _SinhViencService;
        public SinhVienController(ISinhVienService sinhvienService)
        {
            _SinhViencService = sinhvienService;
        }

        [SwaggerOperation(Summary = "Thêm mới một sinh viên", Description = "Requires login verification!", OperationId = "InsertSinhVienAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("POST"), Route("SinhVien/{idhocky}")]
        public async Task<IActionResult> InsertAsync([FromBody] SinhVienMeta sinhvienMeta, string idhocky)
        {
            var result = await _SinhViencService.InsertAsync(sinhvienMeta, idhocky,CurrentUser.MaGiangVien,CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Thêm mới danh sách sinh viên.", Description = "Requires login verification!", OperationId = "InsertListSinhVienAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("POST"), Route("SinhVienList/{idhocky}")]
        public async Task<IActionResult> InsertListAsync([FromBody] List<SinhVienMeta> listsinhvienMeta, string idhocky)
        {
            var result = await _SinhViencService.InsertListAsync(listsinhvienMeta, idhocky, CurrentUser.MaGiangVien, CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sách sinh viên theo kỳ.", Description = "Requires login verification!", OperationId = "GetAllSinhVienAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("GET"), Route("SinhVienGetAll/{idhocky}")]
        public async Task<IActionResult> GetllByHocKyAsync(string idhocky)
        {
            var result = await _SinhViencService.SelectAllAsync(idhocky,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Thông tin sinh viên.", Description = "Requires login verification!", OperationId = "GetDetailSinhVienAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("GET"), Route("GetDetailSinhVien/{idsinhvien}")]
        public async Task<IActionResult> GetDetail(string idsinhvien)
        {
            var result = await _SinhViencService.GetByIdAsync(idsinhvien);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sach sinh viên chưa có đề tài.", Description = "Requires login verification!", OperationId = "GetDetailSinhVienAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("GET"), Route("GetDetailSinhVien/{idhocky}/{}")]
        public async Task<IActionResult> GetChuaCoDeTai(string idsinhvien)
        {
            var result = await _SinhViencService.GetByIdAsync(idsinhvien);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
