using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
	public interface IFolderServices
	{
		//Task<FolderSearchViewModel> SearchAsync(string tenantId, string userId, string keyword, int page, int pageSize);
		Task<ActionResultResponese<string>> InsertAsync(string idBoMon,string FolderName);
		//Task<ActionResultReponese<string>> UpdateAsync(string tenantId, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, int id, FolderMeta folderMeta);
		//Task<ActionResultReponese> DeleteAsync(string tenantId, string deleteUserId, string deleteFullName, string deleteAvatar, int id);
		//Task<ActionResultReponese<FolderDetailViewModel>> GetDetailAsync(string tenantId, string userId, int id);
		Task<List<Folder>> GetsAll(string IdBoMon);
		//Task<ActionResultReponese> UpdateName(string tenantId, string lastUpdateUserId, string lastUpdateFullName,
		//   int folderId, string concurrencyStamp, string name);
		//Task<List<Breadcrumb>> GetBreadcrumbs(string tenantId, string userId, int? folderId);
		//Task<List<TreeData>> GetFullTreeAsync(string tenantId, string userId);
	}
}
