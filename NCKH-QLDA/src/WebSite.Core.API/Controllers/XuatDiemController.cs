using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class XuatDiemController : CoreApiControllerBase
    {
        private readonly IBangDiemService _bangdiemService;
        public XuatDiemController(IBangDiemService bangdiemService)
        {
            _bangdiemService = bangdiemService;
        }

        [SwaggerOperation(Summary = "Danh sách điểm phản biện", Description = "Requires login verification!", OperationId = "SerchDiemPhanBien", Tags = new[] { "XuatDiem" })]
        [AcceptVerbs("GET"), Route("DiemPhanBien/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> XuatDiemPhanBien(string idhocky,string idmonhoc)
        {
            var result = await _bangdiemService.XuatDiemPhanBien(idhocky,idmonhoc,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Danh sách điểm hội đồng", Description = "Requires login verification!", OperationId = "SearchDiemHoiDong", Tags = new[] { "XuatDiem" })]
        [AcceptVerbs("GET"), Route("DiemHoiDong/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> XuatDiemHoiDong(string idhocky, string idmonhoc)
        {
            var result = await _bangdiemService.XuatDiemHoiDong(idhocky, idmonhoc,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
