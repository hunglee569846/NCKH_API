﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Domain.IRepository
{
    public interface IFolderRepository
    {
        Task<int> InsertAsync(string FolderName,Folder folder);
        Task<bool> CheckExitsFolder(int FolderId);
        Task<Folder> GetInfoAsync(int FolderId);
        Task<List<Folder>> SelectAllAsync(string IdBoMon);
        // Task<bool> CheckExistsByFolderIdName(string FolderId, )
    }
}
