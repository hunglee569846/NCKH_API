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
    public class HoiDongToNghiepRepository : IHoiDongTotNghiepRepository
    {
        private readonly string _ConnectionString;
        public HoiDongToNghiepRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<SearchResult<HoiDongTotNghiepViewModel>> SelectAll(string idhocky,string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@IdBoMon", idbomon);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spHoiDongToNghiep_searchByHK]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<HoiDongTotNghiepViewModel>
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<HoiDongTotNghiepViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "[dbo].[spHoiDongToNghiep_searchByHK] SearchAsync HoiDongToNghiepRepository Error.");
                return new SearchResult<HoiDongTotNghiepViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<int> InsertAsync(HoiDongTotNghiep hoiDongTotNghiep)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", hoiDongTotNghiep.IdHoiDong);
                    param.Add("@IdBoMon", hoiDongTotNghiep.IdBoMon);
                    param.Add("@MaHoiDong", hoiDongTotNghiep.MaHoiDong);
                    param.Add("@TenHoiDong", hoiDongTotNghiep.TenHoiDong);
                    param.Add("@IdHocKy", hoiDongTotNghiep.IdHocKy);
                    param.Add("@IdMonHoc", hoiDongTotNghiep.IdMonHoc);
                    param.Add("@DiaDiem", hoiDongTotNghiep.DiaDiem);
                    if (hoiDongTotNghiep.NgayBaoVe != null && hoiDongTotNghiep.NgayBaoVe != DateTime.MinValue)
                    {
                        param.Add("@NgayBaoVe", hoiDongTotNghiep.NgayBaoVe);
                    }
                    if (hoiDongTotNghiep.LastUpdate != null && hoiDongTotNghiep.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", hoiDongTotNghiep.LastUpdate);
                    }
                    if (hoiDongTotNghiep.CreateTime != null && hoiDongTotNghiep.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", hoiDongTotNghiep.CreateTime);
                    }
                    param.Add("@CreatorUserId", hoiDongTotNghiep.CreatorUserId);
                    param.Add("@CreatorFullName", hoiDongTotNghiep.CreatorFullName);
                    param.Add("@LastUpdateUserId", hoiDongTotNghiep.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", hoiDongTotNghiep.LastUpdateFullName);
                    param.Add("@IsActive", hoiDongTotNghiep.IsActive);
                    param.Add("@IsDelete", hoiDongTotNghiep.IsDelete);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spHoiDongTotNghiep_Insert]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHoiDongTotNghiep_Insert] UpdateAllByIdHocKy HoiDongTotNghiepService Error.");
                return -1;
            }
        }

        public async Task<int> UpdateAsync(HoiDongTotNghiep hoiDongTotNghiep)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", hoiDongTotNghiep.IdHoiDong);
                    param.Add("@IdBoMon", hoiDongTotNghiep.IdBoMon);
                    param.Add("@MaHoiDong", hoiDongTotNghiep.MaHoiDong);
                    param.Add("@TenHoiDong", hoiDongTotNghiep.TenHoiDong);
                    param.Add("@IdHocKy", hoiDongTotNghiep.IdHocKy);
                    param.Add("@IdMonHoc", hoiDongTotNghiep.IdMonHoc);
                    param.Add("@DiaDiem", hoiDongTotNghiep.DiaDiem);
                    if (hoiDongTotNghiep.NgayBaoVe != null && hoiDongTotNghiep.NgayBaoVe != DateTime.MinValue)
                    {
                        param.Add("@NgayBaoVe", hoiDongTotNghiep.NgayBaoVe);
                    }
                    if (hoiDongTotNghiep.LastUpdate != null && hoiDongTotNghiep.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", hoiDongTotNghiep.LastUpdate);
                    }
                    if (hoiDongTotNghiep.CreateTime != null && hoiDongTotNghiep.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", hoiDongTotNghiep.CreateTime);
                    }
                    param.Add("@CreatorUserId", hoiDongTotNghiep.CreatorUserId);
                    param.Add("@CreatorFullName", hoiDongTotNghiep.CreatorFullName);
                    param.Add("@LastUpdateUserId", hoiDongTotNghiep.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", hoiDongTotNghiep.LastUpdateFullName);
                    param.Add("@IsActive", hoiDongTotNghiep.IsActive);
                    param.Add("@IsDelete", hoiDongTotNghiep.IsDelete);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spHoiDongTotNghiep_Update]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHoiDongTotNghiep_Update] UpdateAllByIdHocKy HoiDongTotNghiepService Error.");
                return -1;
            }
        }

        public async Task<bool> CheckExit(string idhoidong,string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF(EXISTS(SELECT 1 FROM dbo.HoiDongTotNghieps WHERE IdHoiDong = @idhoidong AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0 ),1,0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHoiDong = idhoidong , IdHocKy  = idhocky});
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckExitMaHD(string MaHoiDong, string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF(EXISTS(SELECT 1 FROM dbo.HoiDongTotNghieps WHERE MaHoiDong = @maHoiDong AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0 ),1,0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaHoiDong = MaHoiDong, IdHocKy = idhocky });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<HoiDongTotNghiep> GetInfo(string idhoidongtotnghiep)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", idhoidongtotnghiep);
                    return await con.QuerySingleOrDefaultAsync<HoiDongTotNghiep>("[dbo].[spHoiDongTotNghiep_GetInfo]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spHoiDongTotNghiep_SelectByID] GetInfoAsync HoiDongTotNghiepRepository Error.");
                return null;
            }

        }

        public async Task<int> DeleteAsync(string idhoidong)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDongTotNghiep", idhoidong);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spHoiDongTotNghiep_DeleteAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHoiDongTotNghiep_Update] DeleteAsync HoiDongTotNghiepRepository Error.");
                return -1;
            }
        }

        public async Task<bool> CheckExitIsActive(string idhoidong)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF(EXISTS(SELECT 1 FROM dbo.HoiDongTotNghieps WHERE IdHoiDong = @idhoidong AND IsActive = 1 AND IsDelete = 0 ),1,0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHoiDong = idhoidong});
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync HocKyRepository Error.");
                return false;
            }
        }

        public async Task<string> GetCodeHoiDong(string maBoMon)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@MaBoMon", maBoMon);
                    return await con.ExecuteScalarAsync<string>("[dbo].[spHoiDong_Code]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "GetCode ServiceRepository Error.");
                return string.Empty;
            }
        }

        public async Task<SearchResult<HoiDongTotNghiepViewModel>> GetByMonHoc(string idhocky, string idMonHoc, string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);
                    param.Add("@IdBoMon", idbomon);
                    param.Add("@IdMonHoc", idMonHoc);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spHoiDongToNghiep_SrcMonHoc]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<HoiDongTotNghiepViewModel>
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<HoiDongTotNghiepViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "[dbo].[spHoiDongToNghiep_searchByHK] SearchAsync HoiDongToNghiepRepository Error.");
                return new SearchResult<HoiDongTotNghiepViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<SearchResult<HoiDongSearchViewModel>> SearchHoiDongNgayBaoVe(string idBoMon, DateTime? ngayBatDau, DateTime? ngayKetThuc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@NgayBatDau", ngayBatDau);
                    param.Add("@NgayKetThuc", ngayKetThuc);
                    param.Add("@IdBomMon", idBoMon);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spHoiDong_SearchNgayBaoVe]", param, commandType: CommandType.StoredProcedure))
                    {
                        var TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault();
                        var listHoiDong = (await multi.ReadAsync<HoiDongSearchViewModel>()).ToList();
                        var listThanhVien = (await multi.ReadAsync<ChiTietThanhVienHDViewModel>()).ToList();
                        if(listHoiDong == null)
                        {
                            return new SearchResult<HoiDongSearchViewModel>() { Code = -1,Data = null };
                        }
                        else
                        {
                            listHoiDong.ForEach(x =>
                            {
                                x.ThanhVienHD = listThanhVien.Where(tv => tv.IdHoiDong == x.IdHoiDong).ToList();
                            });

                            return new SearchResult<HoiDongSearchViewModel>
                            {
                                TotalRows = TotalRows,
                                Data = listHoiDong
                            };
                        }
                       
                    }
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "[dbo].[spHoiDong_SearchNgayBaoVe] SearchAsync HoiDongToNghiepRepository Error.");
                return new SearchResult<HoiDongSearchViewModel> { TotalRows = 0, Data = null };
            }
        }
    }
}
