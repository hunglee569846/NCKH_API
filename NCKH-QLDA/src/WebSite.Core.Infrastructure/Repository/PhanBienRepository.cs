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

        public async Task<SearchResult<PhanBienSearchViewModel>> SelectAllByHk(string idhocky, string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@IdBoMon", idBoMon);
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
                    param.Add("@IdBoMon", phanbien.IdBoMon);
                    param.Add("@IdGVPB", phanbien.IdGVPB);
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
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_InsertAsync] PhanBienRepository Error.");
                return -1;
            }

        }

        public async Task<int> Update(PhanBien phanBien)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", phanBien.IdPhanBien);
                    param.Add("@IdBoMon", phanBien.IdBoMon);
                    param.Add("@IdGVPB", phanBien.IdGVPB);
                    param.Add("@IdDetai", phanBien.IdDetai);
                    param.Add("@Diem", phanBien.Diem);
                    param.Add("@Note", phanBien.Note);
                    param.Add("@IdHocKy", phanBien.IdHocKy);
                    param.Add("@IdMonHoc", phanBien.IdMonHoc);
                    if (phanBien.CreateTime != null && phanBien.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", phanBien.CreateTime);
                    }
                    param.Add("@CreatorUserId", phanBien.CreatorUserId);
                    param.Add("@CreatorFullName", phanBien.CreatorFullName);
                    if (phanBien.LastUpdate != null && phanBien.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", phanBien.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", phanBien.lastUpdateUserId);
                    param.Add("@LastUpdateFullName", phanBien.LastUpdateFullName);
                    if (phanBien.DeleteTime != null && phanBien.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", phanBien.DeleteTime);
                    }
                    param.Add("@DeleteUserId", phanBien.DeleteUserId);
                    param.Add("@DeleteFullName", phanBien.DeleteFullName);
                    param.Add("@IsActive", phanBien.IsActive);
                    param.Add("@IsDelete", phanBien.IsDelete);
                    rowAffected = await con.ExecuteAsync("[dbo].[spPhanBien_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_Update] UpdateAsync PhanBienRepository Error.");
                return -1;
            }

        }

        public async Task<bool> CheckExis(string idPhanBien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.PhanBiens WHERE IdPhanBien = @idPhanBien AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdPhanBien = idPhanBien });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExisPhanBien(string idGVPB, string iddetai, string idhocky, string idmonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.PhanBiens WHERE IdGVPB = @idGVPB AND IdHocKy = @idhocky AND IdMonHoc = @idmonhoc AND IdDetai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdGVPB = idGVPB, IdHocKy = idhocky, IdMonHoc = idmonhoc, IdDetai = iddetai, });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExisByMaGV(string MaGV, string idhocky, string idmonhoc, string iddetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.PhanBiens WHERE MaGVPB = @MaGVPB AND IdHocKy = @idhocky AND
			                    IdMonHoc = @idmonhoc AND IdDetai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaGVPB = MaGV, IdHocKy = idhocky, IdMonHoc = idmonhoc, IdDetai = iddetai });
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

        public async Task<int> UpdateDiem(NoteMeta note, string idPhanBien)
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
                    param.Add("@Diem", note.Diem);
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

        public async Task<PhanBien> GetInfoAsync(string idPhanBien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdPhanBien", idPhanBien);
                    return await con.QuerySingleOrDefaultAsync<PhanBien>("[dbo].[spPhanBien_SelectByID]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_SelectByID] GetInfoAsync PhanBienRepository Error.");
                return null;
            }

        }

        public async Task<List<PhanBien>> ListPhanBien(string idBoMon, string idhocky, string idMonHoc, string idDetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBoMon", idBoMon);
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@IdMonHoc", idMonHoc);
                    param.Add("@IdDeTai", idDetai);
                    var result = await con.QueryAsync<PhanBien>("[dbo].[spPhanBienListByIdDeTai]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_SelectByID] GetInfoAsync PhanBienRepository Error.");
                return null;
            }
        }

        public async Task<int> CoutPhanBien(string idDeTai)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();

                    var sql = @"
					SELECT ISNULL(COUNT(0),1) FROM dbo.PhanBiens WHERE IdDetai = @idDeTai AND  IsActive =1 AND IsDelete = 0 ";

                    var Results = await conn.ExecuteScalarAsync<int>(sql, new { IdDetai = idDeTai });
                    return Results;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_DeleteAsync] PhanBienRepository Error.");
                return -1;
            }
        }
    }
}
