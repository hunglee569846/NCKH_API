using Dapper;
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
    public class BoMonRepository : IBoMonRepository
    {
        private readonly string _connectionString;
       // private readonly string _IBoMonRepository;
        public BoMonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<BoMonSearchViewModel>> SelectAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                var Result = await conn.QueryAsync<BoMonSearchViewModel>("[dbo].[spBoMo_SelectAll]");
                return Result.ToList();
            }

        }
        public async Task<SearchResult<BoMonSearchViewModel>> SearchByIdBoMon(string idBoMon)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", idBoMon);
                using (var multi = await conn.QueryMultipleAsync("[dbo].[spBoMon_SelectByID]", param, commandType: CommandType.StoredProcedure))
                {
                    var listKhoas = await multi.ReadAsync<BoMonSearchViewModel>();
                    if (listKhoas.Count() == 0)
                    {
                        return new SearchResult<BoMonSearchViewModel> { TotalRows = 0, Data = null, Code = -1 };
                    }
                    else
                    {
                        return new SearchResult<BoMonSearchViewModel>
                        {
                            Code = 1,
                            Data = listKhoas
                        };
                    }
                }
            }
        }

       public async Task<SearchResult<BoMonSearchViewModel>> SearchByIdKhoa(string idKhoa)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                DynamicParameters param = new DynamicParameters();
                param.Add("@IdKhoa", idKhoa);
                using (var multi = await conn.QueryMultipleAsync("[dbo].[spBoMon_SearchByIdKhoa]", param, commandType: CommandType.StoredProcedure))
                {
                    var totalRows  = (await multi.ReadAsync<int>()).SingleOrDefault();
                    var listBoMons = await multi.ReadAsync<BoMonSearchViewModel>();
                    if (listBoMons.Count() == 0)
                    {
                        return new SearchResult<BoMonSearchViewModel> { TotalRows = 0, Data = null, Code = -1 };
                    }
                    else
                    {
                        return new SearchResult<BoMonSearchViewModel>
                        {
                            TotalRows = totalRows,
                            Code = 1,
                            Data = listBoMons
                        };
                    }
                }
            }
        }
    }
}
