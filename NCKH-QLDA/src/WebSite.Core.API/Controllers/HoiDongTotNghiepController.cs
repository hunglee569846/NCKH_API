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
        public HoiDongTotNghiepController(IHoiDongTotNghiepService hoiDongTotNghiepService)
        {
            _hoiDongTotNghiepService = hoiDongTotNghiepService;
        }

        [SwaggerOperation(Summary = "Danh sach hội đồng theo hoc kỳ.", Description = "Requires login verification!", OperationId = "GetHoiDongTotNghiepAsync", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("GET"), Route("GetAllHoiDong/{idhocky}")]
        public async Task<IActionResult> GetAllAsync(string idhocky)
        {
            var result = await _hoiDongTotNghiepService.GetByIdHocKy(idhocky,CurrentUser.IdBoMon);
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
    }
}

