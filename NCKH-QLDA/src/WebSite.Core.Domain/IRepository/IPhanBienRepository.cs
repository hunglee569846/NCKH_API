﻿using NCKH.Infrastruture.Binding.ViewModel;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface IPhanBienRepository
    {
        Task<SearchResult<PhanBienSearchViewModel>> SelectAllByHk(string idhocky);
        Task<int> InsertByHk(PhanBien phanbien);
        Task<int> Update(PhanBien phanbien);
        Task<int> UpdateDiem(NoteMeta note,float diem,string idPhanBien);
        Task<bool> CheckExis(string idPhanBien);
        Task<bool> CheckExisPhanBien(string idGVPB, string iddetai, string idhocky, string idmonhoc);
        Task<bool> CheckExisByMaGV(string MaGV,string idhocky,string idmonhoc,string iddetai); //check bằng mã giảng viên
        Task<bool> CheckExisActive(string idphanbien);
        Task<int> DeleteAsync(string idphanbien);
    }
}
