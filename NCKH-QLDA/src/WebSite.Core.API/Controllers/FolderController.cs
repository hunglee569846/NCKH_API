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
    [Route("api/[Controller]")]
    [SwaggerTag("Insert, Update, Delete, Get Detail, Search Folders")]
    public class FolderController : ControllerBase
    {
        private readonly IFolderServices _folderService;
        //private readonly IFileService _fileService;
        public FolderController(IFolderServices folderservice)
        {
            _folderService = folderservice;
        }

        [Route("Insert/{FolderName}/{FolderId}"), AcceptVerbs("POST")]
        [SwaggerOperation(Summary = "Insert information folder.", Description = "Requires login verification!", OperationId = "InsertFolder", Tags = new[] { "Folder" })]
        public async Task<IActionResult> InsertAsync(string FolderName, int FolderId, [FromBody] FolderMeta folderMeta)
        {
            var result = await _folderService.InsertAsync(FolderName, FolderId, folderMeta);
            if (result.Code <= 0)
                return BadRequest(result);
            return Ok(result);
        }

        [Route("SelectAll"), AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "SelectAll information folder.", Description = "Requires login verification!", OperationId = "SelectAllFolder", Tags = new[] { "Folder" })]
        public async Task<IActionResult> GetAlltAsync()
        {
            var result = await _folderService.GetsAll();
            return Ok(result);
        }
    }
}
