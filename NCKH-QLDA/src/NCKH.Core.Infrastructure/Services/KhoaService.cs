using NCKH.Core.Domain.IRepository;
using NCKH.Core.Domain.IServices;
using NCKH.Core.Domain.ViewModel;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Core.Infrastructure.Services
{
    public class KhoaService : IkhoaService
    {
        private readonly IKhoaRepository _IkhoaRepository;
        public KhoaService(IKhoaRepository khoaRepository)
        {
            _IkhoaRepository = khoaRepository;

        }
        public async Task<List<KhoaViewModel>> SelectAllAsync()
        {
            return await _IkhoaRepository.SelectAllAsync();
        }
        public async Task<SearchResult<KhoaViewModel>> SelectByIdAsync(string idKhoa)
        {
            return await _IkhoaRepository.SelectByIdAsync(idKhoa);
        }
    }
}
