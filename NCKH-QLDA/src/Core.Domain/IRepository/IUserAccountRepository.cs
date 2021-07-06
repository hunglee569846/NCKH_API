using Core.Domain.Models;
using Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Constans;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.IRepository
{
    public interface IUserAccountRepository
    {
        //Task<SearchResult<UserAccountViewModel>> SearchAsync(string tenantId, UserType type, bool? isActive, string keyword, int page, int pageSize);
        //Task<List<UserAccountViewModel>> SelectAllAsync(string tenantId);

        //Task<BriefUser> GetCurrentUserAsync(string id);

        Task<int> InsertAsync(UserAccount userAccount);

        //Task<int> UpdateAsync(UserAccount userAccount);

        //Task<int> DeleteAsync(string id);

        //Task<int> ForceDeleteAsync(string id);

        Task<UserAccount> GetInfoAsync(string id);

        Task<UserAccount> GetInfoAsync(string tenantId, string id);

        //Task<bool> CheckExistUserIdAsync(string id);

        //Task<bool> CheckExistUserIdByTenantIdAsync(string tenantId, string id);

        //Task<UserAccount> GetAccountInfoByUserNameAsync(string tenantId, string userName, UserType type);

        Task<UserAccount> GetInfoByUserNameAsync(string idAccount,string userName);//(string idKhoa, string userName, UserType type);

        //Task<bool> CheckUserNameExistsAsync(string id, string tenantId, string userName, UserType type);

        //Task<bool> CheckEmailExistsAsync(string id, string tenantId, string email, UserType type);
        Task<string> GetidKhoaByDomainAsync(string userName);
        Task<int> Update_LockAndResetAsync(UserAccount userAccount);

        //Task<int> Update_IsActiveAsync(UserAccount userAccount);

        Task<int> Update_PasswordAsync(UserAccount userAccount);

        //Task<bool> CheckExisTenantIdAsync(string tenantId);

       Task<bool> CheckIsAdminAsync(string id);
       Task<SearchResult<TaiKhoanViewModel>> GetTaiKhoanByBoMon(string idBoMon);

        //Task<int> SentEmailCodeAsync(UserAccount userAccount);
    } 
}
