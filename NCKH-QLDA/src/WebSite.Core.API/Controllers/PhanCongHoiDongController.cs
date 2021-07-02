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
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class PhanCongHoiDongController : CoreApiControllerBase
    {
        private readonly IBangDiemService _bangdiemService;
        public PhanCongHoiDongController(IBangDiemService bangdiemService)
        {
            _bangdiemService = bangdiemService;
        }

        [SwaggerOperation(Summary = "Phân công một đề tài", Description = "Requires login verification!", OperationId = "PhanCongHoiDongInsertDeTai", Tags = new[] { "PhanCongHoiDong" })]
        [AcceptVerbs("POST"), Route("PhanCongHoiDong/{iddetai}/{idGVHD}/{idhoidong}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync(string iddetai, string idGVHD, string idhoidong, string idhocky, string idmonhoc)
        {
            var result = await _bangdiemService.InsertAsync(iddetai,idGVHD,idhoidong,idhocky,idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        /// <Description>
        /// Chú ý check typeApprover 
        /// = 1 insert HD nghiem thu TN
        /// = 2 HD ĐATN
        /// </Description>
        [SwaggerOperation(Summary = "Phân công list đề tài", Description = "Requires login verification!", OperationId = "PhanCongHoiDongInsertListDeTai", Tags = new[] { "PhanCongHoiDong" })]
        [AcceptVerbs("POST"), Route("PhanCongHoiDongListDetai/{idhoidong}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InserListDeTaitAsync([FromBody]List<BangDiemlistMeta> listdetai, string idhoidong, string idhocky, string idmonhoc)
        {
            var result = await _bangdiemService.InsertListDetaiAsync(listdetai, idhoidong, idhocky, idmonhoc, CurrentUser.MaGiangVien, CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Cập nhật điểm thành phần.", Description = "Requires login verification!", OperationId = "UpdateDiemAsync", Tags = new[] { "PhanCongHoiDong" })]
        [AcceptVerbs("PUT"), Route("UpdateDiem/{idBangDiem}/{diemmso}")]
        public async Task<IActionResult> UpdateDiemAsync(string idBangDiem, float diemmso, string nhanxetGV)
        {
            var result = await _bangdiemService.UpdateDiemAsync(idBangDiem, diemmso, nhanxetGV, CurrentUser.MaGiangVien, CurrentUser.FullName, CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
