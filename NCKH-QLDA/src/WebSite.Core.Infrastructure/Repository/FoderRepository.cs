using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Infrastructure.Repository
{
    public class FoderRepository : IFolderRepository
    {
        private readonly string _ConnectionString;
        public FoderRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public async Task<int> InsertAsync(Folder folder)
        {
            int rowaffaceted = 0;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();
                DynamicParameters para = new DynamicParameters();
                para.Add("@FolderName", folder.FolderName);
                para.Add("@IdBoMon", folder.IdBoMon);
                //para.Add("@FolderId", FolderId);
               // para.Add("@Level", folder.Level);
               // para.Add("@ChildCount", folder.ChildCount);
                //para.Add("@Description", folder.Description);
                if (folder.CreateTime != null && folder.CreateTime != DateTime.MinValue)
                {
                    para.Add("@createTime", folder.CreateTime);
                }
                para.Add("@lastUpdate", folder.LastUpdate);
                if (folder.DeleteTime != null && folder.DeleteTime != DateTime.MinValue)
                {

                    para.Add("@DeleteTime", folder.DeleteTime);
                }
                para.Add("IsDelete", folder.IsDelete);
                para.Add("@IsActive", folder.IsActive);
                rowaffaceted = await con.ExecuteAsync("[dbo].[spFolder_Insert]", para, commandType: CommandType.StoredProcedure);
            }
            return rowaffaceted;
        }
        public async Task<bool> CheckExitsFolder(int folderId)
        {

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();

                var sql = @"SELECT IIF (EXISTS (SELECT 1 FROM dbo.Folder WHERE Id =@folderId  AND IsDelete = 0), 1, 0)";

                var result = await con.ExecuteScalarAsync<bool>(sql, new { FolderId = folderId });
                return result;
            }
        }
        public async Task<Folder> GetInfoAsync(int FolderId)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", FolderId);
                return await con.QuerySingleOrDefaultAsync<Folder>("[dbo].[spFolder_SelectById]", param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Folder>> SelectAllAsync(string idBoMon)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBoMon", idBoMon);
                    var results = await con.QueryAsync<Folder>("[dbo].[spFolder_SelectAll]",param, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "[dbo].[spFolder_SelectAll] SelectAll CountryRepository Error.");
                return new List<Folder>();
            }
        }
    }
}
