using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NCKH.Infrastruture.Binding.Extensions;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFolderRepository _folderRepository;
        private readonly IGiangVienHuongDanRepository _giangVienHuongDanRepository;
        public FileService(IFileRepository fileRepository, IFolderRepository folderRepository, IWebHostEnvironment WebHostEnvironment, IGiangVienHuongDanRepository giangVienHuongDanRepository)
        {
            _fileRepository = fileRepository;
            _folderRepository = folderRepository;
            _giangVienHuongDanRepository = giangVienHuongDanRepository;
            _webHostEnvironment = WebHostEnvironment;
        }

        public async Task<SearchResult<FileViewModel>> SearchAsync(string IdFile)
        {
            return await _fileRepository.SearchAsync(IdFile);
        }
        public async Task<List<FileViewModel>> GetsAll(string IdBoMon, int FolderId)
        {
            return await _fileRepository.SelectAllAsync(IdBoMon, FolderId);
        }
        
        public async Task<ActionResultResponese<List<FileViewModel>>> UploadFiles(string idBoMon, string creatorUserId, string CreatorFullName , int? folderId, IFormFileCollection formFileCollection)
        {
            if(formFileCollection.Count() == 0)
                return new ActionResultResponese<List<FileViewModel>>(-3, "Vui lòng chọn file.");
            Folder folderInfo = null;
            if (folderId.HasValue)
            {
                folderInfo = await _folderRepository.GetInfoAsync(folderId.Value);
                if (folderInfo == null)
                    return new ActionResultResponese<List<FileViewModel>>(-1, "Folder không tồn tại. Bạn cần cập nhật thông tin folder.");
                //_ghmFileResource.GetString("Folder does not exists. You can not update file to this folder."));
            }

            List<Files> listFiles = new List<Files>();
            string uploadUrl = string.Format("/uploadsAPIQLDA/" + folderInfo.FolderName?.Trim() + "/{0:yyyy/MM/dd}/", DateTime.Now);
            foreach (IFormFile formFile in formFileCollection)
            {
                var id = Guid.NewGuid().ToString("n");
                string urlOutPut = $"{uploadUrl}{id}.{formFile.GetExtensionFile()}";
                string uploadPath = $"{CreateFolder()}{id}.{formFile.GetExtensionFile()}";
                string uploadPathBackup = $"{CreateFolderBackUp()}{id}.{formFile.GetExtensionFile()}";
                var type = formFile.GetTypeFile();
                var isImage = type.Contains("image/");

                var isNameExit = await _fileRepository.CheckExistsByFolderIdName(id, folderId, formFile.FileName?.Trim());
                if (isNameExit)
                    continue;

                await CopyFileToServer(formFile, uploadPathBackup, isImage);
                var resultCopyFile = await CopyFileToServer(formFile, uploadPath, isImage);
                if (resultCopyFile == -1)
                    continue;

                var file = new Files
                {
                    Id = id,
                   // FileCode = fileCode,
                    IdBoMon = idBoMon?.Trim(),
                    FileName = formFile.FileName?.Trim(),
                    Type = formFile.GetTypeFile(),
                    Size = formFile.GetFileSize(),
                    Url = urlOutPut,
                    CreatorUserId = creatorUserId?.Trim(),
                    CreatorFullName = CreatorFullName?.Trim(),
                    Folderld = folderInfo.Id,
                    CreateDate = DateTime.Now,
                    DeleteTime = null,
                    LastUpdate = null,
                    IsActive = true,
                    IsDelete = false

                };

                // Add file info to list for insert into database.
                await _fileRepository.InsertAsync(file);
                listFiles.Add(file);
            }

            return new ActionResultResponese<List<FileViewModel>>
            {
                Code = 1,
                Message = "Upload file successful",
                Data = listFiles.Select(x => new FileViewModel
                {
                    IdFile = x.Id,
                    FileName = x.FileName,
                    FolderId = x.Folderld,
                    Size = x.Size,
                    Type = x.Type,
                    Url = x.Url,
                    CreateDate = x.CreateDate,
                    CreatorUserId = x.CreatorUserId,
                }).ToList()
            };

            string CreateFolder()
            {
                var mapPath = string.Format(_webHostEnvironment.ContentRootPath + uploadUrl);
                if (!Directory.Exists(mapPath))
                    Directory.CreateDirectory(mapPath);
                return mapPath;
            }

            string CreateFolderBackUp()
            {
                var mapPath = string.Format("D:/BackUpAPIQLDA" + uploadUrl);
                if (!Directory.Exists(mapPath))
                    Directory.CreateDirectory(mapPath);

                return mapPath;
            }

            async Task<int> CopyFileToServer(IFormFile file, string uploadPath, bool isImage = false)
            {
                if (System.IO.File.Exists(uploadPath))
                    return -1;

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return 1;
            }
        }

        public async Task<ActionResultResponese<string>> DownloadAsync(string id)
        {
            var info = await _fileRepository.GetInfo(id);
            if (info == null)
                return new ActionResultResponese<string>(-2, "File không tồn tại.", "File");

            var mapPath = _webHostEnvironment.ContentRootPath + info.Url;
            if (!System.IO.File.Exists(mapPath))
                return new ActionResultResponese<string>(-5, "Tải thất bại","file.");

            return new ActionResultResponese<string>(1, "Tải xuống thành công.", info.Id, mapPath);
        }

        public async Task<Stream> GioGiangDayExcel(string idhocky, string idBoMon)
        {
            List<ThongKeGiangVienViewModel> thongkegiangvien = await _giangVienHuongDanRepository.ThongKeGiangVien(idhocky,idBoMon);
            var createEx = new CreateExcelExtensions();
            var stream = createEx.CreateExcel(thongkegiangvien, "ThoiGianGiangDay");
            return stream;

        }
    }
}
