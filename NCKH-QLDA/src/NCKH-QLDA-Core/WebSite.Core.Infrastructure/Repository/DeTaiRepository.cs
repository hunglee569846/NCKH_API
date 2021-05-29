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
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Infrastructure.Repository
{
    public class DeTaiRepository : IDeTaiRepository
    {
        private readonly string _connectionString;
        public DeTaiRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<SearchResult<DeTaiSearchViewModel>> SelectByIdHocKy(string idhocky)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDeTai_SelectByIdHocKyAsync]", para, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<DeTaiSearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<DeTaiSearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<DeTaiSearchViewModel> { TotalRows = 0, Data = null, Code = -1 };
            }
        }
        
        public async Task<SearchResult<DeTaiSearchViewModel>> SelectByIdMonHocInHocKy(string idhocky,string idmonhoc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
                    para.Add("@IdMonHoc", idmonhoc);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDeTai_SelectByIdMonHocInHocKyAsync]", para, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<DeTaiSearchViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<DeTaiSearchViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<DeTaiSearchViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<bool> CheckExitsActive(string idhocky, string idmonhoc)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdHocKy = @idhocky  AND IdMonHoc = @idmonhoc AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idhocky, IdMonHoc = idmonhoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExistActiveAsync GiangVienHuongDanTheoKyRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsKyHoc(string idhocky)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdHocKy = idhocky });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExitsKyHoc DetaiRepository Error.");
                return false;
            }
        }
        public async Task<int> InsertAsync(DeTai detai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", detai.IdDeTai);
                    para.Add("@MaDeTai", detai.MaDeTai);
                    para.Add("@TenDeTai", detai.TenDeTai);
                    para.Add("@IdSinVien", detai.IdSinhVien);
                    para.Add("@TenSinhVien", detai.TenSinhVien);
                    para.Add("@IdHocKy", detai.IdHocKy);
                    para.Add("@TenHocKy", detai.TenHocKy);
                    para.Add("@IdMonHoc", detai.IdMonHoc);
                    para.Add("@TenMonHoc", detai.TenMonHoc);
                    para.Add("@DiemTrungBinh", detai.DiemTrungBinh);
                    para.Add("@IsDat", detai.IsDat);
                    para.Add("@IsActive", detai.IsActive);
                    para.Add("@IsDelete", detai.IsDelete);
                    para.Add("@NgayTao", detai.NgayTao);
                    para.Add("@DonViThucTap", detai.DonViThucTap);
                    para.Add("@Email", detai.Email);
                    para.Add("@IsApprove", detai.IsApprove);
                    para.Add("@MaSinhVien", detai.MaSinhVien);
                    para.Add("@MaNguoiTao", detai.MaNguoiTao);
                    para.Add("@TenNguoiTao", detai.TenNguoiTao);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_InsertAsync]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_InsertAsync] InsertAsync DeTaiRepository Error.");
                return -1;
            }
        }

        public async Task<int> UpdateAsync(DeTai detai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", detai.IdDeTai);
                    para.Add("@TenDeTai", detai.TenDeTai);
                    para.Add("@NgaySua", detai.NgaySua);
                    para.Add("@MaNguoiSua", detai.MaNguoiSua);
                    para.Add("@TenNguoiSua", detai.TenNguoisua);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_UpdateAsync]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_UpdateAsync] UpdateAsync DeTaiRepository Error.");
                return -1;
            }
        }

        public async Task<int> UpdateApproveAsync(string iddetai, bool isApprove)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", iddetai);
                    para.Add("@IsApprove", isApprove);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_UpDateAprove]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_UpDateAprove] UpdateApproveAsync DeTaiRepository Error.");
                return -1;
            }
        }
        //kiem tra ban ghi ton tai
        public async Task<bool> CheckExits(string iddetai) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdDeTai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdDeTai = iddetai });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExits DetaiRepository Error.");
                return false;
            }
        } 
        // kiem tra phe duyet
        public async Task<bool> CheckApprove(string iddetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdDeTai = @iddetai AND IsActive = 1 AND IsDelete = 0 AND IsApprove = 1), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdDeTai = iddetai });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckExits DetaiRepository Error.");
                return false;
            }
        }
        public async Task<bool> CheckMaDeTai(string madetai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE MaDeTai = @iddetai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaDeTai = madetai });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }

        public async Task<SearchResult<DeTaivsCTDTViewModel>> SelectByIdCTDTAsync(string idhocky,bool isApprove)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdHocKy", idhocky);
                    para.Add("@IsApprove", isApprove);
                   
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDetai_SearchByHK]", para, commandType: CommandType.StoredProcedure))
                    {
                        var totalrow = (await multi.ReadAsync<int>()).SingleOrDefault();
                        var detai = (await multi.ReadAsync<DeTaivsCTDTViewModel>()).ToList();
                        var chitietdetai = (await multi.ReadAsync<ChiTietDeTaiViewModel>()).ToList();
                        
                        
                        if (detai == null || detai.Count == 0)
                        {
                            return new SearchResult<DeTaivsCTDTViewModel> { TotalRows = 0, Data = null, Code = -1 };
                        }
                        else
                        {
                            detai.ForEach(x =>
                            {
                                x.ChiTietDeTai = chitietdetai.Where(iu => iu.IdDeTai == x.IdDeTai).ToList();

                            });

                            return new SearchResult<DeTaivsCTDTViewModel>
                            {
                                TotalRows = totalrow,
                                Data = detai
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<DeTaivsCTDTViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<DeTai> GetInfo(string iddetai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", iddetai);
                    return await conn.QuerySingleOrDefaultAsync<DeTai>("[dbo].[spDeTai_GetInfo]", para, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_GetInfo] GetInfoAsync DeTaiRepository Error.");
                return null;
            }
        }

        public async Task<int> DeleteAsync(string iddetai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", iddetai);
                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_DeleteAsync]", para, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_GetInfo] GetInfoAsync DeTaiRepository Error.");
                return -1;
            }
        }

        public async Task<bool> CheckIsDat(string idmonhoc, string maSinhVien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE MaSinhVien = @maSinhVien AND IdMonHoc = @idmonhoc AND IsActive = 1 AND IsDelete = 0 AND IsDat = 1), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { MaSinhVien = maSinhVien, IdMonHoc = idmonhoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }
    }
}
