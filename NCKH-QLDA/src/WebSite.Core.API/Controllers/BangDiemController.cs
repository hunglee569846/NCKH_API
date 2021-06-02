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
using WebSite.Core.Domain.Models;

namespace WebSite.Core.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class BangDiemController : CoreApiControllerBase
    {
        private readonly IBangDiemService _bangdiemService;
        public BangDiemController(IBangDiemService bangdiemService)
        {
            _bangdiemService = bangdiemService;
        }

        [SwaggerOperation(Summary = "InsertAsyncBangDiem", Description = "Requires login verification!", OperationId = "InsertAsyncBangDiem", Tags = new[] { "BangDiem" })]
        [AcceptVerbs("POST"), Route("ChiTietDeTai/{iddetai}/{idGVHD}/{idhoidong}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync(string iddetai, string idGVHD, string idhoidong, string idhocky, string idmonhoc)
        {
            var result = await _bangdiemService.InsertAsync(iddetai,idGVHD,idhoidong,idhocky,idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
