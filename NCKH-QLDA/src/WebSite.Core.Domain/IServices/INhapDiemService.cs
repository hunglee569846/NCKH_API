using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Core.Domain.IServices
{
    public interface INhapDiemService
    {
        Task<ActionResultResponese<string>> InsertListExcelAsync(string idhocky, string idmonhoc, string urlFile, string idBoMon);
    }
}
