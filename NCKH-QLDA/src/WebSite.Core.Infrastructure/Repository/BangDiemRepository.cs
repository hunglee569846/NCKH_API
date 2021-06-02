using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Infrastructure.Repository
{
    public class BangDiemRepository : IBangDiemRepository
    {
        private readonly string _ConnectionString;
        public BangDiemRepository(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public async Task<int> InsertAsync(BangDiem bangdiem)
        {
            try
            {
                int rowAffect = 0;
                using (SqlConnection conn = new SqlConnection(_ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@IdBangDiem", bangdiem.IdBangDien);
                    param.Add("@IdDeTai", bangdiem.IdDeTai);
                    param.Add("@IdSinhVien", bangdiem.IdSinhVien);
                    param.Add("@IdHocKy", bangdiem.IdHocKy);
                    param.Add("@IdMonHoc", bangdiem.IdMonHoc);
                    param.Add("@IdHoiDong", bangdiem.IdHoiDong);
                    param.Add("@IdGiangVien", bangdiem.IdGiangVien);
                    param.Add("@NhanXetGV", bangdiem.NhanXetGV);
                    param.Add("@CreatorUserId", bangdiem.CreatorUserId);
                    param.Add("@CreatorFullName", bangdiem.CreatorFullName);
                    param.Add("@IsDelete", bangdiem.IsDelete);
                    param.Add("@IsActive", bangdiem.IsActive);

                    rowAffect = await conn.ExecuteAsync("[dbo].[spBangDiem_InsertAsync]", param, commandType: CommandType.StoredProcedure);
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
