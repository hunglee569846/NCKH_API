using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class HoiDongTotNghiepController : ControllerBase
    {
        private readonly IHoiDongTotNghiepService _hoiDongTotNghiepService;
        public HoiDongTotNghiepController(IHoiDongTotNghiepService hoiDongTotNghiepService)
        {
            _hoiDongTotNghiepService = hoiDongTotNghiepService;
        }

        [SwaggerOperation(Summary = "GetAllHoiDong", Description = "Requires login verification!", OperationId = "GetHoiDongTotNghiepAsync", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("GET"), Route("GetAllHoiDong/{idhocky}")]
        public async Task<IActionResult> GetAllAsync(string idhocky)
        {
            var result = await _hoiDongTotNghiepService.GetByIdHocKy(idhocky);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "InsertHoiDong", Description = "Requires login verification!", OperationId = "InsertHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("POST"), Route("InsertHoiDong/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync([FromBody]HoiDongTotNghiepMeta hoidongMeta, string idhocky, string idmonhoc)
        {
            var result = await _hoiDongTotNghiepService.InsertAsync(hoidongMeta, idhocky, idmonhoc);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "UpdateHoiDong", Description = "Requires login verification!", OperationId = "UpdateHoiDong", Tags = new[] { "HoiDongTotNghiep" })]
        [AcceptVerbs("PUT"), Route("UpdateHoiDong/{idhoidong}/{idhocky}")]
        public async Task<IActionResult> UpdateAsync([FromBody] HoiDongTotNghiepMeta hoidongMeta, string idhoidong, string idhocky)
        {
            var result = await _hoiDongTotNghiepService.UpdateAsync(hoidongMeta, idhoidong, idhocky);
            return Ok(result);
        }
    }
}

