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
                using (SqlConnection conn = new SqlConnection())
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

                throw;
            }
            
        }

        public async Task<int> InserAsync(ChiTietDeTai chitietdetai)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdChiTietDeTai", chitietdetai.IdChiTietDeTai);
                    param.Add("@IdDeTai", chitietdetai.IdDeTai);
                    param.Add("@MaDeTai", chitietdetai.MaDeTai);
                    param.Add("@IdGVHD", chitietdetai.IdGVHD);
                    param.Add("@MaGVHD", chitietdetai.MaGVHD);
                    param.Add("@TenGVHD", chitietdetai.TenGVHD);
                    param.Add("@DiemSo", chitietdetai.DiemSo);
                    param.Add("@NhanXet", chitietdetai.NhanXet);
                    param.Add("@NgayTao", chitietdetai.NgayTao);
                    param.Add("@NgaySua", chitietdetai.NgaySua);
                    param.Add("@NgayXoa", chitietdetai.NgaySua);
                    param.Add("@MaNguoiTao", chitietdetai.MaNguoiTao);
                    param.Add("@TenNguoiTao", chitietdetai.TenNguoiTao);
                    param.Add("@IsDelete", chitietdetai.IsDelete);
                    param.Add("@IsActive", chitietdetai.IsActive);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spChiTietDeTai_Insert]", param, commandType: CommandType.StoredProcedure);
                    return rowAffect;
                    
                }
            }
            catch (Exception)
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
    }

}
