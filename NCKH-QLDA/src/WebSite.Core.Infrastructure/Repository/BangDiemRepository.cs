﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Infrastructure.Repository
{
    public class BangDiemRepository : IBangDiemRepository
    {
        private readonly string _ConnectionString;
        public BangDiemRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public async Task<int> InsertAsync(BangDiem bangdiem)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", bangdiem.IdBangDiem);
                    param.Add("@IdDeTai", bangdiem.IdDeTai);
                    param.Add("@IdSinhVien", bangdiem.IdSinhVien);
                    param.Add("@IdHocKy", bangdiem.IdHocKy);
                    param.Add("@IdMonHoc", bangdiem.IdMonHoc);
                    param.Add("@IdHoiDong", bangdiem.IdHoiDong);
                    param.Add("@IdGiangVien", bangdiem.IdGiangVien);
                    param.Add("@DiemSo", bangdiem.DiemSo);
                    param.Add("@CreatorUserId", bangdiem.CreatorUserId);
                    param.Add("@CreatorFullName", bangdiem.CreatorFullName);
                    param.Add("@IsDelete", bangdiem.IsDelete);
                    param.Add("@IsActive", bangdiem.IsActive);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spBangDiem_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<bool> CheckExit(string iddetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.BangDiem WHERE IdDeTai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdDeTai = iddetai });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckDuplicate CTDT DetaiRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExitIdBangDiem(string idBangDiem)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.BangDiem WHERE IdBangDiem = @idBangDiem AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdBangDiem = idBangDiem });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckDuplicate CTDT DetaiRepository Error.");
                return false;
            }
        }

        public async Task<int> UpdateDiemAsync(BangDiem bangdiem)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", bangdiem.IdBangDiem);
                    param.Add("@DiemSo", bangdiem.DiemSo);
                    param.Add("@NhanXetGV", bangdiem.NhanXetGV);
                    if (bangdiem.NgayVaoDiem != DateTime.MinValue && bangdiem.NgayVaoDiem != null)
                    {
                        param.Add("@NgayVaoDiem", bangdiem.NgayVaoDiem);
                    }
                    param.Add("@CreatorPointUserId", bangdiem.CreatorPointUserId);
                    param.Add("@CreatorPointFullName", bangdiem.CreatorPointFullName);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spBanDiem_UpdateDiemHD]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
