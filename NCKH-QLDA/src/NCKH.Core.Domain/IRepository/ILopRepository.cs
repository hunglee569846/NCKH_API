using NCKH.Core.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
    public interface ILopRepository
    {
        Task<LopSearchViewModel> GetByIdLop(string id);
        Task<List<LopSearchViewModel>> SelectAllAsync();
    }
}
