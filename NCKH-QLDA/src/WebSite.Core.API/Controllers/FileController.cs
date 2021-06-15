﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.IServices;

namespace WebSite.Core.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [SwaggerTag("Insert, Update, Delete, Get Detail, Search Folders")]
    public class FileController : CoreApiControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IBangDiemService _bangdiemService;
        //private readonly IFileService _fileService;
        public FileController(IFileService fileservice,
                              IBangDiemService bangdiemService)
        {
            _fileService = fileservice;
            _bangdiemService = bangdiemService;
        }
        [Route("SearchID/IdPath/FolderName/FolderId"), AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "SearchAll information File.", Description = "Requires login verification!", OperationId = "SearchById", Tags = new[] { "File" })]
        public async Task<IActionResult> SearchAsync(string IdFile)
        {
            var result = await _fileService.SearchAsync(IdFile);
            return Ok(result);
        }
        [Route("SearchAll/FolderName/FolderId"), AcceptVerbs("GET")]
        [SwaggerOperation(Summary = "SearchAll information File.", Description = "Requires login verification!", OperationId = "SearchAll", Tags = new[] { "File" })]
        public async Task<IActionResult> GetsAllAsync(string FileName, int FolderId)
        {
            var result = await _fileService.GetsAll(FileName, FolderId);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Upload file.", Description = "Requires login verification!", OperationId = "UploadFile", Tags = new[] { "File" })]
        [HttpPost, DisableRequestSizeLimit]
        [Route("uploads"), AcceptVerbs("POST")]
        public async Task<IActionResult> UploadFileAsync(string FileCode, string FolderName, int folderId, IFormFileCollection formFileCollection)
        {
            var result = await _fileService.UploadFiles(FileCode,CurrentUser.MaGiangVien,CurrentUser.FullName, FolderName, folderId, formFileCollection);
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Download file information file.", Description = "Requires login verification!", OperationId = "DownloadFile", Tags = new[] { "File" })]
        [Route("downloads/{id}"), AcceptVerbs("GET")]
        public async Task<IActionResult> DownloadAsync(string id)
        {
            var result = await _fileService.DownloadAsync(id);
            if (result.Code <= 0)
            {
               // _logger.LogError("Download file controller code: " + result.Code + " .Message: " + result.Message);
                return BadRequest(result);
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(result.Data, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(result.Data), Path.GetFileName(result.Data));

        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        [SwaggerOperation(Summary = "downloadsDiemPhanBien file information file.", Description = "Requires login verification!", OperationId = "downloadsDiemPhanBien", Tags = new[] { "File" })]
        [Route("downloadsDiemPhanBien/{idhocky}/{idmonhoc}"), AcceptVerbs("GET")]
        public async Task<IActionResult> DownloadDiemPhanBienAsync(string idhocky, string idmonhoc)
        {
            var stream = await _bangdiemService.XuatBangDiemExcel(idhocky, idmonhoc);

            var buffer = stream as MemoryStream;

            buffer.Position = 0;
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelDiemPhanBien.xlsx");

        }

        [SwaggerOperation(Summary = "downloadsDiemHoiDong file information file.", Description = "Requires login verification!", OperationId = "downloadsDiemHoiDong", Tags = new[] { "File" })]
        [Route("downloadsDiemHoiDong/{idhocky}/{idmonhoc}"), AcceptVerbs("GET")]
        public async Task<IActionResult> DownloadDiemHoiDongAsync(string idhocky, string idmonhoc)
        {
            var stream = await _bangdiemService.XuatHoiDongExcel(idhocky, idmonhoc);

            var buffer = stream as MemoryStream;

            buffer.Position = 0;
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelDiemHoiDong.xlsx");

        }
    }
}
