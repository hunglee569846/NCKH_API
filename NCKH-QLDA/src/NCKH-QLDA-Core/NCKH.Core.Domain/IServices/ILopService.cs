using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IServices
{
    public interface ILopService
    {
        Task<ActionResultResponese<LopSearchViewModel>> GetByIdLop(string id);
        Task<List<LopSearchViewModel>> SelectAllAsync();
    }
}
