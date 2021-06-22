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
    public class FileRepository : IFileRepository
    {
        private readonly string _connectionString;
        public FileRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        //search theo FileId hoac FolderId ten file gan dung
        public async Task<SearchResult<FileViewModel>> SearchAsync(string IdFile)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@IdFile", IdFile);
                    using (var multi = await con.QueryMultipleAsync("[dbo].[spFile_SelectByID]", para, commandType: CommandType.StoredProcedure))
                    {
                        return new SearchResult<FileViewModel>
                        {
                            Data = (await multi.ReadAsync<FileViewModel>()).ToList()
                        };
                    }

                }
            }
            catch (Exception)
            {
                return new SearchResult<FileViewModel> { TotalRows = 0, Data = null };
            }
        }
        //Search All 
        public async Task<List<FileViewModel>> SelectAllAsync(string idBoMon, int FolderId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();
                DynamicParameters para = new DynamicParameters();
                para.Add("@IdBoMon", idBoMon);
                para.Add("@FolderId", FolderId);
                var code = await con.QueryAsync<FileViewModel>("[dbo].[SpFile_SelectAll]", para, commandType: CommandType.StoredProcedure);
                return code.ToList();
            }

        }
        public async Task<int> InsertAsync(Files file)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    await con.OpenAsync();
                DynamicParameters para = new DynamicParameters();
                para.Add("@Id", file.Id);
                para.Add("@IdBoMon", file.IdBoMon);
                para.Add("@FileName", file.FileName);
                para.Add("@Type", file.Type);
                para.Add("@Size", file.Size);
                para.Add("@Url", file.Url);
                para.Add("@FolderId", file.Folderld);
                para.Add("@CreatorUserId", file.CreatorUserId);
                para.Add("@CreatorFullName", file.CreatorFullName);
                if (file.CreateDate != null && file.CreateDate != DateTime.MinValue)
                {
                    para.Add("@CreateDate", file.CreateDate);
                }
                para.Add("@IsDelete", file.IsDelete);
                para.Add("@IsActive", file.IsActive);
                var code = await con.ExecuteAsync("[dbo].[SpFiles_Insert]", para, commandType: CommandType.StoredProcedure);
                return code;
            }

        }
        public async Task<bool> CheckExistsByFolderIdName(string id, int? folderId, string fileName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    var sql = @"
					SELECT IIF (EXISTS (SELECT 1 FROM Files WHERE Id != @Id AND ISNULL(FolderId,0) = ISNULL(@folderId,0) AND IsDelete = 0 AND FileName = @FileName), 1, 0)";

                    var result = await con.ExecuteScalarAsync<bool>(sql, new { Id = id, FolderId = folderId, FileName = fileName });
                    return result;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<Files> GetInfo(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        await con.OpenAsync();

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdFile", id);
                    return await con.QuerySingleOrDefaultAsync<Files>("[dbo].[spFile_SelectByID]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "[dbo].[spFile_SelectByID] GetInfoAsync FileRepository Error.");
                return null;
            }
        }
    }
}
