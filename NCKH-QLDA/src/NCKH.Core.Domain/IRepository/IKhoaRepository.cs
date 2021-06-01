using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Domain.IRepository
{
    public interface IKhoaRepository
    {
        Task<List<KhoaViewModel>> SelectAllAsync();
        Task<SearchResult<KhoaViewModel>> SelectByIdAsync(string IdKhoa);

    }
}
