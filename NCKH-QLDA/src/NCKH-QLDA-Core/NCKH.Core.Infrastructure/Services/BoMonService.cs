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
    public class BoMonService : IBoMonService
    {
        private readonly IBoMonRepository _IBoMonRepository;
        private readonly IKhoaRepository _IKhoaRepository;
        public BoMonService(IKhoaRepository khoaRepository, IBoMonRepository boMonRepository)
        {
            _IKhoaRepository = khoaRepository;
            _IBoMonRepository = boMonRepository;

        }
        public async Task<List<BoMonSearchViewModel>> SelectAllAsync()
        {
            return await _IBoMonRepository.SelectAllAsync();
        }
        public async Task<SearchResult<BoMonSearchViewModel>> SearchByIdBoMon(string idBoNon)
        {
            return await _IBoMonRepository.SearchByIdBoMon(idBoNon);
        }
        public async Task<SearchResult<BoMonSearchViewModel>> SearchByIdKhoa(string idKhoa)
        {
            return await _IBoMonRepository.SearchByIdKhoa(idKhoa);
        }
    }
}
