using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Services
{
    public class FolderService : IFolderServices
    {
        private readonly IFolderRepository _iFolderRepository;
        public FolderService(IFolderRepository iFolderRepository)
        {
            _iFolderRepository = iFolderRepository;
        }

        public async Task<ActionResultResponese<string>> InsertAsync(string idBoMon,string FolderName)
        {
            //var isFolderID = await _iFolderRepository.CheckExitsFolder(folderId);
            //if (isFolderID)
            //    return new ActionResultResponese<string>(-21, "FolderId already exists", "Folder", null);
            var folder = new Folder()
            {
                //FolderId = folderId,
                FolderName = FolderName,
                IdBoMon = idBoMon?.Trim(),
               // NamePath = folderMeta.NamePath?.Trim(),
               // Level = folderMeta.Level,
               // ChildCount = folderMeta.ChildCount,
              //  Description = folderMeta.Description?.Trim(),
                CreateTime = DateTime.Now,
                DeleteTime = null,
                LastUpdate = null,
                IsActive = true,
                IsDelete = false,
            };
            var result = await _iFolderRepository.InsertAsync(folder);
            if (result <= 0)
                return new ActionResultResponese<string>(-1, "Thêm mới thất bại", "Folder", null);
            return new ActionResultResponese<string>(result, "Thêm mới thành công", "Folder", null);
        }

        public async Task<List<Folder>> GetsAll(string idBoMon)
        {
            return await _iFolderRepository.SelectAllAsync(idBoMon);
        }
    }
}
