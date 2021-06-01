using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IRepository;
using NCKH.Infrastruture.Binding.ViewModel;
using NCKH.Core.Domain.ViewModel;
using NCKH.Core.Domain.Models;

namespace GHM.NailSpa.Infrastructure.Repository
{
    public class NganhRepository : INganhRepository
	{
		private readonly string _connectionString;
		private readonly ILogger<NganhRepository> _logger;

		public NganhRepository(string connectionString, ILogger<NganhRepository> logger)
		{
			_connectionString = connectionString;
			_logger = logger;
		}

		//public async Task<SearchResult<NganhSearchViewModel>> SearchAsync(string keyword, int page, int pageSize)
		//{
		//	try
		//	{
		//		using (SqlConnection con = new SqlConnection(_connectionString))
		//		{
		//			if (con.State == ConnectionState.Closed)
		//				await con.OpenAsync();

		//			DynamicParameters param = new DynamicParameters();
		//			param.Add("@Keyword", keyword);
		//			param.Add("@page", page);
		//			param.Add("@pageSize", pageSize);

		//			using (var multi = await con.QueryMultipleAsync("[dbo].[spNganh_Search]", param, commandType: CommandType.StoredProcedure))
		//			{
		//				return new SearchResult<NganhSearchViewModel>
		//				{
		//					TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
		//					Data = (await multi.ReadAsync<NganhSearchViewModel>()).ToList()
		//				};
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex, "[dbo].[spNganh_Search] SearchAsync NganhRepository Error.");
		//		return new SearchResult<NganhSearchViewModel> { TotalRows = 0, Data = null };
		//	}
		//}


		public async Task<List<NganhSearchViewModel>> SelectAllAsync()
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var results = await con.QueryAsync<NganhSearchViewModel>("[dbo].[spNganh_SelectAll]");
					return results.ToList();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spNganh_SelectAll] SelectAllAsync NganhRepository Error.");
				return new List<NganhSearchViewModel>();
			}
		}


		public async Task<int> InsertAsync(Nganh nganh)
		{
			try
			{
				int rowAffected = 0;
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@Id", nganh.Id);
					param.Add("@MaNganh", nganh.MaNganh);
					param.Add("@TenNganh", nganh.TenNganh);
					param.Add("@IdBoMon", nganh.IdBoMon);
					if (nganh.NgayTao != null && nganh.NgayTao != DateTime.MinValue)
					{
						param.Add("@NgayTao", nganh.NgayTao);
					}
					param.Add("@IsDelete", nganh.IsDelete);
					param.Add("@IsActive", nganh.IsActive);
					if (nganh.NgayCapNhat != null && nganh.NgayCapNhat != DateTime.MinValue)
					{
						param.Add("@NgayCapNhat", nganh.NgayCapNhat);
					}
					if (nganh.NgayXoa != null && nganh.NgayXoa != DateTime.MinValue)
					{
						param.Add("@NgayXoa", nganh.NgayXoa);
					}
					rowAffected = await con.ExecuteAsync("[dbo].[spNganh_Insert]", param, commandType: CommandType.StoredProcedure);
				}
				return rowAffected;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spNganh_Insert] InsertAsync NganhRepository Error.");
				return -1;
			}
		}


		//public async Task<int> UpdateAsync(Nganh nganh)
		//{
		//	try
		//	{
		//		int rowAffected = 0;
		//		using (SqlConnection con = new SqlConnection(_connectionString))
		//		{
		//			if (con.State == ConnectionState.Closed)
		//				await con.OpenAsync();

		//			DynamicParameters param = new DynamicParameters();
		//			param.Add("@Id", nganh.Id);
		//			param.Add("@MaNganh", nganh.MaNganh);
		//			param.Add("@TenNganh", nganh.TenNganh);
		//			param.Add("@IdBoMon", nganh.IdBoMon);
		//			if (nganh.NgayTao != null && nganh.NgayTao != DateTime.MinValue)
		//			{
		//				param.Add("@NgayTao", nganh.NgayTao);
		//			}
		//			param.Add("@IsDelete", nganh.IsDelete);
		//			param.Add("@IsActive", nganh.IsActive);
		//			if (nganh.NgayCapNhat != null && nganh.NgayCapNhat != DateTime.MinValue)
		//			{
		//				param.Add("@NgayCapNhat", nganh.NgayCapNhat);
		//			}
		//			if (nganh.NgayXoa != null && nganh.NgayXoa != DateTime.MinValue)
		//			{
		//				param.Add("@NgayXoa", nganh.NgayXoa);
		//			}
		//			rowAffected = await con.ExecuteAsync("[dbo].[spNganh_Update]", param, commandType: CommandType.StoredProcedure);
		//		}
		//		return rowAffected;
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex, "[dbo].[spNganh_Update] UpdateAsync NganhRepository Error.");
		//		return -1;
		//	}
		//}


		//public async Task<int> DeleteAsync(Nganh nganh)
		//{
		//	try
		//	{
		//		int rowAffected = 0;
		//		using (SqlConnection con = new SqlConnection(_connectionString))
		//		{
		//			if (con.State == ConnectionState.Closed)
		//				await con.OpenAsync();

		//			DynamicParameters param = new DynamicParameters();
		//			param.Add("@Id", nganh.Id);
		//			param.Add("@DeleteUserId", nganh.DeleteUserId);
		//			param.Add("@DeleteFullName", nganh.DeleteFullName);
		//			rowAffected = await con.ExecuteAsync("[dbo].[spNganh_DeleteByID]", param, commandType: CommandType.StoredProcedure);
		//		}
		//		return rowAffected;
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex, "[dbo].[spNganh_DeleteByID] DeleteAsync NganhRepository Error.");
		//		return -1;
		//	}
		//}


		public async Task<int> ForceDeleteAsync(string id)
		{
			try
			{
				int rowAffected = 0;
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@Id", id);
					rowAffected = await con.ExecuteAsync("[dbo].[spNganh_ForceDeleteByID]", param, commandType: CommandType.StoredProcedure);
				}
				return rowAffected;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spNganh_ForceDeleteByID] ForceDeleteAsync NganhRepository Error.");
				return -1;
			}
		}


        public async Task<Nganh> GetInfoAsync(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", id);
                    return await con.QuerySingleOrDefaultAsync<Nganh>("[dbo].[spNganh_SelectByID]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[dbo].[spNganh_SelectByID] GetInfoAsync NganhRepository Error.");
                return null;
            }
        }


        public async Task<bool> CheckExistsAsync(string id)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM Nganhs WHERE Id = @Id AND IsDelete = 0), 1, 0)";

					var result = await con.ExecuteScalarAsync<bool>(sql, new { Id = id });
					return result;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "CheckExistsAsync NganhRepository Error.");
				return false;
			}
		}


		//public async Task<bool> CheckExistsNameAsync(string id, string name)
		//{
		//	try
		//	{
		//		using (SqlConnection con = new SqlConnection(_connectionString))
		//		{
		//			if (con.State == ConnectionState.Closed)
		//				await con.OpenAsync();

		//			var sql = @"
		//			SELECT IIF (EXISTS (SELECT 1 FROM Nganhs WHERE Id != @Id AND Name = @Name AND IsDelete = 0), 1, 0)";

		//			var result = await con.ExecuteScalarAsync<bool>(sql, new { Id = id, Name = name });
		//			return result;
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex, "CheckExistsNameAsync NganhRepository Error.");
		//		return false;
		//	}
		//}


	}
}
