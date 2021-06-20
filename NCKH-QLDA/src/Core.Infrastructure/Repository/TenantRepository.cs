using Core.Domain.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
	public class TenantRepository : ITenantRepository
	{
		private readonly string _connectionString;
		//private readonly ILogger<TenantRepository> _logger;

		public TenantRepository(string connectionString)//, ILogger<TenantRepository> logger)
		{
			_connectionString = connectionString;
			//_logger = logger;
		}

		public async Task<string> GetidKhoaByDomainAsync(string domain)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"SELECT TOP 1 ISNULL(IdKhoa,'') AS TenantId FROM dbo.KhoaSuDungs WHERE Domain = @Domain AND IsActive = 1";

                    var result = await con.ExecuteScalarAsync<string>(sql, new { Domain = domain });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "GetTenantIdByDomain TenantRepository Error.");
                return string.Empty;
            }
        }
		public async Task<int> UpdateIsActiveAsync(string id, bool isActive)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", id);
                    param.Add("@IsActive", isActive);
                    rowAffected = await con.ExecuteAsync("[dbo].[spKhoaSuDung_Update_IsActive]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spTenant_Update_IsActive] UpdateIsActive TenantRepository Error.");
                return -1;
            }
        }
	}
}
