using Core.Domain.IRepository;
using Core.Domain.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
    public class TenantLanguageRepository : ITenantLanguageRepository
    {
        private readonly string _connectionString;
       // private readonly ILogger<TenantLanguageRepository> _logger;

        public TenantLanguageRepository(string connectionString)
           // ILogger<TenantLanguageRepository> logger)
        {
            _connectionString = connectionString;
           // _logger = logger;
        }

        public async Task<List<TenantLanguageViewModel>> SelectAllByTenantIdAsync(string tenantId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@TenantId", tenantId);
                    var results = await con.QueryAsync<TenantLanguageViewModel>("[dbo].[spTenantLanguage_SelectAll]", param, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spTenantLanguage_SelectAll] SelectAll TenantLanguageRepository Error.");
                return new List<TenantLanguageViewModel>();
            }
        }


    //    public async Task<int> InsertAsync(TenantLanguage tenantLanguage)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantLanguage.TenantId);
    //                param.Add("@LanguageId", tenantLanguage.LanguageId);
    //                param.Add("@Name", tenantLanguage.Name);
    //                param.Add("@IsActive", tenantLanguage.IsActive);
    //                param.Add("@IsDefault", tenantLanguage.IsDefault);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_Insert]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_Insert] Insert TenantLanguageRepository Error.");
    //            return -1;
    //        }
    //    }


    //    public async Task<int> UpdateAsync(TenantLanguage tenantLanguage)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantLanguage.TenantId);
    //                param.Add("@LanguageId", tenantLanguage.LanguageId);
    //                param.Add("@Name", tenantLanguage.Name);
    //                param.Add("@IsActive", tenantLanguage.IsActive);
    //                param.Add("@IsDefault", tenantLanguage.IsDefault);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_Update]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_Update] Update TenantLanguageRepository Error.");
    //            return -1;
    //        }
    //    }


    //    public async Task<int> ForceDeleteAsync(string tenantId, string languageId)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantId);
    //                param.Add("@LanguageId", languageId);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_ForceDeleteByID]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_ForceDeleteByID] ForceDelete TenantLanguageRepository Error.");
    //            return -1;
    //        }
    //    }


    //    public async Task<TenantLanguage> GetInfoAsync(string tenantId, string languageId)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantId);
    //                param.Add("@LanguageId", languageId);
    //                return await con.QuerySingleOrDefaultAsync<TenantLanguage>("[dbo].[spTenantLanguage_SelectByID]", param, commandType: CommandType.StoredProcedure);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_SelectByID] GetInfo TenantLanguageRepository Error.");
    //            return null;
    //        }
    //    }

    //    public async Task<bool> CheckExistsAsync(string tenantId, string languageId)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                var sql = @"
				//	SELECT IIF (EXISTS (SELECT 1 FROM TenantLanguages WHERE TenantId = @TenantId AND LanguageId = @LanguageId), 1, 0)";

    //                var result = await con.ExecuteScalarAsync<bool>(sql, new { TenantId = tenantId, LanguageId = languageId });
    //                return result;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "CheckExists TenantLanguageRepository Error.");
    //            return false;
    //        }
    //    }

    //    public async Task<int> UpdateIsActiveAsync(string tenantId, string languageId, bool isActive)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantId);
    //                param.Add("@LanguageId", languageId);
    //                param.Add("@IsActive", isActive);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_Update_IsActive]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_Update_IsActive] Update TenantLanguageRepository Error.");
    //            return -1;
    //        }
    //    }

    //    public async Task<int> UpdateIsDefaultAsync(string tenantId, string languageId, bool isDefault)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantId);
    //                param.Add("@LanguageId", languageId);
    //                param.Add("@IsDefault", isDefault);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_Update_IsDefault]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_Update_IsDefault] Update TenantLanguageRepository Error.");
    //            return -1;
    //        }
    //    }

    //    public async Task<int> ForceDeleteByTenantIdAsync(string tenantId)
    //    {
    //        try
    //        {
    //            int rowAffected = 0;
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                DynamicParameters param = new DynamicParameters();
    //                param.Add("@TenantId", tenantId);
    //                rowAffected = await con.ExecuteAsync("[dbo].[spTenantLanguage_ForceDeleteByTenantId]", param, commandType: CommandType.StoredProcedure);
    //            }
    //            return rowAffected;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "[dbo].[spTenantLanguage_ForceDeleteByTenantId] ForceDelete TenantPageRepository Error.");
    //            return -1;
    //        }
    //    }

    //    public async Task<bool> CheckExistIsDefaultAsync(string tenantId, string languageId, bool isDefault)
    //    {
    //        try
    //        {
    //            using (SqlConnection con = new SqlConnection(_connectionString))
    //            {
    //                if (con.State == ConnectionState.Closed)
    //                    await con.OpenAsync();

    //                var sql = @"
				//	SELECT IIF (EXISTS (SELECT 1 FROM TenantLanguages WHERE TenantId = @TenantId AND LanguageId != @LanguageId AND IsDefault = @IsDefault), 1, 0)";

    //                var result = await con.ExecuteScalarAsync<bool>(sql, new { TenantId = tenantId, LanguageId = languageId, IsDefault = isDefault });
    //                return result;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "CheckExistIsDefaultAsync TenantLanguageRepository Error.");
    //            return false;
    //        }
    //    }
    }
}
