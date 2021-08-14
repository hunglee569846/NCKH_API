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
        private readonly INhapDiemService _nhapDiemService;

        public DeTaiController(IDeTaiService ideTaiService,
                               INhapDiemService nhapDiemService)
        {
            _ideTaiService = ideTaiService;
            _nhapDiemService = nhapDiemService;

        }
        [AcceptVerbs("GET"), Route("GetAllByHocKy/{idhocky}")]
        [SwaggerOperation(Summary = "báo cáo danh sách đề tài của học kỳ.", Description = "Requires login verification!", OperationId = "SearchByHocKy", Tags = new[] { "DeTai" })]
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
        [SwaggerOperation(Summary = "Danh sách đề tài theo môn học", Description = "Requires login verification!", OperationId = "SearchByMonHocInHocKy", Tags = new[] { "DeTai" })]
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

        // đề tài và chi tiết đề tài trong học kỳ getall
        [AcceptVerbs("GET"), Route("GetCT/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "GetByInHocKyandMonHocAsync Detai", Description = "Requires login verification!", OperationId = "GetByInHocKyandMonHocAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> GetByInHocKyandMonHocAsync(string idhocky, string idmonhoc)
        {
            var result = await _ideTaiService.GetByIdMonHocInHocKyAsync(idhocky, idmonhoc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetPhanHoiDong/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "Danh sách đề tài chưa phân công trong môn học", Description = "Requires login verification!", OperationId = "GetPhanHoiDongAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> GetByChuaPhanHopiDongAsync(string idhocky, string idmonhoc)
        {
            var result = await _ideTaiService.GetChuaPhanHDAsync(idhocky, idmonhoc,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("InsertDeTai/{idhocky}/{idmonhoc}/{idsinhvien}")]
        [SwaggerOperation(Summary = "Thêm mới đề tài.", Description = "Requires login verification!", OperationId = "InsertAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertAsync([FromBody] DeTaiInsertMeta detaiInsertMeta , string idhocky, string idmonhoc, string idsinhvien)
        {
            var result = await _ideTaiService.InsertAsync(detaiInsertMeta, idhocky, idmonhoc, idsinhvien,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("Update/{iddetai}")]
        [SwaggerOperation(Summary = "Cập nhật thông tin đề tài.", Description = "Requires login verification!", OperationId = "UpdateAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertAsync([FromBody] DeTaiUpdateMeta detaiUpdateMeta, string iddetai)
        {
            var result = await _ideTaiService.UpdateAsync(detaiUpdateMeta, iddetai,CurrentUser.MaGiangVien,CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("UpdateDiemSX/{iddetai}/{diem}")]
        [SwaggerOperation(Summary = "Vào điểm sản xuất.", Description = "Requires login verification!", OperationId = "UpdateDiemSXAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertAsync(string iddetai, float? diem)
        {
            var result = await _ideTaiService.UpdateDiemSxAsync(iddetai,diem, CurrentUser.MaGiangVien, CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        //phê duyệt đề tài
        //[AcceptVerbs("PUT"), Route("Approve/{iddetai}/{isApprove}")]
        //[SwaggerOperation(Summary = "UpdateApproveAsync Detai", Description = "Requires login verification!", OperationId = "UpdateApproveAsync", Tags = new[] { "DeTai" })]
        //public async Task<IActionResult> UpdateApproveAsync(string iddetai, bool isApprove)
        //{
        //    var result = await _ideTaiService.UpdateAproveAsync(iddetai, isApprove);
        //    if (result.Code <= 0)
        //    {
        //        //_logger.LogError("Search DeTai controller error " + result.Code);
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}

        [AcceptVerbs("DELETE"), Route("Delete/{iddetai}")]
        [SwaggerOperation(Summary = "Xóa đề tài.", Description = "Requires login verification!", OperationId = "DeleteAsync", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> DeleteAsync(string iddetai)
        {
            var result = await _ideTaiService.DeleteAsync(iddetai,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("PUT"), Route("UpdateDiemTBC/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "Cập nhật điểm chung bình chung cho đề tài.", Description = "Requires login verification!", OperationId = "UpdatePointAGV", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> DeleteAsync(string idhocky, string idmonhoc)
        {
            var result = await _nhapDiemService.ChungBinhDiem(idhocky, idmonhoc, CurrentUser.IdBoMon,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("PhanPhanBien/{idhocky}/{idmonhoc}/{IdGVHD}")]
        [SwaggerOperation(Summary = "Danh sách đề tài phân phản biện.", Description = "Requires login verification!", OperationId = "DeTaiPhanPhanBien", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> DeTaiPhanPhanBien(string idhocky, string idmonhoc,string IdGVHD)
        {
            var result = await _ideTaiService.DeTaiPhanPhanBien(idhocky, idmonhoc, CurrentUser.IdBoMon, IdGVHD);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("Detai/{idfile}/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "Thêm mới đề tài từ Excel.", Description = "Requires login verification!", OperationId = "InsertDeTaiFromExcel", Tags = new[] { "DeTai" })]
        public async Task<IActionResult> InsertDeTaiFromExcel(string idfile, string idhocky, string idmonhoc)
        {
            var result = await _ideTaiService.InsertFromExcelAsync(idfile,idhocky, idmonhoc, CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
