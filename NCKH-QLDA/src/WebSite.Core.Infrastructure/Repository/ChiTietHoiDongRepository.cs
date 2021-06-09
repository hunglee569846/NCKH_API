using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Repository
{
    public class ChiTietHoiDongRepository : IChiTietHoiDongRepository
    {
        private readonly string _ConnectionString;
        public ChiTietHoiDongRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<int> InserAsync(ChiTietHoiDong chitiethoidong)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdChiTietHD", chitiethoidong.IdChiTietHD);
                    param.Add("@IdHoiDong", chitiethoidong.IdHoiDong);
                    param.Add("@IdGiangVien", chitiethoidong.IdGiangVien);
                    param.Add("@CreateTime", chitiethoidong.CreateTime);
                    param.Add("@CreatorUserId", chitiethoidong.CreatorUserId);
                    param.Add("@CreatorFullName", chitiethoidong.CreatorUserFullName);
                    param.Add("@IsDelete", chitiethoidong.IsDelete);
                    param.Add("@IsActive", chitiethoidong.IsActive);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietHoiDong_Insert]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteByIdHoiDongAsync(string idhoidong)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDongTotNghiep", idhoidong);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietHoiDong_DeleteByIdHoiDongAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> DeleteByIdAsync(string idchitietHD)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdChiTietHoiDong", idchitietHD);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietHoiDong_DeleteByIdAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<bool> CheckExits(string idchitiethoidong)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.ChiTietHoiDongs WHERE IdChiTietHD = @idchitiethoidong AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdChiTietHD = idchitiethoidong });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsDuplicate(string idHoiDong, string idGVHD)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.ChiTietHoiDongs WHERE IdHoiDong= @IdHoiDong AND IdGiangVien = @idGVHD AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHoiDong = idHoiDong, IdGVHD = idGVHD });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckDuplicate CTDT DetaiRepository Error.");
                return false;
            }
        }

        public async Task<List<GiangVienGetListViewModel>> GetListThanhVien(string idHoiDong)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", idHoiDong);
                    var result = await conn.QueryAsync<GiangVienGetListViewModel>("[dbo].[spChiTietHoiDong_GetListGV]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
