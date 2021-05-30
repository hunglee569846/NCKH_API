using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;

namespace WebSite.Core.Domain.IServices
{
    public interface IBangDiemService
    {
        Task<ActionResultResponese<string>> InsertAsync(BangDiemMeta bangdiemMeta,string creatorUserId,string creatorFullName );
    }
}
