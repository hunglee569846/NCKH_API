using Core.Domain.ModelMeta;
using Core.Domain.Models;
using Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Constans;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.IServices
{
   public interface IUserAccountService
    {
        Task<ActionResultResponese<string>> InsertAsync(UserAccountInsertMeta userAccountMeta,string userId,string fullName,UserType permission,string userName);
        //Task<SearchResult<UserAccountViewModel>> SearchAsync(string tenantId, UserType type, bool? isActive, string keyword, int page, int pageSize);
        
        //Task<ActionResultResponese> DeleteAsync(string tenantId, string id);
        //Task<ActionResultResponese> ForceDeleteAsync(string tenantId, string id);
        Task<ActionResultResponese> ResetLockoutAsync(string idKhoa, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string userName, UserType type);
        //Task<ActionResultResponese> LockAccountAsync(string tenantId, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string userName, UserType type);
        //Task<ActionResultResponese> UpdateIsActiveAsync(string tenantId, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string userName, UserType type, bool isActive);
        int UpdateAccessFailCount(string idKhoa, string userName, UserType type, int failCount, bool lockoutOnFailure = false);
        
        Task<ActionResultResponese> ResetPasswordAsync(string tenantId, string lastUpdateUserId, string lastUpdateFullName, string lastUpdateAvatar, string userName, UserType type, string pwd);
        Task<ActionResultResponese> UpdatePasswordAsync(string userId, string lastUpdateUserId, string lastUpdateFullName, UpdatePasswordMeta updatePasswordMeta);
        Task<SearchResult<TaiKhoanViewModel>> GetTaiKhoanByBoMon(string idBoMon);
        //Task<List<UserAccountViewModel>> GetShortUserInfoByListUserId(string tenantId, List<string> userIds);
        //Task<ActionResultResponese<string>> CheckExitUserNameAsync(string domain, string userName, UserType type);
        //Task<ActionResultResponese> SentEmailCodeAsync(string domain, string userName, UserType type);
        //Task<ActionResultResponese> ComfirmEmailCodeAsync(string domain, string userName, string code, string pwd, UserType type);
        //Task<string> GetDetailAdminAsync(string id);
    }
}
