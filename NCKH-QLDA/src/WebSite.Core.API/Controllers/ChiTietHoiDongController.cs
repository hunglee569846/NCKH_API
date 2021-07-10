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
    public class ChiTietHoiDongController : CoreApiControllerBase
    {
        private readonly IChiTietHoiDongService _ChitietHoiDongService;

        public ChiTietHoiDongController(IChiTietHoiDongService chitietHoiDongService)
        {
            _ChitietHoiDongService = chitietHoiDongService;

        }
        [AcceptVerbs("GET"), Route("GetAllThanhVien/{idHoiDong}")]
        [SwaggerOperation(Summary = "Danh sách thành viên hội đồng", Description = "Requires login verification!", OperationId = "SearchByIdBoHoiDong", Tags = new[] { "ChiTietHoiDong" })]
        public async Task<IActionResult> GetAllByHocKyAsync(string idHoiDong)
        {
            var result = await _ChitietHoiDongService.SelectByIdHoiDongAsync(idHoiDong);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("InsertListChiTietHoiDong/{idhoidong}/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "Thêm mới danh sách thanh viên một hội đồng.", Description = "Requires login verification!", OperationId = "InsertListChiTietHoiDong", Tags = new[] { "ChiTietHoiDong" })]
        public async Task<IActionResult> InsertListChiTietHoiDongAsync([FromBody] List<ChiTietHoiDongMeta> listchitiethoidong, string idhoidong,string idhocky,string idmonhoc)
        {
            var result = await _ChitietHoiDongService.InserListDeTaiAsync(listchitiethoidong, idhoidong,idhocky,idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("POST"), Route("InsertChiTietHoiDong/{idhoidong}/{idgiangvien}/{idhocky}/{idmonhoc}")]
        [SwaggerOperation(Summary = "thêm mới một thành viên hội đồng.", Description = "Requires login verification!", OperationId = "InsertChiTietHoiDong", Tags = new[] { "ChiTietHoiDong" })]
        public async Task<IActionResult> InsertAsync(string idgiangvien, string idhoidong, string idhocky, string idmonhoc)
        {
            var result = await _ChitietHoiDongService.InserAsync(idhoidong,idgiangvien,idhocky,idmonhoc, CurrentUser.MaGiangVien, CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [AcceptVerbs("DELETE"), Route("DeleteChiTietHoiDong/{idchitietHD}")]
        [SwaggerOperation(Summary = "xóa thành viên hội đồng.", Description = "Requires login verification!", OperationId = "DeleteChiTietHoiDong", Tags = new[] { "ChiTietHoiDong" })]
        public async Task<IActionResult> DeleteChiTietHoiDongAsync(string idchitietHD)
        {
            var result = await _ChitietHoiDongService.DeleteAsync(idchitietHD);
            if (result.Code <= 0)
            {
                //_logger.LogError("Search DeTai controller error " + result.Code);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
