using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IFileRepository
    {
        Task<SearchResult<FileViewModel>> SearchAsync(string IdFile);
        Task<List<FileViewModel>> SelectAllAsync(string IdBoMon, int FolderId);
        Task<Files> GetInfo(string id);
        Task<int> InsertAsync(Files file);
        Task<bool> CheckExistsByFolderIdName(string IdFile, int? folderId, string FileName);
    }
}
