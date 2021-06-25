using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
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
    public class ChiTietDeTaiController : CoreApiControllerBase
    {
        private readonly IChiTietDeTaiService _chitietdetaiService;
        public ChiTietDeTaiController(IChiTietDeTaiService chitietdetaiService)
        {
            _chitietdetaiService = chitietdetaiService;
        }
        
        [SwaggerOperation(Summary = "Thêm mới một hướng dẫn đề tài.", Description = "Requires login verification!", OperationId = "InsertAsyncChiTietDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("POST"), Route("ChiTietDeTai/{iddetai}/{idGVHD}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertAsync(ChiTietDeTaiMeta chitietdetai,string iddetai,string idGVHD,string idhocky,string idmonhoc)
        {
            var result = await _chitietdetaiService.InserAsync(chitietdetai, iddetai, idGVHD,idhocky,idmonhoc,CurrentUser.MaGiangVien,CurrentUser.FullName,CurrentUser.IdBoMon);
            if(result.Code <= 0)
            {
               return BadRequest(result);
            }
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Phân hướng dân theo list đề tài.", Description = "Requires login verification!", OperationId = "InsertAsyncListChiTietDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("POST"), Route("ListChiTietDeTai/{idGVHD}/{idhocky}/{idmonhoc}")]
        public async Task<IActionResult> InsertListChitietDTAsync([FromBody]List<ChiTietDeTaiListDeTaiMeta> listchitietdetai,string idGVHD, string idhocky, string idmonhoc)
        {
            var result = await _chitietdetaiService.InserListDeTaiAsync(listchitietdetai, idGVHD,idhocky,idmonhoc, CurrentUser.MaGiangVien, CurrentUser.FullName,CurrentUser.IdBoMon);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [SwaggerOperation(Summary = "chi tiết theo id đề tài.", Description = "Requires login verification!", OperationId = "SerchByIdDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("GET"), Route("SerchByIdDeTai/{iddetai}")]
        public async Task<IActionResult> SearchAsync(string iddetai)
        {
            var result = await _chitietdetaiService.SelectByDeTaiAsync(iddetai);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [SwaggerOperation(Summary = "xóa chi tiết đề tài", Description = "Requires login verification!", OperationId = "DeleteIdDeTai", Tags = new[] { "ChiTietDeTai" })]
        [AcceptVerbs("DELETE"), Route("Delete/{idChiTietDeTai}")]
        public async Task<IActionResult> DeleteAsync(string idChiTietDeTai)
        {
            var result = await _chitietdetaiService.DeleteAsync(idChiTietDeTai);
            if (result.Code <= 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        
    }
}
