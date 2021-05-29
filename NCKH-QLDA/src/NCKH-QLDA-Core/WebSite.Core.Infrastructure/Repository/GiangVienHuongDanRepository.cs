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
        public async Task<List<GiangVienHuongDanViewModel>> SelectAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                var Result = await conn.QueryAsync<GiangVienHuongDanViewModel>("[dbo].[spGiangVienHuongDan]");
                return Result.ToList();
            }

        }

        public async Task<SearchResult<GiangVienHuongDanViewModel>> SelectByIdHocKyAsync(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
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

        public async Task<int> InsertAsync(GVHDTheoKy giangvientheoky)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGVHDTheoKy", giangvientheoky.IdGVHDTheoKy);
                    para.Add("@IdGVHD", giangvientheoky.IdGVHD);
                    para.Add("@MaGVHD", giangvientheoky.MaGVHD);
                    para.Add("@TenGVHD", giangvientheoky.TenGVHD);
                    para.Add("@IdHocKy", giangvientheoky.IdHocKy);
                    para.Add("@IdMonHoc", giangvientheoky.IdMonHoc);
                    para.Add("@DonViCongTac", giangvientheoky.DonViCongTac);
                    para.Add("@Email", giangvientheoky.Email);
                    para.Add("@DienThoai", giangvientheoky.DienThoai);
                    para.Add("@Type", giangvientheoky.Type);
                    para.Add("@IsActive", giangvientheoky.IsActive);
                    para.Add("@IsDelete", giangvientheoky.IsDelete);
                    if (giangvientheoky.NgayTao != DateTime.MinValue && giangvientheoky.NgayTao != null)
                    {
                        para.Add("@NgayTao", giangvientheoky.NgayTao);
                    }
                    if (giangvientheoky.NgayXoa != DateTime.MinValue && giangvientheoky.NgayXoa != null)
                    {
                        para.Add("@NgayXoa", giangvientheoky.NgayXoa);
                    }
                    rowAffect = await conn.ExecuteAsync("[dbo].[spGVHD_InsertByIdHocKy]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGVHD_InsertByIdHocKy] InsertchAsync GiangVienHuongDanRepository Error.");
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

        public async Task<int> UpdatetAsync(GVHDTheoKy gvhdkyUpdate)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGVHDTheoKy", gvhdkyUpdate.IdGVHDTheoKy);
                    para.Add("@DonViCongTac", gvhdkyUpdate.DonViCongTac);
                    para.Add("@Email", gvhdkyUpdate.Email);
                    para.Add("@DienThoai", gvhdkyUpdate.DienThoai);
                    para.Add("@Type", gvhdkyUpdate.Type);

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

        public async Task<bool> CheckExitsActive(string idhocky, string idGVHD, string idMonHoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.GVHDTheoKys WHERE IdHocKy = @idhocky  AND IdGVHD = @idGVHD AND IdMonHoc = @idMonHoc  AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idhocky, IdGVHD = idGVHD, IdMonHoc = idMonHoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExitsGVHD(string idGVHD)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.GVHDTheoKys WHERE IdGVHD = @idGVHD  AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdGVHD = idGVHD });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }

        }

        public async Task<int> DeleteByIdAsync(string idgvhdTheoky)
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

        public async Task<GVHDTheoKy> GetInfo(string idGVHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdGHVD", idGVHD);

                    return await conn.QuerySingleOrDefaultAsync<GVHDTheoKy>("[dbo].[spGVHDTheoKys_GetInfo]", para, commandType: CommandType.StoredProcedure);
                     
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_DeleteAsync] DeleteAsync GiangVienHuongDanRepository Error.");
                return null;
            }
        }
    }
}
