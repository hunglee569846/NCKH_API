using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.ModelMeta;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IServices
{
    public interface ISinhVienService
    {
        Task<ActionResultResponese<string>> InsertAsync(SinhVienMeta sinhvienMeta,string idhocky, string creatorUserId, string creatorFullName, string idBoMon);
        Task<ActionResultResponese<string>> InsertListAsync(List<SinhVienMeta> sinhvienMeta,string idhocky, string creatorUserId, string creatorFullName,string idBoMon);
        Task<SearchResult<SinhVienSearchViewModel>> SelectAllAsync(string idhocky, string idBoMon);
        Task<SearchResult<SinhVienSearchViewModel>> GetByIdAsync(string idsinhvien);
        Task<SearchResult<SinhVienSearchViewModel>> GetChuaDeTai(string idhocky, string idmonhoc, string idBoMon);
        Task<ActionResultResponese<string>> UpdateAsync(string lastUpdateUserId, string lastUpdateFullName,string idbomon, string idSinhVien, SinhVienMeta sinhVienMeta);
        Task<ActionResultResponese<string>> UpdateDonViThucTap (List<UpDateDonViTTMeta> donViThucTapMeta, string LastUpdateUserId, string LastUpDateFullName);
        //Task<ActionResultResponese<string>> InsertListGVHDAsync(List<GiangVienListMeta> gvhdlistMeta, string idhocky, string CreatorUserId, string CreatorFullName);
        //Task<ActionResultResponese<string>> UpdateAsync(GVHDupdateMeta gvhdkyUpdateMeta, string idGVHD, string idGvhdTheoKy, TypeGVHD tygvhd, string LastUpdateUserId, string LastUpdateFullName);
        //Task<ActionResultResponese<string>> DeleteAsync(string idgvhdTheoky, string deleteUserId, string deleteFullName);
       
        //Theem sinh viên file Excel
        Task<ActionResultResponese<string>> InsertFromExcelAsync(string idfile, string idhocky, string creatorUserId, string creatorFullName, string idBoMon);

        //Xuat sinh viên file Excel tao de tai

        //Task<Stream> XuatSinhVienExcel(string idhocky, string idBoMon);

    }
}
