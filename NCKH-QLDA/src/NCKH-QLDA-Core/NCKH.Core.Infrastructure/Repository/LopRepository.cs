using Dapper;
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

namespace NCKH.Core.Infrastructure.Repository
{
    public class LopRepository : ILopRepository
    {
        private readonly string _ConnectionString;
        private readonly ILogger<LopRepository> _logger;
        public LopRepository(string ConnectionString, ILogger<LopRepository> logger)
        {
            _ConnectionString = ConnectionString;
            _logger = logger;
        }
        public async Task<LopSearchViewModel> GetByIdLop(string id)
        {
            try

            {
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id",id);
                    return await conn.QuerySingleOrDefaultAsync<LopSearchViewModel>("dbo.spLopHoc_SelectByID", param, commandType: CommandType.StoredProcedure);
                    
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"[dbo].[spLopHoc_SelectByID] GetByIdLop Error.");
                return null;
            }
            
        }
        public async Task<List<LopSearchViewModel>> SelectAllAsync() {

            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();
                var Result = await conn.QueryAsync<LopSearchViewModel>("[dbo].[spLopHoc_SelectAll]");
                return Result.ToList();
            }
        }
    }
}
