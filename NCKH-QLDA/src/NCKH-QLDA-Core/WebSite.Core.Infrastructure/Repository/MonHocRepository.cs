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

        public async Task<SearchResult<MonHocSearchViewModel>> SelectAllByIdHocKy(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
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
                //_logger.LogError(ex, "[dbo].[spMonHoc_SelectAllByHocky] SelectAllByIdHocKy MonHocService Error.");
                return new SearchResult<MonHocSearchViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<int> InsertAsync(MonHoc monhoc)
        {
            try
            {
                var rowAffect = 0; 
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", monhoc.IdMonHoc);
                    param.Add("@MaMonHoc", monhoc.MaMonHoc);
                    param.Add("@IdHocKy", monhoc.IdHocKy);
                    param.Add("@TenMonHoc", monhoc.TenMonHoc);
                    param.Add("@NgayTao", monhoc.NgayTao);
                    param.Add("@IsActive", monhoc.IsActive);
                    param.Add("@IsDelete", monhoc.IsDelete);
                    param.Add("@TypeApprove", monhoc.TypeApprover);
                    param.Add("@CreatorUserId", monhoc.CreatorUserId);
                    param.Add("@CreatorFullName", monhoc.CreatorUserId);
                    param.Add("@IdMonTienQuyet", monhoc.IdMonTienQuyet);
                    param.Add("@NameMonTienQuyet", monhoc.NameMonTienQuyet);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spMonHoc_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_SelectAllByHocky] SelectAllByIdHocKy MonHocRepository Error.");
                return -1;
            }

        }

       public async Task<bool> CheckExits(string idmonhoc, string mamonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.MonHocs WHERE IdMonHoc = @idmonhoc AND MaMonHoc = @mamonhoc AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdMonHoc = idmonhoc, MaMonHoc = mamonhoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
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
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }

        }
        public async Task<int> UpdateAsync(MonHoc monhoc)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", monhoc.IdMonHoc);
                    param.Add("@MaMonHoc", monhoc.MaMonHoc);
                    param.Add("@IdHocKy", monhoc.IdHocKy);
                    param.Add("@TenMonHoc", monhoc.TenMonHoc);
                    param.Add("@TypeApprover", monhoc.TypeApprover);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spMonHoc_EditById]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spMonHoc_EditById] UpdateAllByIdHocKy MonHocService Error.");
                return -1;
            }

        }
        public async Task<MonHocSearchViewModel> SearchInfo(string idmonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdMonHoc", idmonhoc);
                    return await con.QuerySingleOrDefaultAsync<MonHocSearchViewModel>("[dbo].[spMonHoc_GetInfo]", param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "GetInfoAsync MonHocRepository Error.");
                return null;
            }
        }
    }
}
