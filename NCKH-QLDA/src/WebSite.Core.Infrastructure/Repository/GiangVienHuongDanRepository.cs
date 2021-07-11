using Dapper;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Repository
{
    public class GiangVienHuongDanRepository : IGiangVienHuongDanRepository
    {
        private readonly string _connectionString;
        public GiangVienHuongDanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<SearchResult<GiangVienHuongDanViewModel>> SelectAllAsync(string idbomon)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                DynamicParameters para = new DynamicParameters();
                para.Add("@IdBoMon", idbomon);
                using (var multi = await conn.QueryMultipleAsync("[dbo].[spGiangVienHuongDan_SelectAll]", commandType: CommandType.StoredProcedure))
                {
                    return new SearchResult<GiangVienHuongDanViewModel>()
                    {
                        TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                        Data = (await multi.ReadAsync<GiangVienHuongDanViewModel>()).ToList()
                    };
                }
            }

        }

        public async Task<SearchResult<GiangVienHuongDanViewModel>> SelectByIdHocKyAsync(string idhocky,string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
                    para.Add("@IdBoMon", idBoMon);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spGiangVienHuongDan_SelectByIdHocKy]", para, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<GiangVienHuongDanViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<GiangVienHuongDanViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<GiangVienHuongDanViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<int> InsertAsync(GVHDTheoKy gVHDTheoKy)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdGVHDTheoKy", gVHDTheoKy.IdGVHDTheoKy);
                    param.Add("@IdBoMon", gVHDTheoKy.IdBoMon);
                    param.Add("@IdGVHD", gVHDTheoKy.IdGVHD);
                    param.Add("@MaGVHD", gVHDTheoKy.MaGVHD);
                    param.Add("@TenGVHD", gVHDTheoKy.TenGVHD);
                    param.Add("@IdHocKy", gVHDTheoKy.IdHocKy);
                    param.Add("@IdMonHoc", gVHDTheoKy.IdMonHoc);
                    param.Add("@DonViCongTac", gVHDTheoKy.DonViCongTac);
                    param.Add("@Email", gVHDTheoKy.Email);
                    param.Add("@DienThoai", gVHDTheoKy.DienThoai);
                    param.Add("@Type", gVHDTheoKy.Type);
                    param.Add("@IsActive", gVHDTheoKy.IsActive);
                    param.Add("@IsDelete", gVHDTheoKy.IsDelete);
                    if (gVHDTheoKy.CreateTime != null && gVHDTheoKy.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", gVHDTheoKy.CreateTime);
                    }
                    param.Add("@DeleteUserId", gVHDTheoKy.DeleteUserId);
                    param.Add("@DeleteUserFullName", gVHDTheoKy.DeleteFullName);
                    if (gVHDTheoKy.LastUpdate != null && gVHDTheoKy.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", gVHDTheoKy.LastUpdate);
                    }
                    if (gVHDTheoKy.DeteteTime != null && gVHDTheoKy.DeteteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", gVHDTheoKy.DeteteTime);
                    }
                    param.Add("@CreatorUserId", gVHDTheoKy.CreatorUserId);
                    param.Add("@CreartorFullName", gVHDTheoKy.CreatorFullName);
                    param.Add("@LastUpdateUserId", gVHDTheoKy.lastUpdateUserId);
                    param.Add("@LastUpdateFullName", gVHDTheoKy.LastUpdateFullName);
                    rowAffected = await con.ExecuteAsync("[dbo].[spGVHD_InsertByIdHocKy]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spGVHDTheoKy_Insert] InsertAsync GVHDTheoKyRepository Error.");
                return -1;
            }


        }
        public async Task<bool> CheckExits(string idGVHDTheoKy)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.GVHDTheoKys WHERE IdGVHDTheoKy = @idGVHDTheoKy AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdGVHDTheoKy = idGVHDTheoKy });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }
        }

        public async Task<int> UpdatetAsync(GVHDTheoKy giangvienhuongdan)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGVHDTheoKy", giangvienhuongdan.IdGVHDTheoKy);
                    para.Add("@DonViCongTac", giangvienhuongdan.DonViCongTac);
                    para.Add("@TenGVHD", giangvienhuongdan.TenGVHD);
                    para.Add("@Email", giangvienhuongdan.Email);
                    para.Add("@DienThoai", giangvienhuongdan.DienThoai);
                    para.Add("@Type", giangvienhuongdan.Type);
                    if (giangvienhuongdan.CreateTime != DateTime.MinValue && giangvienhuongdan.CreateTime != null)
                    {
                        para.Add("@LastUpdate", giangvienhuongdan.CreateTime);
                    }
                    para.Add("@LastUpdateUserId", giangvienhuongdan.lastUpdateUserId);
                    para.Add("@LastUpdateFullName", giangvienhuongdan.LastUpdateFullName);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spGiangVienHuongDan_UpdateAsync]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_UpdateAsync] UpdateAsync GiangVienHuongDanRepository Error.");
                return -1;
            }
        }

        public async Task<bool> CheckExitsActive(string idhocky, string idGVHD)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.GVHDTheoKys WHERE IdHocKy = @idhocky  AND IdGVHD = @idGVHD  AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idhocky, IdGVHD = idGVHD });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExitsGVHD(string maGVHD)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.GVHDTheoKys WHERE MaGVHD = @maGVHD  AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaGVHD = maGVHD });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }

        }

        public async Task<int> DeleteByIdAsync(string idgvhdTheoky,string deleteUserId,string deleteFullName,DateTime? DeleteTime)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGVHDTheoKy", idgvhdTheoky);
                    para.Add("@DeleteUserId", deleteUserId);
                    para.Add("@DeleteFullName", deleteFullName);
                    if(DeleteTime != DateTime.MinValue && DeleteTime != null)
                    {
                        para.Add("@DeleteTime", DeleteTime);
                    }
                    rowAffect = await conn.ExecuteAsync("[dbo].[spGiangVienHuongDan_DeleteAsync]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_DeleteAsync] DeleteAsync GiangVienHuongDanRepository Error.");
                return -1;
            }
        }
        
        public async Task<GVHDTheoKy> GetInfo(string idGVHDTheoKy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGHVDTheoKy", idGVHDTheoKy);

                    return await conn.QuerySingleOrDefaultAsync<GVHDTheoKy>("[dbo].[spGVHDTheoKys_GetInfo]", para, commandType: CommandType.StoredProcedure);
                     
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGVHDTheoKys_GetInfo] DeleteAsync GiangVienHuongDanRepository Error.");
                return null;
            }
        }
        public async Task<GVHDTheoKy> GetInfoByMaGVHD(string idhocky, string maGVHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
                    para.Add("@IdGVHD", maGVHD);

                    return await conn.QuerySingleOrDefaultAsync<GVHDTheoKy>("[dbo].[spGiangVienHuongDan_GetInfoByHK]", para, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_GetInfoByHK] DeleteAsync GiangVienHuongDanRepository Error.");
                return null;
            }
        }

        public async Task<List<ThongKeGiangVienViewModel>> ThongKeGiangVien(string idHocKy, string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idHocKy);
                    para.Add("@IdBoMon", idBoMon);

                    var result = await conn.QueryAsync<ThongKeGiangVienViewModel>("[dbo].[spThongKe_GiangVien]", para, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_GetInfoByHK] DeleteAsync GiangVienHuongDanRepository Error.");
                return null;
            }
        }
    }
}
