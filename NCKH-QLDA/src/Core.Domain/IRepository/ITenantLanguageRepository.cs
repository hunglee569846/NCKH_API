using Core.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.IRepository
{
    public interface ITenantLanguageRepository
    {
        Task<List<TenantLanguageViewModel>> SelectAllByTenantIdAsync(string tenantId);
        //Task<int> InsertAsync(TenantLanguage tenantLanguage);
        //Task<int> UpdateAsync(TenantLanguage tenantLanguage);
        //Task<int> ForceDeleteAsync(string tenantId, string languageId);
        //Task<TenantLanguage> GetInfoAsync(string tenantId, string languageId);
        //Task<bool> CheckExistsAsync(string tenantId, string languageId);
        //Task<int> UpdateIsActiveAsync(string tenantId, string languageId, bool isActive);
        //Task<int> UpdateIsDefaultAsync(string tenantId, string languageId, bool isDefault);
        //Task<int> ForceDeleteByTenantIdAsync(string tenantId);
        //Task<bool> CheckExistIsDefaultAsync(string tenantId, string languageId, bool isDefault);
    }
}
