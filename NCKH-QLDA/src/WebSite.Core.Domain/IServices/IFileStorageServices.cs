using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Core.Domain.IServices
{
    public interface IFileStorageServices
    {
        string GetFileUrl(string fileName);
        Task<int> CopyFileToServer(Stream mediaBinaryStream, string fileName);
        Task<int> CopyFileToServer(IFormFile file);
        Task<string> SaveFile(IFormFile file);
        Task<int> DeleteFileAsync(string fileName);
    }
}
