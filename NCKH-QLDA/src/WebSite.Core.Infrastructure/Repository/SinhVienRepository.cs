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

        public async Task<SearchResult<SinhVienSearchViewModel>> SelectAllByHocKyAsync(string idhocky,string idbomon)
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

        public async Task<SinhVien> GetInfo(string idsinhvien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdSinhVien", idsinhvien);

                    return await conn.QuerySingleOrDefaultAsync<SinhVien>("[dbo].[spSinhVien_ByIdSinhVien]", para, commandType: CommandType.StoredProcedure);

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

        public async Task<int> InsertAsync(SinhVien sinhVien)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdSinhVien", sinhVien.IdSinhVien);
                    param.Add("@IdBoMon", sinhVien.IdBoMon);
                    param.Add("@MaSinhVien", sinhVien.MaSinhVien);
                    param.Add("@TenSinhVien", sinhVien.TenSinhVien);
                    param.Add("@Email", sinhVien.Email);
                    param.Add("@DienThoai", sinhVien.DienThoai);
                    param.Add("@DonViThucTap", sinhVien.DonViThucTap);
                    param.Add("@MaLopHoc", sinhVien.MaLopHoc);
                    param.Add("@LopHoc", sinhVien.LopHoc);
                    param.Add("@IdHocKy", sinhVien.IdHocKy);
                    param.Add("@TenChuyenNganh", sinhVien.TenChuyenNganh);
                    param.Add("MaChuyenNganh", sinhVien.MaChuyenNganh);
                    if (sinhVien.CreateTime != null && sinhVien.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", sinhVien.CreateTime);
                    }
                    param.Add("@CreatorUserId", sinhVien.CreatorUserId);
                    param.Add("@CreatorFullName", sinhVien.CreatorFullName);
                    if (sinhVien.LastUpdate != null && sinhVien.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", sinhVien.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", sinhVien.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", sinhVien.LastUpdateFullName);
                    if (sinhVien.DeleteTime != null && sinhVien.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", sinhVien.DeleteTime);
                    }
                    param.Add("@DeleteUserId", sinhVien.DeleteUserId);
                    param.Add("@DeleteFullName", sinhVien.DeleteFullName);
                    param.Add("@IsActive", sinhVien.IsActive);
                    param.Add("@IsDelete", sinhVien.IsDelete);

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
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.SinhViens WHERE IdSinhVien = @idSinhVien AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdSinhVien = @idSinhVien });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExitsGVHD SinhVienRepository Error.");
                return false;
            }
        }
        public async Task<SearchResult<SinhVienSearchViewModel>> SelectChuaCoDeTai(string idhocky, string idmonhoc, string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@idHocKy", idhocky);
                    para.Add("@idMonHoc", idmonhoc);
                    para.Add("@IdBoMon", idBoMon);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spSinhVien_SearchChuaDeTai]", para, commandType: CommandType.StoredProcedure))
                    {
                        var totalRows = (await multi.ReadAsync<int>()).SingleOrDefault();
                        var data = (await multi.ReadAsync<SinhVienSearchViewModel>()).ToList();
                        if (totalRows == 0 || data == null)
                        {
                            return new SearchResult<SinhVienSearchViewModel>() { Code = 1, Data = null, Message = "Không có sinh viên chưa tạo đề tài." };
                        }
                        return new SearchResult<SinhVienSearchViewModel>()
                        {
                            Data = data,
                            TotalRows = totalRows
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDetai_SearchChuaPhanHD] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<SinhVienSearchViewModel> { TotalRows = 0, Data = null, Code = -1 };
            }
        }

        public async Task<int> UpdateAsync(SinhVien sinhVien)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdSinhVien", sinhVien.IdSinhVien);
                    param.Add("@IdBoMon", sinhVien.IdBoMon);
                    param.Add("@MaSinhVien", sinhVien.MaSinhVien);
                    param.Add("@TenSinhVien", sinhVien.TenSinhVien);
                    param.Add("@Email", sinhVien.Email);
                    param.Add("@DienThoai", sinhVien.DienThoai);
                    param.Add("@DonViThucTap", sinhVien.DonViThucTap);
                    param.Add("@MaLopHoc", sinhVien.MaLopHoc);
                    param.Add("@LopHoc", sinhVien.LopHoc);
                    param.Add("@IdHocKy", sinhVien.IdHocKy);
                    param.Add("@TenChuyenNganh", sinhVien.TenChuyenNganh);
                    if (sinhVien.CreateTime != null && sinhVien.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", sinhVien.CreateTime);
                    }
                    param.Add("@CreatorUserId", sinhVien.CreatorUserId);
                    param.Add("@CreatorFullName", sinhVien.CreatorFullName);
                    if (sinhVien.LastUpdate != null && sinhVien.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", sinhVien.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", sinhVien.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", sinhVien.LastUpdateFullName);
                    if (sinhVien.DeleteTime != null && sinhVien.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", sinhVien.DeleteTime);
                    }
                    param.Add("@DeleteUserId", sinhVien.DeleteUserId);
                    param.Add("@DeleteFullName", sinhVien.DeleteFullName);
                    param.Add("@IsActive", sinhVien.IsActive);
                    param.Add("@IsDelete", sinhVien.IsDelete);
                    rowAffected = await con.ExecuteAsync("[dbo].[spSinhVien_Update]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spSinhVien_Update] UpdateAsync SinhVienRepository Error.");
                return -1;
            }
        }

        public async Task<List<DataSinhVienVewModel>> DataSinhVienByMonHoc(string idhocky, string idBoMon)
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
                    var result = await conn.QueryAsync<DataSinhVienVewModel>("[dbo].[spSinhVienExportExcel]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<DataSinhVienVewModel>();
            }
        }
    }
}
