using Core.Domain.IRepository;
using Core.Domain.Models;
using Core.Domain.ViewModel;
using Dapper;
using NCKH.Infrastruture.Binding.Constans;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly string _connectionString;
       // private readonly ILogger<UserAccountRepository> _logger;

        public UserAccountRepository(string connectionString)
            //, ILogger<UserAccountRepository> logger)
        {
            _connectionString = connectionString;
          //  _logger = logger;
        }
        public async Task<int> InsertAsync(UserAccount userAccount)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdAccount", userAccount.IdAccount);
                    param.Add("@MaGiangVien", userAccount.MaGiangVien);
                    param.Add("@UserFullName", userAccount.UserFullName);
                    param.Add("@UserName", userAccount.UserName);
                    param.Add("@Email", userAccount.Email);
                    param.Add("@PasswordHash", userAccount.PasswordHash);
                    param.Add("@PasswordSalt", userAccount.PasswordSalt);
                    param.Add("@PhoneNumber", userAccount.PhoneNumber);
                    param.Add("@IdBoMon", userAccount.IdBoMon);
                    param.Add("@NameBoMon", userAccount.NameBoMon);
                    param.Add("@LockoutEnd", userAccount.LockoutEnd);
                    param.Add("@LockoutEnabled", userAccount.LockoutEnabled);
                    param.Add("@AccessFailedCount", userAccount.AccessFailedCount);
                    param.Add("@IsActive", userAccount.IsActive);
                    param.Add("@IsDelete", userAccount.IsDelete);
                    param.Add("@CreateTime", userAccount.CreateTime);
                    param.Add("@Type", userAccount.Type);
                    param.Add("@CreatorId", userAccount.CreatorId);
                    param.Add("@CreatorFullName", userAccount.CreatorFullName);
                    if (userAccount.LastUpdate != null && userAccount.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", userAccount.LastUpdate);
                    }
                    rowAffected = await con.ExecuteAsync("[dbo].[spAccount_Insert]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception)
            {
               // _logger.LogError(ex, "[dbo].[spUserAccount_Insert] Insert UserAccountRepository Error.");
                return -1;
            }
        }

        public async Task<UserAccount> GetInfoAsync(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdAccount", id);
                    return await con.QuerySingleOrDefaultAsync<UserAccount>("[dbo].[spUserAccount_SelectByID]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
              //  _logger.LogError(ex, "[dbo].[spUserAccount_SelectByID] GetInfo UserAccountRepository Error.");
                return null;
            }
        }


        public async Task<UserAccount> GetInfoAsync(string tenantId, string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdAccount", id);
                    param.Add("@TenantId", tenantId);
                    return await con.QuerySingleOrDefaultAsync<UserAccount>("[dbo].[spUserAccount_SelectByIDTenantId]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
              //  _logger.LogError(ex, "[dbo].[spUserAccount_SelectByIDTenantId] GetInfo UserAccountRepository Error.");
                return null;
            }
        }

        public async Task<bool> CheckIsAdminAsync(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM UserAccounts WHERE IdAccount = @Id AND Type = 1 AND IsDelete = 0  AND IsActive = 1), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdAccount = id });
                    return result;
                }
            }
            catch (Exception)
            {
              //  _logger.LogError(ex, "CheckIsAdminAsync UserAccountRepository Error.");
                return false;
            }
        }
        public async Task<UserAccount> GetInfoByUserNameAsync (string idAccount,string userName)// string userName, UserType type)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UserName", userName);
                    param.Add("@IdAccount", idAccount);
                  //  param.Add("@Type", type);
                    return await con.QuerySingleOrDefaultAsync<UserAccount>("[dbo].[spUserAccount_GetInfoByUserName]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
               // _logger.LogError(ex, "[dbo].[spUserAccount_GetInfoByUserName] GetInfo UserAccountRepository Error.");
                return null;
            }
        }

        public async Task<int> Update_LockAndResetAsync(UserAccount userAccount)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdAccount", userAccount.IdAccount);
                    param.Add("@LockoutEnd", userAccount.LockoutEnd);
                    param.Add("@AccessFailedCount", userAccount.AccessFailedCount);
                    if (userAccount.LastUpdate != null && userAccount.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", userAccount.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", userAccount.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", userAccount.LastUpdateFullName);
                    rowAffected = await con.ExecuteAsync("[dbo].[spUserAccount_Update_LockAndReset]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spUserAccount_Update_LockAndReset] Update UserAccountRepository Error.");
                return -1;
            }
        }

        public async Task<string> GetidKhoaByDomainAsync(string userName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"SELECT TOP 1 ISNULL(IdAccount,'') AS IdAccount FROM dbo.UserAccounts WHERE UserName = @userName AND IsActive = 1";

                    var result = await con.ExecuteScalarAsync<string>(sql, new { UserName = userName });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "GetidKhoaByDomainAsync TenantRepository Error.");
                return string.Empty;
            }
        }

        public Task<int> UpdateAsync(UserAccount userAccount)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update_PasswordAsync(UserAccount userAccount)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", userAccount.IdAccount);
                    param.Add("@PasswordHash", userAccount.PasswordHash);
                    param.Add("@PasswordSalt", userAccount.PasswordSalt);
                    if (userAccount.LastUpdate != null && userAccount.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", userAccount.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", userAccount.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", userAccount.LastUpdateFullName);

                    rowAffected = await con.ExecuteAsync("[dbo].[spUserAccount_UpdatePassword]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spUserAccount_UpdatePassword] Update UserAccountRepository Error.");
                return -1;
            }
        }

        public async Task<SearchResult<TaiKhoanViewModel>> GetTaiKhoanByBoMon(string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdBoMon", idBoMon);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spUserAccount_getByBoMon]", para, commandType: CommandType.StoredProcedure))
                    {
                        var data = (await multi.ReadAsync<TaiKhoanViewModel>()).ToList();
                        if (data == null)
                        {
                            return new SearchResult<TaiKhoanViewModel>() { Code = -1, Message = "Bộ môn không tồn tại.", Data = null };
                        }
                        return new SearchResult<TaiKhoanViewModel>()
                        {
                            Data = data,
                            Code = 1
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spSinhVien_ByIdSinhVien] GetInfo SinhVienRepository Error.");
                return null;
            }
        }
    }

}
