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
    public class ChiTietDeTaiRepository : IChiTietDeTaiRepository
    {
        private readonly string _ConnectionString;
        public ChiTietDeTaiRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task<SearchResult<ChiTietDeTaiViewModel>> SearchById(string iddetai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdDeTai", iddetai);
                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDeTai_SelectByIdHocKyAsync]", param, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<ChiTietDeTaiViewModel>()
                        {
                            TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
                            Data = (await multi.ReadAsync<ChiTietDeTaiViewModel>()).ToList()
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new SearchResult<ChiTietDeTaiViewModel> { Data = null, Code = 1 };
            }
            
        }

        public async Task<int> InserAsync(ChiTietDeTai chiTietDeTa)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdChiTietDeTai", chiTietDeTa.IdChiTietDeTai);
                    param.Add("@IdBoMon", chiTietDeTa.IdBoMon);
                    param.Add("@IdDeTai", chiTietDeTa.IdDeTai);
                    param.Add("@MaDeTai", chiTietDeTa.MaDeTai);
                    param.Add("@IdGVHD", chiTietDeTa.IdGVHD);
                    param.Add("@DiemSo", chiTietDeTa.DiemSo);
                    param.Add("@NhanXet", chiTietDeTa.NhanXet);
                    if (chiTietDeTa.CreateTime != null && chiTietDeTa.CreateTime != DateTime.MinValue)
                    {
                        param.Add("@CreateTime", chiTietDeTa.CreateTime);
                    }
                    if (chiTietDeTa.LastUpdate != null && chiTietDeTa.LastUpdate != DateTime.MinValue)
                    {
                        param.Add("@LastUpdate", chiTietDeTa.LastUpdate);
                    }
                    if (chiTietDeTa.DeleteTime != null && chiTietDeTa.DeleteTime != DateTime.MinValue)
                    {
                        param.Add("@DeleteTime", chiTietDeTa.DeleteTime);
                    }
                    param.Add("@CreatorUserId", chiTietDeTa.CreatorUserId);
                    param.Add("@CreatorFullName", chiTietDeTa.CreatorFullName);
                    param.Add("@LastUpdateUserId", chiTietDeTa.LastUpdateUserId);
                    param.Add("@LastUpdateFullName", chiTietDeTa.LastUpdateFullName);
                    param.Add("@DeleteUserId", chiTietDeTa.DeleteUserId);
                    param.Add("@DeleteFullName", chiTietDeTa.DeleteFullName);
                    param.Add("@IsDelete", chiTietDeTa.IsDelete);
                    param.Add("@IsActive", chiTietDeTa.IsActive);


                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietDeTai_Insert]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                    
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<bool> CheckExits(string idChiTietDeTai)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.ChiTietDeTai WHERE IdChiTietDeTai = @idChiTietDeTai AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdChiTietDeTai = idChiTietDeTai });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckMaDeTai DetaiRepository Error.");
                return false;
            }
        }

        public async Task<bool> CheckExitsDuplicate(string idDeTai, string idGVHD)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.ChiTietDeTai WHERE IdDeTai = @idDeTai AND IdGVHD = @idGVHD AND IsActive = 1 AND IsDelete = 0), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { IdDeTai = idDeTai, IdGVHD = idGVHD });
                    return result;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "CheckDuplicate CTDT DetaiRepository Error.");
                return false;
            }
        }
        public async Task<SearchResult<DeTaivsCTDTViewModel>> SearchByIdDetai(string iddetai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdDeTai", iddetai);

                    using (var multi = await conn.QueryMultipleAsync("[dbo].[spDetai_SearchCT]", para, commandType: CommandType.StoredProcedure))
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

        public async Task<int> DeleteAsync(string idchitietdetai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdChiTietDeTai", idchitietdetai);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietDeTai_DeleteAsync]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;

                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> CountGiangVienHD(string idDeTai)
        {
            try
            {
                int Results = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    var sql = @"
					SELECT ISNULL(COUNT(0),1)   FROM dbo.ChiTietDeTai WHERE IdDetai = @idDeTai AND  IsActive =1 AND IsDelete = 0 ";

                    Results = await conn.ExecuteScalarAsync<int>(sql, new { IdDetai = idDeTai });
                    return Results;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_DeleteAsync] PhanBienRepository Error.");
                return -1;
            }
        }

        public async Task<List<ChiTietDeTaiViewModel>> GetCheckGVHDnotPB(string iddetai)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdDeTai", iddetai);

                    var rowAffect = await conn.QueryAsync<ChiTietDeTaiViewModel>("[dbo].[spChiTietDeTai_GetList]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect.ToList();

                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spPhanBien_DeleteAsync] PhanBienRepository Error.");
                return null;
            }
        }
    }

}
