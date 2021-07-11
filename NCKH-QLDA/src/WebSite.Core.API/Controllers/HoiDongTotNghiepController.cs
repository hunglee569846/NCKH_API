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
    public class HoiDongTotNghiepController : CoreApiControllerBase
    {
        private readonly IHoiDongTotNghiepService _hoiDongTotNghiepService;
        private readonly IBangDiemService _bangdiemService;
        private readonly INhapDiemService _nhapdiemService;
        public HoiDongTotNghiepController(IHoiDongTotNghiepService hoiDongTotNghiepService,
                                          IBangDiemService bangdiemService,
                                          INhapDiemService nhapdiemService)
        {
            _hoiDongTotNghiepService = hoiDongTotNghiepService;
            _bangdiemService = bangdiemService;
            _nhapdiemService = nhapdiemService;
        }

        [SwaggerOperation(Summary = "Danh sach hội đồng theo hoc kỳ.", Description = "Requires login verification!", OperationId = "GetHoiDongTotNghiepAsync", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("GET"), Route("GetAllHoiDong/{idhocky}")]
        public async Task<IActionResult> GetAllAsync(string idhocky)
        {
            var result = await _hoiDongTotNghiepService.GetByIdHocKy(idhocky,CurrentUser.IdBoMon);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sach hội đồng theo môn học của hoc kỳ.", Description = "Requires login verification!", OperationId = "GetHoiDongTotNghiepByMonHocAsync", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("GET"), Route("GetAllHoiDong/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> GetByMonHoc(string idhocky,string idmonhoc)
        {
            var result = await _hoiDongTotNghiepService.GetByIdMonHoc(idhocky, idmonhoc, CurrentUser.IdBoMon);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Thêm mới một hội đồng.", Description = "Requires login verification!", OperationId = "InsertHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("POST"), Route("InsertHoiDong/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync([FromBody]HoiDongTotNghiepMeta hoidongMeta, string idhocky, string idmonhoc)
        {
            var result = await _hoiDongTotNghiepService.InsertAsync(hoidongMeta, idhocky, idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Cập nhật thông tin hội đồng.", Description = "Requires login verification!", OperationId = "UpdateHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("PUT"), Route("UpdateHoiDong/{idhoidong}/{idhocky}/{idMonHoc}")]
        public async Task<IActionResult> UpdateAsync([FromBody] HoiDongTotNghiepMeta hoidongMeta, string idhoidong, string idhocky, string idMonHoc)
        {
            var result = await _hoiDongTotNghiepService.UpdateAsync(hoidongMeta, idhoidong, idhocky, idMonHoc, CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            return Ok(result);
        }
        
        [SwaggerOperation(Summary = "Xóa hội đồng.", Description = "Requires login verification!", OperationId = "DeleteHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("DELETE"), Route("DeleteHoiDongAsync/{idhoidong}")]
        public async Task<IActionResult> DeleteAsync(string idhoidong)
        {
            var result = await _hoiDongTotNghiepService.DeleteAsync(idhoidong);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Search Hội đồng theo ngày bảo vệ tu ngay den ngay", Description = "Requires login verification!", OperationId = "SearchHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("GET"), Route("SearchHoiDong/{NgayBatDau}/{NgayKetThuc}")]
        public async Task<IActionResult> SearchHoiDong(DateTime NgayBatDau,DateTime NgayKetThuc)
        {
            var result = await _hoiDongTotNghiepService.SearchHoiDongNgayBaoVe(CurrentUser.IdBoMon,NgayBatDau,NgayKetThuc);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Vào điểm hội đồng bằng file excel", Description = "Requires login verification!", OperationId = "UpdateDiemFileExcel", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("POST"), Route("DiemHoiDong/{idfile}/{idmonhoc}")]
        public async Task<IActionResult> UpdateDiemFileExcel(string idfile, string idmonhoc)
        {
            var result = await _nhapdiemService.InsertDiemHoiDongExcelAsync(idfile, idmonhoc, CurrentUser.IdBoMon, CurrentUser.MaGiangVien, CurrentUser.FullName);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search PhanBien controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

