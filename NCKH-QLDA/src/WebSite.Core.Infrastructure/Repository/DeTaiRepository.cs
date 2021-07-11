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
            catch (Exception)
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

        public async Task<SearchResult<DeTaiSearchViewModel>> SelectChuaPhanHD(string idhocky, string idmonhoc,string idBoMon)
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
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDetai_SearchChuaPhanHD]", para, commandType: CommandType.StoredProcedure))
                    {
                        var totalRows = (await multi.ReadAsync<int>()).SingleOrDefault();
                        var data = (await multi.ReadAsync<DeTaiSearchViewModel>()).ToList();
                        if (totalRows == 0 || data == null)
                        {
                            return new SearchResult<DeTaiSearchViewModel>() { Code = 1, Data = null, Message = "Không có đề tài chưa phân hội đồng." };
                        }
                        return new SearchResult<DeTaiSearchViewModel>()
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
                return new SearchResult<DeTaiSearchViewModel> { TotalRows = 0, Data = null ,Code = -1};
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
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.HocKys WHERE IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

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
        public async Task<int> InsertAsync(DeTai deTai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdDeTai", deTai.IdDeTai);
                    param.Add("@IdBoMon", deTai.IdBoMon);
                    param.Add("@MaDeTai", deTai.MaDeTai);
                    param.Add("@TenDeTai", deTai.TenDeTai);
                    param.Add("@IdSinhVien", deTai.IdSinhVien);
                    param.Add("@IdHocKy", deTai.IdHocKy);
                    param.Add("@IdMonHoc", deTai.IdMonHoc);
                    param.Add("@DiemTrungBinh", deTai.DiemTrungBinh);
                    param.Add("@IsDat", deTai.IsDat);
                    param.Add("@IsApprove", deTai.IsApprove);
                    param.Add("@IsActive", deTai.IsActive);
                    param.Add("@IsDelete", deTai.IsDelete);
                    if (deTai.CreateTime != null && deTai.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", deTai.CreateTime);
                    }
                    if (deTai.DeleteTime != null && deTai.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeteteTime", deTai.DeleteTime);
                    }
                    if (deTai.LastUpdate != null && deTai.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", deTai.LastUpdate);
                    }
                    param.Add("@lastUpdateUserId", deTai.lastUpdateUserId);
                    param.Add("@DeleteUserId", deTai.DeleteUserId);
                    param.Add("@CreatorUserId", deTai.CreatorUserId);
                    param.Add("@CreatorFullName", deTai.CreatorFullName);
                    param.Add("@LastUpdateFullName", deTai.LastUpdateFullName);
                    param.Add("@DeleteFullName", deTai.DeleteFullName);


                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_InsertAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_InsertAsync] InsertAsync DeTaiRepository Error.");
                return -1;
            }
        }

        public async Task<int> UpdateAsync(DeTai deTai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdDeTai", deTai.IdDeTai);
                    param.Add("@IdBoMon", deTai.IdBoMon);
                    param.Add("@MaDeTai", deTai.MaDeTai);
                    param.Add("@TenDeTai", deTai.TenDeTai);
                    param.Add("@IdSinhVien", deTai.IdSinhVien);
                    param.Add("@IdHocKy", deTai.IdHocKy);
                    param.Add("@IdMonHoc", deTai.IdMonHoc);
                    param.Add("@DiemTrungBinh", deTai.DiemTrungBinh);
                    param.Add("@IsDat", deTai.IsDat);
                    param.Add("@IsApprove", deTai.IsApprove);
                    param.Add("@IsActive", deTai.IsActive);
                    param.Add("@IsDelete", deTai.IsDelete);
                    if (deTai.CreateTime != null && deTai.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", deTai.CreateTime);
                    }
                    if (deTai.DeleteTime != null && deTai.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeteteTime", deTai.DeleteTime);
                    }
                    if (deTai.LastUpdate != null && deTai.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", deTai.LastUpdate);
                    }
                    param.Add("@lastUpdateUserId", deTai.lastUpdateUserId);
                    param.Add("@DeleteUserId", deTai.DeleteUserId);
                    param.Add("@CreatorUserId", deTai.CreatorUserId);
                    param.Add("@CreatorFullName", deTai.CreatorFullName);
                    param.Add("@LastUpdateFullName", deTai.LastUpdateFullName);
                    param.Add("@DeleteFullName", deTai.DeleteFullName);


                    rowAffect = await conn.ExecuteAsync("[dbo].[spDeTai_UpdateAsync]", param, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteAsync(string iddetai, string deleteUserId,string deleteFullName,DateTime deteteTime)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", iddetai?.Trim());
                    para.Add("@DeleteUserId", deleteUserId?.Trim());
                    para.Add("@DeleteFullName", deleteFullName?.Trim());
                    para.Add("@DeteteTime", deteteTime);
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

        public async Task<bool> CheckIsDat(string idmonhoc, string idsinhvien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdSinhVien = @idsinhvien AND IdMonHoc = @idmonhoc AND IsActive = 1 AND IsDelete = 0 AND IsDat = 1), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdSinhVien = idsinhvien, IdMonHoc = idmonhoc });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsSinhVien(string idhocky, string idmonhoc, string idsinhvien)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.DeTais WHERE IdSinhVien = @idsinhvien AND IdMonHoc = @idmonhoc AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdSinhVien = idsinhvien, IdMonHoc = idmonhoc, IdHocKy= idhocky });
                    return result;
                }
            }
            catch (Exception)
            {
                // _logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }

        public async Task<List<DeTai>> SelectList(string idhocky, string idMonHoc, string idBoMon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdBoMon", idBoMon);
                    para.Add("@IdHocKy", idhocky);
                    para.Add("@IdMonHoc", idMonHoc);
                    var result = await conn.QueryAsync<DeTai>("[dbo].[spDeTai_SelectListByMonHoc]", para, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spDeTai_SelectListByMonHoc] GetInfoAsync DeTaiRepository Error.");
                return null;
            }
        }

        public async Task<SearchResult<DeTaiPhanBienViewModel>> DeTaiPhanBien(string idhocky, string idmonhoc, string IdBoMon, string IdGVHD)
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
                    para.Add("@IdBoMon", IdBoMon);
                    para.Add("@IdGVHD", IdGVHD);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDeTai_LocChiTietDT]", para, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<DeTaiPhanBienViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<DeTaiPhanBienViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spHocKy_SelectAll] SearchAsync GiangVienHuongDanRepository Error.");
                return new SearchResult<DeTaiPhanBienViewModel> { TotalRows = 0, Data = null };
            }
        }

        public async Task<bool> CheckDeTaiVsMonHoc(string idhocky, string idmonhoc, string idDeTai , string idBoMon)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF(EXISTS(SELECT 1 FROM dbo.DeTais WHERE IdBoMon = @idBoMon AND IdDeTai = @idDeTai 
                    AND IdMonHoc = @idmonhoc AND IdHocKy = @idhocky AND IsActive = 1 AND IsDelete = 0 ),1,0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdBoMon = @idBoMon, IdDeTai = @idDeTai, IdMonHoc = @idmonhoc, IdHocKy = idhocky });
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
