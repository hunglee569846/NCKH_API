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
    public class BangDiemRepository : IBangDiemRepository
    {
        private readonly string _ConnectionString;
        public BangDiemRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        // phan công đề tài.
        public async Task<int> InsertAsync(BangDiem bangdiem)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", bangdiem.IdBangDiem);
                    param.Add("@IdBoMon", bangdiem.IdBoMon);
                    param.Add("@IdDeTai", bangdiem.IdDeTai);
                    param.Add("@IdSinhVien", bangdiem.IdSinhVien);
                    param.Add("@IdHocKy", bangdiem.IdHocKy);
                    param.Add("@IdMonHoc", bangdiem.IdMonHoc);
                    param.Add("@IdHoiDong", bangdiem.IdHoiDong);
                    param.Add("@IdGiangVien", bangdiem.IdGiangVien);
                    param.Add("@NhanXetGV", bangdiem.NhanXetGV);
                    param.Add("@DiemSo", bangdiem.DiemSo);
                    if (bangdiem.NgayVaoDiem != null && bangdiem.NgayVaoDiem != DateTime.MinValue)
                    {
                        param.Add("@NgayVaoDiem", bangdiem.NgayVaoDiem);
                    }
                    param.Add("@CreatorPointUserId", bangdiem.CreatorPointUserId);
                    param.Add("@CreatorPointFullName", bangdiem.CreatorPointFullName);
                    if (bangdiem.CreateTime != null && bangdiem.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", bangdiem.CreateTime);
                    }
                    param.Add("@CreatorUserId", bangdiem.CreatorUserId);
                    param.Add("@CreatorFullName", bangdiem.CreatorFullName);
                    if (bangdiem.LastUpdate != null && bangdiem.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", bangdiem.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", bangdiem.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", bangdiem.LastUpdateFullName);
                    if (bangdiem.DeleteTime != null && bangdiem.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", bangdiem.DeleteTime);
                    }
                    param.Add("@DeleteUserId", bangdiem.DeleteUserId);
                    param.Add("@DeleteFullName", bangdiem.DeleteFullName);
                    param.Add("@IsActive", bangdiem.IsActive);
                    param.Add("@IsDelete", bangdiem.IsDelete);
                    rowAffected = await con.ExecuteAsync("[dbo].[spBangDiem_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spBangDie_Insert] InsertAsync BangDieRepository Error.");
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
                int rowAffected = 0;
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", bangdiem.IdBangDiem);
                    param.Add("@IdBoMon", bangdiem.IdBoMon);
                    param.Add("@IdDeTai", bangdiem.IdDeTai);
                    param.Add("@IdSinhVien", bangdiem.IdSinhVien);
                    param.Add("@IdHocKy", bangdiem.IdHocKy);
                    param.Add("@IdMonHoc", bangdiem.IdMonHoc);
                    param.Add("@IdHoiDong", bangdiem.IdHoiDong);
                    param.Add("@IdGiangVien", bangdiem.IdGiangVien);
                    param.Add("@NhanXetGV", bangdiem.NhanXetGV);
                    if (bangdiem.DiemSo >= 0 && bangdiem.DiemSo <= 10)
                    {
                        param.Add("@DiemSo", bangdiem.DiemSo);
                    }
                    if (bangdiem.NgayVaoDiem != null && bangdiem.NgayVaoDiem != DateTime.MinValue)
                    {
                        param.Add("@NgayVaoDiem", bangdiem.NgayVaoDiem);
                    }
                    param.Add("@CreatorPointUserId", bangdiem.CreatorPointUserId);
                    param.Add("@CreatorPointFullName", bangdiem.CreatorPointFullName);
                    if (bangdiem.CreateTime != null && bangdiem.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", bangdiem.CreateTime);
                    }
                    param.Add("@CreatorUserId", bangdiem.CreatorUserId);
                    param.Add("@CreatorFullName", bangdiem.CreatorFullName);
                    if (bangdiem.LastUpdate != null && bangdiem.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", bangdiem.LastUpdate);
                    }
                    param.Add("@LastUpdateUserId", bangdiem.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", bangdiem.LastUpdateFullName);
                    if (bangdiem.DeleteTime != null && bangdiem.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", bangdiem.DeleteTime);
                    }
                    param.Add("@DeleteUserId", bangdiem.DeleteUserId);
                    param.Add("@DeleteFullName", bangdiem.DeleteFullName);
                    param.Add("@IsActive", bangdiem.IsActive);
                    param.Add("@IsDelete", bangdiem.IsDelete);
                    rowAffected = await con.ExecuteAsync("[dbo].[spBanDiem_UpdateDiemHD]", param, commandType: CommandType.StoredProcedure);
                }
                return rowAffected;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spBangDie_Update] UpdateAsync BangDieRepository Error.");
                return -1;
            }

        }

        //Xuat Diem
        public async Task<SearchResult<XuatDiemPhanBienViewModel>> XuatDiemPhanBien(string idhocky, string idmonhoc,string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@idhocky", idhocky);
                    param.Add("@idmonhoc", idmonhoc);
                    param.Add("@idBoMon", idmonhoc);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spNhapDiemPhanBien_SelectAll]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<XuatDiemPhanBienViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<XuatDiemPhanBienViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new SearchResult<XuatDiemPhanBienViewModel> { Data = null, Code = 1 };
            }
        }

        public async Task<List<XuatDiemPhanBienViewModel>> XuatDiemPhanBienExcel(string idhocky, string idmonhoc, string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@idhocky", idhocky);
                    param.Add("@idmonhoc", idmonhoc);
                    param.Add("@idBoMon", idbomon);
                    var result = await conn.QueryAsync<XuatDiemPhanBienViewModel>("[dbo].[spXuatExcel_DiemPhanVien]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Diem hoi dong xuat Excel
        public async Task<List<XuatDiemHoiDongViewModel>> XuatDiemHoiDongExcel(string idhocky, string idmonhoc,string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@idhocky", idhocky);
                    param.Add("@idmonhoc", idmonhoc);
                    param.Add("@idBoMon", idbomon);
                    var result = await conn.QueryAsync<XuatDiemHoiDongViewModel>("[dbo].[spXuatExcel_DiemHoiDong]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        // xuat diem hoi dong
        public async Task<SearchResult<XuatDiemHoiDongViewModel>> XuatDiemHoiDong(string idhocky, string idmonhoc,string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@idhocky", idhocky);
                    param.Add("@idmonhoc", idmonhoc);
                    param.Add("@IdBoMon", idbomon);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spXuatDiemHoiDong_SelectAll]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<XuatDiemHoiDongViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<XuatDiemHoiDongViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new SearchResult<XuatDiemHoiDongViewModel> { Data = null, Code = 1 };
            }
        }

        public async Task<BangDiem> GetInfo(string idBangDiem)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", idBangDiem);
                    return await con.QuerySingleOrDefaultAsync<BangDiem>("[dbo].[spBangDiem_GetById]", param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "GetInfo BangDiemRepository Error.");
                return null;
            }
        }

        public async Task<List<BangDiem>> DetailDiemHD(string idbomon, string idHocKy, string idMonHoc, string idDeTai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBoMon", idbomon);
                    param.Add("@IdHocKy", idHocKy);
                    param.Add("@IdMonHoc", idMonHoc);
                    param.Add("@IdDeTai", idDeTai);
                    var result = await con.QueryAsync<BangDiem>("[dbo].[spBangDiem_SlectListByIdDeTai]", param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "GetInfo BangDiemRepository Error.");
                return null;
            }
        }

        public async Task<List<XuatDiemHoiDongViewModel>> XuatDiemHoiDongTTTNExcel(string idhocky, string idmonhoc, string idbomon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@idhocky", idhocky);
                    param.Add("@idmonhoc", idmonhoc);
                    param.Add("@idBoMon", idbomon);
                    var result = await conn.QueryAsync<XuatDiemHoiDongViewModel>("[dbo].[spXuatExcel_DiemHoiDong_TTTN]", param, commandType: CommandType.StoredProcedure);
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
