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
    public class MonHocRepository: IMonHocRepository
    {
        private readonly string _connectionString;
        public MonHocRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SearchResult<MonHocSearchViewModel>> SelectAllByIdHocKy(string idhocky,string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@IdBoMon", idbomon);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spMonHoc_SelectAllByHocky]",param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<MonHocSearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<MonHocSearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_SelectAllByHocky] SelectAllByIdHocKy MonHocRepository Error.");
                return new SearchResult<MonHocSearchViewModel> { TotalRows = 0, Data = null };
            }
        }
        
        public async Task<int> InsertAsync(MonHoc monHoc)
        {
            try
            {
                var rowAffected = 0; 
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", monHoc.IdMonHoc);
                    param.Add("@IdBoMon", monHoc.IdBoMon);
                    param.Add("@MaMonHoc", monHoc.MaMonHoc);
                    param.Add("@IdHocKy", monHoc.IdHocKy);
                    param.Add("@TenMonHoc", monHoc.TenMonHoc);
                    param.Add("@SoLuongGVHD", monHoc.SoLuongGVHD);
                    param.Add("@SoLuongPhanBien", monHoc.SoLuongPhanBien);
                    param.Add("@TypeApprover", monHoc.TypeApprover);
                    param.Add("@IdMonTienQuyet", monHoc.IdMonTienQuyet);
                    param.Add("@NameMonTienQuyet", monHoc.NameMonTienQuyet);
                    if (monHoc.LastUpdate != null && monHoc.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", monHoc.LastUpdate);
                    }
                    if (monHoc.CreateTime != null && monHoc.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", monHoc.CreateTime);
                    }
                    param.Add("@CreatorUserId", monHoc.CreatorUserId);
                    param.Add("@CreatorFullName", monHoc.CreatorFullName);
                    param.Add("@LastUpdateUserId", monHoc.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", monHoc.LastUpdateFullName);
                    if (monHoc.DeleteTime != null && monHoc.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", monHoc.DeleteTime);
                    }
                    param.Add("@DeleteTimeUserId", monHoc.DeleteTimeUserId);
                    param.Add("@DeleteTimeFullName", monHoc.DeleteTimeFullName);
                    param.Add("@IsActive", monHoc.IsActive);
                    param.Add("@IsDelete", monHoc.IsDelete);
                    rowAffected = await conn.ExecuteAsync("[dbo].[spMonHoc_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffected;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_SelectAllByHocky] SelectAllByIdHocKy MonHocRepository Error.");
                return -1;
            }

        }

       public async Task<bool> CheckExits(string IdHocKy, string MaMonHoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.MonHocs WHERE IdHocKy = @IdHocKy AND MaMonHoc = @MaMonHoc AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = IdHocKy, MaMonHoc = MaMonHoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync MonHocRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsIsActvive(string idmonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.MonHocs WHERE IdMonHoc = @idmonhoc AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdMonHoc = idmonhoc});
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync MonHocRepository Error.");
                return false;
            }

        }
        public async Task<bool> CheckExitsMaMonHoc(string mamonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.MonHocs WHERE MaMonHoc = @mamonhoc AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaMonHoc = mamonhoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync MonHocRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckMonHocInHocKyExits(string idmonhoc, string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.MonHocs WHERE IdMonHoc = @idmonhoc AND IdHocKy =@idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdMonHoc = idmonhoc, IdHocKy = idhocky });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync MonHocRepository Error.");
                return false;
            }
        }
        public async Task<int> UpdateAsync(MonHoc monHoc)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", monHoc.IdMonHoc);
                    param.Add("@IdBoMon", monHoc.IdBoMon);
                    param.Add("@MaMonHoc", monHoc.MaMonHoc);
                    param.Add("@IdHocKy", monHoc.IdHocKy);
                    param.Add("@TenMonHoc", monHoc.TenMonHoc);
                    param.Add("@TypeApprover", monHoc.TypeApprover);
                    param.Add("@IdMonTienQuyet", monHoc.IdMonTienQuyet);
                    param.Add("@SoLuongGVHD", monHoc.SoLuongGVHD);
                    param.Add("@SoLuongPhanBien", monHoc.SoLuongPhanBien);
                    param.Add("@NameMonTienQuyet", monHoc.NameMonTienQuyet);
                    if (monHoc.LastUpdate != null && monHoc.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", monHoc.LastUpdate);
                    }
                    if (monHoc.CreateTime != null && monHoc.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", monHoc.CreateTime);
                    }
                    param.Add("@CreatorUserId", monHoc.CreatorUserId);
                    param.Add("@CreatorFullName", monHoc.CreatorFullName);
                    param.Add("@LastUpdateUserId", monHoc.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", monHoc.LastUpdateFullName);
                    if (monHoc.DeleteTime != null && monHoc.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", monHoc.DeleteTime);
                    }
                    param.Add("@DeleteTimeUserId", monHoc.DeleteTimeUserId);
                    param.Add("@DeleteTimeFullName", monHoc.DeleteTimeFullName);
                    param.Add("@IsActive", monHoc.IsActive);
                    param.Add("@IsDelete", monHoc.IsDelete);
                    rowAffected = await con.ExecuteAsync("[dbo].[spMonHoc_EditById]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_Update] UpdateAsync MonHocRepository Error.");
                return -1;
            }
        }



        public async Task<int> DeleteAsync(MonHoc monHoc)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", monHoc.IdMonHoc);
                    param.Add("@DeleteUserId", monHoc.DeleteTimeUserId);
                    param.Add("@DeleteFullName", monHoc.DeleteTimeFullName);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spMonHoc_DeleteAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_DeleteAsync] DeleteAsync MonHocRepository Error.");
                return -1;
            }
        }
        public async Task<MonHoc> GetInfoAsync(string idMonHoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", idMonHoc);
                    return await con.QuerySingleOrDefaultAsync<MonHoc>("[dbo].[spMonHoc_GetInfo]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spMonHoc_SelectByID] GetInfoAsync MonHocRepository Error.");
                return null;
            }
        }
    }
}
