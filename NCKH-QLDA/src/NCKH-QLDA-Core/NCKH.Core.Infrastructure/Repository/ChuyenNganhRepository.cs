using Dapper;
using GHM.NailSpa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace NCKH.Core.Infrastructure.Repository
{
   public class ChuyenNganhRepository : IChuyenNganhRepository
    {
        private readonly string _connectionString;
       // private readonly string _IChuyenNganhRepository;
        private readonly ILogger<ChuyenNganhRepository> _logger;
        public ChuyenNganhRepository(string connectionString, ILogger<ChuyenNganhRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        
        public async Task<ChuyenNganhSearchViewModel> ChiTietChuyenNganh(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", id);
                    return await conn.QuerySingleOrDefaultAsync<ChuyenNganhSearchViewModel>("[dbo].[spChuyenNganh_SelectByID]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[dbo].[spCustomer_SelectByIDTenantId] GetInfoAsync ChiTietChuyenNganh Error.");
                return null;
            }
        }
        public async Task<List<ChuyenNganhViewModel>> SelectAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                var Result = await conn.QueryAsync<ChuyenNganhViewModel>("[dbo].[spChuyenNganh_SelectAll]");
                return Result.ToList();
            }
        }
    }
}
