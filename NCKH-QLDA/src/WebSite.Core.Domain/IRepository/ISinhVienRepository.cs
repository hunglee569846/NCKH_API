using NCKH.Infrastruture.Binding.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;

namespace WebSite.Core.Domain.IRepository
{
    public interface ISinhVienRepository
    {
        Task<int> InsertAsync(SinhVien sinhvien);
        Task<SearchResult<SinhVienSearchViewModel>> SelectAllByHocKyAsync(string idhocky,string idbomon);
        //Task<SearchResult<GiangVienHuongDanViewModel>> SelectByIdHocKyAsync(string idhocky);
        Task<SinhVien> GetInfo(string idsinhvien);
        Task<SearchResult<SinhVienSearchViewModel>> SearchById(string idsinhvien);
        //Task<GVHDTheoKy> GetInfoByMaGVHD(string idhocky, string maGVHD);
        //Task<int> InsertAsync(GVHDTheoKy gvhdky);
        Task<int> UpdateAsync(SinhVien sinhVien);
        //Task<int> DeleteByIdAsync(string idgvhdTheoky, string deleteUserId, string deleteFullName, DateTime? ngayxoa);
        Task<bool> CheckExits(string idhocky,string masinhvien); //kiem tra sinh vien trong ky
       // Task<bool> CheckExitsActive(string idhocky, string idGVHD); //kiem tra tồn tại của GVHD trong hoc kỳ không có 2 GV giống nhau
        Task<bool> CheckExitsIdSinhVien(string idSinhVien); //kiem tra tồn tại của GVHD trong hoc kỳ
        Task<SearchResult<SinhVienSearchViewModel>> SelectChuaCoDeTai(string idhocky, string idmonhoc, string idBoMon);

        //Xuất danh sách sinh viên của môn học
        Task<List<DataSinhVienVewModel>> DataSinhVienByMonHoc(string idhocky , string idBoMon);
    }
}
