using Dapper;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Repository
{
    public class KhoaRepository : IKhoaRepository
    {
		private readonly string _connectionString;
		//private readonly string _IKhoaRepository;
		public KhoaRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<List<KhoaViewModel>> SelectAllAsync()
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				if (conn.State == ConnectionState.Closed)
					await conn.OpenAsync();
				var Result = await conn.QueryAsync<KhoaViewModel>("[dbo].[spKhoa_SelectAll]");
				return Result.ToList();
			}

		}

		public async Task<SearchResult<KhoaViewModel>> SelectByIdAsync(string idKhoa)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				if (conn.State == ConnectionState.Closed)
					await conn.OpenAsync();
				DynamicParameters param = new DynamicParameters();
				param.Add("@Id", idKhoa);
				using (var multi = await conn.QueryMultipleAsync("[dbo].[spKhoa_SelectByID]", param, commandType: CommandType.StoredProcedure))
				{
					var listKhoas = await multi.ReadAsync<KhoaViewModel>();
					if (listKhoas.Count() == 0)
					{
						return new SearchResult<KhoaViewModel> { TotalRows = 0, Data = null,Code = -1};
					}
					else
					{
						return new SearchResult<KhoaViewModel>
						{
							Code = 1,
							Data = listKhoas
						};
					}
				}
			}
		}
	}
}
