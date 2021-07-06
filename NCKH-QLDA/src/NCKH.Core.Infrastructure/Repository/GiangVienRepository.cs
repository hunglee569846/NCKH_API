using Dapper;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IRepository;
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
	public class GiangVienRepository : IGiangVienRepository
	{
		private readonly string _connectionString;
		private readonly ILogger<GiangVienRepository> _logger;

		public GiangVienRepository(string connectionString, ILogger<GiangVienRepository> logger)
		{
			_connectionString = connectionString;
			_logger = logger;
		}

		//public async Task<SearchResult<GiangVienSearchViewModel>> SearchAsync(string keyword, int page, int pageSize)
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

		//			using (var multi = await con.QueryMultipleAsync("[dbo].[spGiangVien_Search]", param, commandType: CommandType.StoredProcedure))
		//			{
		//				return new SearchResult<GiangVienSearchViewModel>
		//				{
		//					TotalRows = (await multi.ReadAsync<int>()).SingleOrDefault(),
		//					Data = (await multi.ReadAsync<GiangVienSearchViewModel>()).ToList()
		//				};
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex, "[dbo].[spGiangVien_Search] SearchAsync GiangVienRepository Error.");
		//		return new SearchResult<GiangVienSearchViewModel> { TotalRows = 0, Data = null };
		//	}
		//}

		public async Task<List<GiangVienSearchViewModel>> SelectAllAsync()
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					var results = await con.QueryAsync<GiangVienSearchViewModel>("[dbo].[spGiangVien_SelectAll]");
					return results.ToList();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "[dbo].[spGiangVien_SelectAll] SelectAllAsync GiangVienRepository Error.");
				return new List<GiangVienSearchViewModel>();
			}
		}
		public async Task<SearchResult<ThongTinGiangVienViewModel>> GetInfoAsync(string idgiangvien)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					if (con.State == ConnectionState.Closed)
						await con.OpenAsync();

					DynamicParameters param = new DynamicParameters();
					param.Add("@IdGiangVien", idgiangvien);
					var results = await con.QueryAsync<ThongTinGiangVienViewModel>("[dbo].[spThongTinGiangVien]", param, commandType: CommandType.StoredProcedure);
                    if (results == null)
                    {
						return new SearchResult<ThongTinGiangVienViewModel>() { Code = -1, Message = "Giảng viên không tồn tại.", Data = null };

					}else
						return new SearchResult<ThongTinGiangVienViewModel>() { Code = 1, Message = "Giảng viên", Data = results };

				}
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex, "[dbo].[spThongTinGiangVien] GetInfoAsync GiangVienRepository Error.");
				return null;
			}
		}

	}
}
