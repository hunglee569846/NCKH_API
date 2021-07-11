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

        public async Task<SearchResult<HocKySearchViewModel>> SelectAll(string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBoMon", idbomon);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spHocKy_SelectAll]",param, commandType: CommandType.StoredProcedure))
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
                    param.Add("@IdBoMon", hocky.IdBoMon);
                    param.Add("@MaHocKy", hocky.MaHocKy);
                    param.Add("@TenHocKy", hocky.TenHocKy);
                    param.Add("@NamHoc", hocky.NamHoc);
                    if (hocky.CreateTime != null && hocky.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", hocky.CreateTime);
                    }
                    param.Add("@IsActive", hocky.IsActive);
                    param.Add("@IsDelete", hocky.IsDelete);
                    param.Add("@LockData", hocky.IsLockData);
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
        
        //public async Task<int> UpdateAsync(string idhocky, string mahocky,string tenhocky, DateTime? LastUpdate, string userId, string fullName)
        //{
        //    try
        //    {
        //        int TotalRow = 0;
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {
        //            if (conn.State == ConnectionState.Closed)
        //                await conn.OpenAsync();
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@IdHocKy", idhocky);
        //            param.Add("@MaHocKy", mahocky);
        //            param.Add("@TenHocKy", tenhocky);
        //            param.Add("@LastUpdate", LastUpdate);
        //            param.Add("@LastUpdateUserId", userId);
        //            param.Add("@LastUpdateFullName", fullName);
        //            TotalRow = await conn.ExecuteAsync("[dbo].[spHocKy_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
        //            return TotalRow;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //_logger.LogError(ex, "[dbo].[spHocKy_UpdateAsync] UpdatetAsync HocKyRepository Error.");
        //        return -1;
        //    }
        //}

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

        public async Task<bool> CheckExisMaHocKy(string mahocky,string idbomon)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE MaHocKy = @mahocky AND IdBoMon = @IdBoMon AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new {MaHocKy = mahocky , IdBoMon  = idbomon });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }


        public async Task<bool> CheckExisIsActivetAsync(string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idhocky });
                    return result;
                }
            }
            catch (Exception ex)
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
        public async Task<bool> CheckLockDataAsync(string idHocKy)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE IdHocKy = @idHocKy AND IsLockData = 1 AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idHocKy });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }
        public async Task<HocKy> SearchInfo(string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    return  await con.QuerySingleOrDefaultAsync<HocKy>("[dbo].[spHocKy_GetInfo]", param, commandType: CommandType.StoredProcedure);
                    
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "GetInfoAsync HocKyRepository Error.");
                return null;
            }
        }

        public async Task<int> UpdateAsync(HocKy hocKy)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();


                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", hocKy.IdHocKy);
                    param.Add("@IdBoMon", hocKy.IdBoMon);
                    param.Add("@MaHocKy", hocKy.MaHocKy);
                    param.Add("@TenHocKy", hocKy.TenHocKy);
                    param.Add("@NamHoc", hocKy.NamHoc);
                    if (hocKy.CreateTime != null && hocKy.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", hocKy.CreateTime);
                    }
                    if (hocKy.LastUpdate != null && hocKy.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", hocKy.LastUpdate);
                    }
                    if (hocKy.DeleteTime != null && hocKy.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", hocKy.DeleteTime);
                    }
                    param.Add("@IsActive", hocKy.IsActive);
                    param.Add("@IsDelete", hocKy.IsDelete);
                    param.Add("@IsLockData", hocKy.IsLockData);
                    param.Add("@CreatetorId", hocKy.CreatetorId);
                    param.Add("@CreatorFullName", hocKy.CreatorFullName);
                    param.Add("@LastUpdateUserId", hocKy.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", hocKy.LastUpdateFullName);
                    rowAffected = await con.ExecuteAsync("[dbo].[spHocKy_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
                    
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_Update] UpdateAsync HocKyRepository Error.");
                return -1;
            }
        }
    }
}
