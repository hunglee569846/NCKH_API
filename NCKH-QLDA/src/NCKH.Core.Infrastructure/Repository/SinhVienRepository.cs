using Dapper;
using GHM.NailSpa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.Models;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
		
		private readonly string _connectionString;
		private readonly ILogger<SinhVienRepository> _logger;

		public SinhVienRepository(string connectionString, ILogger<SinhVienRepository> logger)
		{
			_connectionString = connectionString;
			_logger = logger;
		}

		public async Task<SearchResult<SinhVienSearchViewModel>> SearchAsync(string id, int page, int pageSize)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@page", page);
					param.Add("@Id", id);
					param.Add("@pageSize", pageSize);

					using (var multi = await con.QueryMultipleAsync("[dbo].[spSinhVien_Search]", param, commandType: CommandType.StoredProcedure))
					{
						return new SearchResult<SinhVienSearchViewModel>
						{
							TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
							Data = (await multi.ReadAsync<SinhVienSearchViewModel>()).ToList()
						};
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVien_Search] SearchAsync SinhVienRepository Error.");
				return new SearchResult<SinhVienSearchViewModel> { TotalRows = 0, Data = null };
			}
		}


		public async Task<List<SinhVienSearchViewModel>> SelectAllAsync()
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var results = await con.QueryAsync<SinhVienSearchViewModel>("[dbo].[spSinhVien_SelectAll]");
					return results.ToList();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVien_SelectAll] SelectAllAsync SinhVienRepository Error.");
				return new List<SinhVienSearchViewModel>();
			}
		}

		public async Task<ThongTinSinhVienViewModel> GetInfoAsync(string id)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@IdSingVien", id);
					return await con.QuerySingleOrDefaultAsync<ThongTinSinhVienViewModel>("[dbo].[spThongTinSinhVien]", param, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spThongTinSinhVien] GetInfoAsync SinhVienRepository Error.");
				return null;
			}
		}
		public async Task<ThongTinSinhVienViewModel> GetInfoByMaSinhVienAsync(string maSinhVien)
        {
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@MaSinhVien", maSinhVien);
					return await con.QuerySingleOrDefaultAsync<ThongTinSinhVienViewModel>("[dbo].[spThongTinSinhVienByMaSinhVien]", param, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spThongTinSinhVienByMaSinhVien] GetInfoByMaSinhVienAsync SinhVienRepository Error.");
				return null;
			}
		}

		public async Task<bool> CheckExistsAsync(string maSinhVien)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM dbo.SinhViens WHERE MaSinhVien = @maSinhVien AND IsDelete = 0), 1, 0)";

					var result = await con.ExecuteScalarAsync<bool>(sql, new { MaSinhVien = maSinhVien });
					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "CheckExistsAsync SinhVien Error.");
				return false;
			}
		}

		public async Task<SearchResult<SinhVienChuyenNganhViewModel>> SearchSinhVienByIdChuyenNganhAsync(string idChuyenNganh)
        {
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@IdChuyenNganh", idChuyenNganh);
					using (var multi = await con.QueryMultipleAsync("[dbo].[spSinhVienChuyenNganh_GetAll]", param, commandType: CommandType.StoredProcedure))
					{
						return new SearchResult<SinhVienChuyenNganhViewModel>
						{
							TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
							Data = (await multi.ReadAsync<SinhVienChuyenNganhViewModel>()).ToList()
						};
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spSinhVienChuyenNganh_GetAll] SearchSinhVienByIdChuyenNganhAsync SinhVienRepository Error.");
				return new SearchResult<SinhVienChuyenNganhViewModel> { TotalRows = 0, Data = null };
			}

		}

	}
}
