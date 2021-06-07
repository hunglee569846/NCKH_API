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
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly string _connectionString;
        public SinhVienRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public async Task<SearchResult<SinhVienSearchViewModel>> SelectAllByHocKyAsync(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spSinhVien_SelectAllByHocKy]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<SinhVienSearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<SinhVienSearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spSinhVien_SelectAllByHocKy] SinhVienRepository Error.");
                return new SearchResult<SinhVienSearchViewModel> { TotalRows = 0, Data = null, Code = -1 };
            }
        }

        public async Task<SinhVienSearchViewModel> GetInfo(string idsinhvien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdSinhVien", idsinhvien);

                    return await conn.QuerySingleOrDefaultAsync<SinhVienSearchViewModel>("[dbo].[spSinhVien_ByIdSinhVien]", para, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spSinhVien_ByIdSinhVien] GetInfo SinhVienRepository Error.");
                return null;
            }
        }
        public async Task<SearchResult<SinhVienSearchViewModel>> SearchById(string idsinhvien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdSinhVien", idsinhvien);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spSinhVien_ByIdSinhVien]", para, commandType: CommandType.StoredProcedure))
                    {
                        var data = (await multi.ReadAsync<SinhVienSearchViewModel>()).ToList();
                        if (data == null)
                        {
                            return new SearchResult<SinhVienSearchViewModel>() { Code = -1, Message = "Sinh viên không tồn tại.", Data = null};
                        }
                        return new SearchResult<SinhVienSearchViewModel>()
                        {
                            Data = data,
                            Code = 1
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spSinhVien_ByIdSinhVien] GetInfo SinhVienRepository Error.");
                return null;
            }
        }

        public async Task<int> InsertAsync(SinhVien sinhvien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdSinhVien", sinhvien.IdSinhVien);
                    param.Add("@MaSinhVien", sinhvien.MaSinhVien);
                    param.Add("@TenSinhVien", sinhvien.TenSinhVien);
                    param.Add("@Email", sinhvien.Email);
                    param.Add("@DienThoai", sinhvien.DienThoai);
                    param.Add("@DonViThucTap", sinhvien.DonViThucTap);
                    param.Add("@MaLopHoc", sinhvien.MaLopHoc);
                    param.Add("@LopHoc", sinhvien.LopHoc);
                    param.Add("@IdHocKy", sinhvien.IdHocKy);
                    param.Add("@CreateTime", sinhvien.CreateTime);
                    param.Add("@CreatorUserId", sinhvien.CreatorUserId);
                    param.Add("@CreatorFullName", sinhvien.CreatorFullName);
                    param.Add("@IsActive", sinhvien.IsActive);
                    param.Add("@IsDelete", sinhvien.IsDelete);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spSinhVien_InsertInHocKy]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spSinhVien_InsertInHocKy] PhanBienRepository Error.");
                return -1;
            }

        }
        public async Task<bool> CheckExits(string idhocky, string masinhvien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.SinhViens WHERE MaSinhVien = @masinhvien AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaSinhVien = masinhvien, IdHocKy = idhocky });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsIdSinhVien(string idSinhVien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.SinhViens WHERE IdSinhVien = @idSinhVien AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaSinhVien = @idSinhVien });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExitsGVHD SinhVienRepository Error.");
                return false;
            }
        }

    }
}
