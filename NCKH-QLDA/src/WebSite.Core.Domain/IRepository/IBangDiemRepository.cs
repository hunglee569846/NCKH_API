using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;

namespace WebSite.Core.Domain.IRepository
{
    public interface IBangDiemRepository
    {
        Task<int> InsertAsync(BangDiem bangdiem);
        Task<int> UpdateDiemAsync(BangDiem bangdiem);
        Task<bool> CheckExit(string iddetai);
        Task<bool> CheckExitIdBangDiem(string idBangDiem);
    }
}
