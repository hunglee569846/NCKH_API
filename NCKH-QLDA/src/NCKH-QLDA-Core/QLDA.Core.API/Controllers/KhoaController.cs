using Microsoft.AspNetCore.Mvc;
using NCKH.Core.Domain.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDA.Core.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Insert, Update, Delete, GetAll")]
    public class KhoaController : ControllerBase
    {
        private readonly IkhoaService _ikhoaService;
        public KhoaController(IkhoaService ikhoaService)
        {
            _ikhoaService = ikhoaService;
        }
        [AcceptVerbs("GET"), Route("GetAll")]
        [SwaggerOperation(Summary = "SelectAll Khoas", Description = "Requires login verification!", OperationId = "GetAllKhoas", Tags = new[] { "Khoas" })]
        public async Task<IActionResult> SelectAllAsync()
        {
            var result = await _ikhoaService.SelectAllAsync();
            return Ok(result);
        }

        [AcceptVerbs("GET"), Route("GetById/{idKhoa}")]
        [SwaggerOperation(Summary = "SelectByIdKhoas", Description = "Requires idkhoa!", OperationId = "GetByIdKhoas", Tags = new[] { "Khoas" })]
        public async Task<IActionResult> SelectByIdAsync(string idKhoa)
        {
            var result = await _ikhoaService.SelectByIdAsync(idKhoa);
            return Ok(result);
        }


        //[AcceptVerbs("POST"), Route("post/{ClassName}/{idClass}")]
        //[SwaggerOperation(Summary = "post Department User", Description = "Requires login verification!", OperationId = "Post-ClasSpecialized", Tags = new[] { "ClasSpecialized" })]
        //public async Task<IActionResult> InsertAsync(string ClassName, string idClass, ClassMeta clas)
        //{
        //    var result = await _iclassService.InsertAsync(ClassName, idClass, clas);
        //    return Ok(result);
        //}


        //[AcceptVerbs("PUT"), Route("Update/{id}/{idClass}/{className}")]
        //[SwaggerOperation(Summary = "Update Department User", Description = "Requires login verification!", OperationId = "Update-ClasSpecialized", Tags = new[] { "ClasSpecialized" })]
        //public async Task<IActionResult> UpdateAsync(string id, string idClass, string className, ClassMeta clas)
        //{
        //    var result = await _iclassService.UpdateAsync(id, idClass, className, clas);
        //    return Ok(result);
        //}

        //[AcceptVerbs("DELETE"), Route("Delete/{id}/{idclass}")]
        //[SwaggerOperation(Summary = "DELETE Department User", Description = "Requires login verification!", OperationId = "DELETE-ClasSpecialized", Tags = new[] { "ClasSpecialized" })]
        //public async Task<IActionResult> DeleteAsync(string id, string idclass)
        //{
        //    var result = await _iclassService.DeleteAsync(id, idclass);
        //    return Ok(result);
        //}

    }
}
