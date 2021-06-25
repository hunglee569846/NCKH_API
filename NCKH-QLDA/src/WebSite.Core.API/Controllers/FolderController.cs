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
    [Route("api/[Controller]")]
    [SwaggerTag("Insert, Update, Delete, Get Detail, Search Folders")]
    public class FolderController : CoreApiControllerBase
    {
        private readonly IFolderServices _folderService;
        //private readonly IFileService _fileService;
        public FolderController(IFolderServices folderservice)
        {
            _folderService = folderservice;
        }

        [Route("Insert/{FolderName}"), AcceptVerbs("POST")]
        [SwaggerOperation(Summary = "Tạo mới folder.", Description = "Requires login verification!", OperationId = "InsertFolder", Tags = new[] { "Folder" })]
        public async Task<IActionResult> InsertAsync(string FolderName)
        {
            var result = await _folderService.InsertAsync(CurrentUser.IdBoMon,FolderName);
            if (result.Code <= 0)
                return BadRequest(result);
            return Ok(result);
        }

        [Route("SelectAll"), AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "Danh sach folder.", Description = "Requires login verification!", OperationId = "SelectAllFolder", Tags = new[] { "Folder" })]
        public async Task<IActionResult> GetAlltAsync()
        {
            var result = await _folderService.GetsAll(CurrentUser.IdBoMon);
            return Ok(result);
        }
    }
}
