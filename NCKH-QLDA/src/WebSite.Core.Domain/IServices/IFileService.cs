using Microsoft.AspNetCore.Http;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IFileService
    {
        
        //string FileCode, string creatorUserId,string CreatorFullName, string FolderName, int? folderId, IFormFileCollection formFileCollection
        Task<ActionResultResponese<List<FileViewModel>>> UploadFiles(string idBoMon,string creatorUserId, string CreatorFullName, int? folderId, IFormFileCollection formFileCollection);
        Task<SearchResult<FileViewModel>> SearchAsync(string IdFile);
        //Task<ActionResultReponese<string>> UpdateAsync(string tenantId, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string id, FileMeta fileMeta);
        //Task<ActionResultReponese> DeleteAsync(string tenantId, string deleteUserId, string deleteFullName, string deleteAvatar, string id);
        //Task<ActionResultReponese<FileDetailViewModel>> GetDetailAsync(string tenantId, string userId, string id);
        Task<List<FileViewModel>> GetsAll(string IdBoMon, int FolderId);
        Task<ActionResultResponese<string>> DownloadAsync(string id);

        //Xuat thong ke giang vien
        Task<Stream> GioGiangDayExcel(string idhocky, string idBoMonc);
    }
}
