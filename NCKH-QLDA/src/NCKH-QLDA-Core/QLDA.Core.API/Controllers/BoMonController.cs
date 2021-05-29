using Microsoft.AspNetCore.Mvc;
using NCKH.Core.Domain.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace QLDA.Core.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class BoMonController : ControllerBase
    {
        private readonly IBoMonService _iBoMonService;
        
        public BoMonController(IBoMonService iBoMonService)
        {
            _iBoMonService = iBoMonService;
            
        }
        [AcceptVerbs("GET"), Route("GetAll")]
        [SwaggerOperation(Summary = "SelectAll BoMon", Description = "Requires login verification!", OperationId = "GetAllBoMon", Tags = new[] { "BoMon" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _iBoMonService.SelectAllAsync();
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetByIdBoMon/{idBoMon}")]
        [SwaggerOperation(Summary = "SelectByIDlBoMon", Description = "Requires idBoMon!", OperationId = "GetByIdBoMon", Tags = new[] { "BoMon" })]
        public async Task<IActionResult> SearchByIdBoMon(string idBoMon)
        {
            var result = await _iBoMonService.SearchByIdBoMon(idBoMon);
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetByIdKhoa/{idKhoa}")]
        [SwaggerOperation(Summary = "SelectBoMonByIDlKhoa", Description = "Requires idKhoa!", OperationId = "GetByIdKhoa", Tags = new[] { "BoMon" })]
        public async Task<IActionResult> SearchByIdKhoa(string idKhoa)
        {
            var result = await _iBoMonService.SearchByIdKhoa(idKhoa);
            return Ok(result);
        }


    }

}
