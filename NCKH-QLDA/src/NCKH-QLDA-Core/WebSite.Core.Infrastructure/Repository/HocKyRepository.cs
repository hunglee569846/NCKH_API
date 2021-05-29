using Dapper;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Repository
{
    public class HocKyRepository : IHocKysRepository
    {
        private readonly string _connectionString;
        public HocKyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SearchResult<HocKySearchViewModel>> SelectAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spHocKy_SelectAll]", commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<HocKySearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<HocKySearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync BranchRepository Error.");
                return new SearchResult<HocKySearchViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<int> InsertAsync(HocKy hocky)
        {
            try
            {
                int TotalRow = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", hocky.IdHocKy);
                    param.Add("@MaHocKy", hocky.MaHocKy);
                    param.Add("@TenHocKy", hocky.TenHocKy);
                    if (hocky.NgayTao != null && hocky.NgayTao != DateTime.MinValue)
                    {
                        param.Add("@NgayTao", hocky.NgayTao);
                    }
                    param.Add("@IsActive", hocky.IsActive);
                    param.Add("@IsDelete", hocky.IsDelete);
                    param.Add("@CreatetorId", hocky.CreatetorId);
                    param.Add("@CreatorFullName", hocky.CreatorFullName);
                    TotalRow = await conn.ExecuteAsync("[dbo].[spHocKy_Insert]", param, commandType: CommandType.StoredProcedure);
                    return TotalRow;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync HocKyRepository Error.");
                return -1;
            }
        }
        
        public async Task<int> UpdateAsync(string idhocky, string mahocky,string tenhocky, DateTime? ngaysua,string userId, string fullName)
        {
            try
            {
                int TotalRow = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@MaHocKy", mahocky);
                    param.Add("@TenHocKy", tenhocky);
                    param.Add("@NgaySua", ngaysua);
                    param.Add("@LastUpdateUserId", userId);
                    param.Add("@LastUpdateFullName", fullName);
                    TotalRow = await conn.ExecuteAsync("[dbo].[spHocKy_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
                    return TotalRow;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_UpdateAsync] UpdatetAsync HocKyRepository Error.");
                return -1;
            }
        }

        public async Task<bool> CheckExistAsync(string idHocKy,string maHocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE IdHocKy = @idHocKy AND MaHocKy = @maHocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idHocKy, MaHocKy = maHocky});
                    return result;
                }
            }
            catch (Exception)
            {
               // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

       
        public async Task<bool> CheckExisIsActivetAsync(string idHocKy)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE IdHocKy = @idHocKy AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idHocKy});
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<int> DeleteAsync (string idhocky)
        {
            try
            {
                var totalRow = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    totalRow = await con.ExecuteAsync("[dbo].[spHocky_DeleteAsync]", param, commandType: CommandType.StoredProcedure);
                    return totalRow;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return -1;
            }
        }

        public async Task<HocKySearchViewModel> SearchInfo(string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    return  await con.QuerySingleOrDefaultAsync<HocKySearchViewModel>("[dbo].[spHocKy_GetInfo]", param, commandType: CommandType.StoredProcedure);
                    
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "GetInfoAsync HocKyRepository Error.");
                return null;
            }
        }
    }
}
