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
    public class PhanBienRepository : IPhanBienRepository
    {
        private readonly string _connectionString;
        public PhanBienRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public async Task<SearchResult<PhanBienSearchViewModel>> SelectAllByHk(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spPhanBien_SelectAllByHK]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<PhanBienSearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<PhanBienSearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_SelectAllByHK] PhanBienRepository Error.");
                return new SearchResult<PhanBienSearchViewModel> { TotalRows = 0, Data = null, Code = -1};
            }
        }

        public async Task<int> InsertByHk(PhanBien phanbien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", phanbien.IdPhanBien);
                    param.Add("@IdGVPB", phanbien.IdGVPB);
                    param.Add("@MaGVPB", phanbien.MaGVPB);
                    param.Add("@TenGVPB", phanbien.TenGVPB);
                    param.Add("@IdDetai", phanbien.IdDetai);
                    param.Add("@IdHocKy", phanbien.IdHocKy);
                    param.Add("@IdMonHoc", phanbien.IdMonHoc);
                    param.Add("@Diem", phanbien.Diem);
                    param.Add("@CreateTime", phanbien.CreateTime);
                    param.Add("@CreatorUserId", phanbien.CreatorUserId);
                    param.Add("@CreatorFullName", phanbien.CreatorFullName);
                    param.Add("@IsActive", phanbien.IsActive);
                    param.Add("@IsDelete", phanbien.IsDelete);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spPhanBien_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_InsertAsync] PhanBienRepository Error.");
                return -1;
            }

        }

        public async Task<int> Update(PhanBien phanbien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", phanbien.IdPhanBien);
                    param.Add("@IdGVPB", phanbien.IdGVPB);
                    param.Add("@MaGVPB", phanbien.MaGVPB);
                    param.Add("@TenGVPB", phanbien.TenGVPB);
                    param.Add("@IdDetai", phanbien.IdDetai);
                    param.Add("@Note", phanbien.Note);
                    param.Add("@NgaySua", phanbien.LastUpdate);
                    param.Add("@LastUpdateUserId", phanbien.lastUpdateUserId);
                    param.Add("@LastUpdateFullName", phanbien.LastUpdateFullName);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spPhanBien_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_UpdateAsync] PhanBienRepository Error.");
                return -1;
            }
        }

        public async Task<bool> CheckExis(string idGVPB, string idhocky,string idmonhoc,string iddetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.PhanBiens WHERE IdGVPB = @idGVPB AND IdHocKy = @idhocky AND IdMonHoc = @idmonhoc AND IdDetai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdPhanBien = idGVPB, IdHocKy = idhocky , IdMonHoc = idmonhoc, IdDetai = iddetai });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExisActive(string idphanbien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.PhanBiens WHERE IdPhanBien = @idphanbien AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdPhanBien = idphanbien});
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<int> UpdateDiem(NoteMeta note, float diem, string idPhanBien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", idPhanBien);
                    param.Add("@Diem", diem);
                    param.Add("@Note", note.Note);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spPhanBien_UpdateDiem]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_UpdateDiem] PhanBienRepository Error.");
                return -1;
            }
        }
        public async Task<int> DeleteAsync(string idphanbien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", idphanbien);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spPhanBien_DeleteAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_DeleteAsync] PhanBienRepository Error.");
                return -1;
            }
        }
    }
}
