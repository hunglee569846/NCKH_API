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

        public async Task<SearchResult<HoiDongTotNghiepViewModel>> SelectAll(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHocKy", idhocky);

                    
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

        public async Task<int> InsertAsync(HoiDongTotNghiep hoidong)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", hoidong.IdHoiDong);
                    param.Add("@MaHoiDong", hoidong.MaHoiDong);
                    param.Add("@TenHoiDong", hoidong.TenHoiDong);
                    param.Add("@IdHocKy", hoidong.IdHocKy);
                    param.Add("@TenHocKy", hoidong.TenHocKy);
                    param.Add("@IdMonHoc", hoidong.IdMonHoc);
                    param.Add("@TenMonHoc", hoidong.TenMonHoc);
                    if(hoidong.NgayTao != DateTime.MinValue || hoidong.NgayTao != null)
                    {
                        param.Add("@NgayTao", hoidong.NgayTao);
                    }
                    if (hoidong.NgayBaoVe != DateTime.MinValue || hoidong.NgayBaoVe != null)
                    {
                        param.Add("@NgayBaoVe", hoidong.NgayBaoVe);
                    }
                    if (hoidong.NgaySua != DateTime.MinValue || hoidong.NgaySua != null)
                    {
                        param.Add("@NgaySua", hoidong.NgaySua);
                    }
                    param.Add("@IsActive", hoidong.IsActive);
                    param.Add("@IsDelete", hoidong.IsDelete);
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

        public async Task<int> UpdateAsync(HoiDongTotNghiep hoidong)
        {
            try
            {
                var rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdHoiDong", hoidong.IdHoiDong);
                    param.Add("@MaHoiDong", hoidong.MaHoiDong);
                    param.Add("@TenHoiDong", hoidong.TenHoiDong);
                    param.Add("@NgayBaoVe", hoidong.NgayBaoVe);
                    param.Add("@NgaySua", hoidong.NgaySua);
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
    }
}
