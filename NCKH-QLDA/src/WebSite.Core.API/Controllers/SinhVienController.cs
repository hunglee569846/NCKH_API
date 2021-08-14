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
using System.IO;

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
        private readonly IBangDiemService _bangDiemService;
        public SinhVienController(ISinhVienService sinhvienService,
                                   IBangDiemService bangDiemService)
        {
            _SinhViencService = sinhvienService;
            _bangDiemService = bangDiemService;
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

        [SwaggerOperation(Summary = "Danh sach sinh viên chưa có đề tài.", Description = "Requires login verification!", OperationId = "GetSinhVienChuaDeTaiAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("GET"), Route("ChuaCoDeTai/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> GetChuaCoDeTai(string idhocky, string idmonhoc)
        {
            var result = await _SinhViencService.GetChuaDeTai(idhocky,idmonhoc,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Cập nhật đơn vị thực tập.", Description = "Requires login verification!", OperationId = "UpdateDonViAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("PUT"), Route("DonViThucTap/{idSinhVien}")]
        public async Task<IActionResult> UpdateDonViTT([FromBody] SinhVienMeta sinhvien, string idSinhVien)
        {
            var result = await _SinhViencService.UpdateAsync(CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon,idSinhVien, sinhvien);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Cập nhật danh sách đơn vị thực tập.", Description = "Requires login verification!", OperationId = "ListDonViTTAsync", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("PUT"), Route("ListDonViTTAsync/{idSinhVien}")]
        public async Task<IActionResult> UpdateDonViTT([FromBody] List<UpDateDonViTTMeta> donvithuctap)
        {
            var result = await _SinhViencService.UpdateDonViThucTap(donvithuctap,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sách sinh viên từ file Excel.", Description = "Requires login verification!", OperationId = "listSinhVien", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("POST"), Route("InsertExcel/{idfile}/{idhocky}")]
        public async Task<IActionResult> InsertlistFromExcel(string idfile, string idhocky)
        {
            var result = await _SinhViencService.InsertFromExcelAsync(idfile, idhocky, CurrentUser.MaGiangVien, CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("InsertListAsync SinhVien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sách sinh viên khởi tạo đề tài", Description = "Requires login verification!", OperationId = "DataSinhVien", Tags = new[] { "SinhVien" })]
        [AcceptVerbs("GET"), Route("DataSinhVien/{idhocky}")]
        public async Task<IActionResult> DownloadDataSinhVienAsync(string idhocky)
        {
            var stream = await _bangDiemService.XuatSinhVienExcel(idhocky, CurrentUser.IdBoMon);

            var buffer = stream as MemoryStream;

            buffer.Position = 0;
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelSinhVien.xlsx");

        }

    }
}
