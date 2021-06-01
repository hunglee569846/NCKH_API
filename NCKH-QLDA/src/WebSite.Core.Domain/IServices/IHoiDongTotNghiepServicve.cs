﻿using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface IHoiDongTotNghiepService
    {
        Task<SearchResult<HoiDongTotNghiepViewModel>> GetByIdHocKy(string idhocky); 
        Task<ActionResultResponese<string>> InsertAsync(HoiDongTotNghiepMeta hoidongMeta, string idhocky, string idmonhoc, string creatorUserId, string creatorFullName); 
        Task<ActionResultResponese<string>> UpdateAsync(HoiDongTotNghiepMeta hoidongMeta, string idhoidong,string idhocky, string LastUpdateUserId, string LastUpdateFullName); 
        Task<ActionResultResponese<string>> DeleteAsync(string idhoidong); 
    }
}