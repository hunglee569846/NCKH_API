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
        public async Task<SearchResult<GiangVienHuongDanViewModel>> SelectAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
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
                    para.Add("@DonViCongTac", giangvientheoky.DonViCongTac);
                    para.Add("@Email", giangvientheoky.Email);
                    para.Add("@DienThoai", giangvientheoky.DienThoai);
                    para.Add("@Type", giangvientheoky.Type);
                    para.Add("@IsActive", giangvientheoky.IsActive);
                    para.Add("@IsDelete", giangvientheoky.IsDelete);
                    if (giangvientheoky.CreateTime != DateTime.MinValue && giangvientheoky.CreateTime != null)
                    {
                        para.Add("@CreateTime", giangvientheoky.CreateTime);
                    }
                    para.Add("@CreatorUserId", giangvientheoky.CreatorUserId);
                    para.Add("@CreartorFullName", giangvientheoky.CreatorFullName);
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

        public async Task<int> DeleteByIdAsync(string idgvhdTheoky,string deleteUserId,string deleteFullName,DateTime? ngayxoa)
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
                    if(ngayxoa != DateTime.MinValue && ngayxoa != null)
                    {
                        para.Add("@NgayXoa", ngayxoa);
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
                //_logger.LogError(ex, "[dbo].[spGiangVienHuongDan_DeleteAsync] DeleteAsync GiangVienHuongDanRepository Error.");
                return null;
            }
        }
    }
}
