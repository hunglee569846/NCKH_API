using NCKH.Infrastruture.Binding.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class NhapDiemService
    {

        private readonly IPhanBienRepository _phanBienRepository;
        private readonly IBangDiemRepository _bangdiemRepository;
        public NhapDiemService(IPhanBienRepository phanBienRepository,
                               IBangDiemRepository bangdiemRepository )
        {
            _phanBienRepository = phanBienRepository;
            _bangdiemRepository = bangdiemRepository;
        }

        /// <summary>
        /// chu y duong dan lay file excel la lay tu upload cua API upFile
        /// 
        /// </summary>
        /// <param name="NhapDiemService"></param>
        /// <returns></returns>
        //public async Task<ActionResultResponese<string>> InsertListExcelAsync(string idhocky,string idmonhoc, string urlFile)
        //{
        //    var info = await _phanBienRepository.GetInfoAsync(urlFile);
        //    if (info == null)
        //        return new ActionResultResponese<string>(-2, "Phản biện không tồn tại.", "Phản biện.");
        //    List<XuatDiemPhanBienViewModel> phanbien = new List<XuatDiemPhanBienViewModel>();
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    using (var pakage = new ExcelPackage(new FileInfo(urlFile)))
        //    {
        //        ExcelWorksheet worsheet = pakage.Workbook.Worksheets[0];
        //        for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
        //        {
        //            //StudentTest st1 = new StudentTest();
        //            int j = 1;
        //            string idPhanBien = worsheet.Cells[i, j++].Value.ToString();
        //            string diem = worsheet.Cells[i, j++].Value.ToString();
        //            string note = worsheet.Cells[i, j++].Value.ToString();
        //            float diemphanbien = float.Parse(diem);
        //            XuatDiemPhanBienViewModel _phanbienlist = new XuatDiemPhanBienViewModel()
        //            {
        //                IdPhanBien = idPhanBien?.Trim(),
        //                Diem = diemphanbien,
        //                Note = note?.Trim(),
        //            };
        //            phanbien.Add(_phanbienlist);
        //        }
        //        #region
        //        //int dem = 0;
        //        //foreach (var item in departmentlist)
        //        //{
        //        //    var idfaculty = await _facultyRepository.CheckExitsFacult(NameFaculty);
        //        //    if (!idfaculty)
        //        //        return new ActionResultResponese<string>(-21, "khoa khong ton tai", "Faculty");

        //        //    var namedeartment = await _departmentRepository.CheckExitsDepartment(item.NameDepartment);
        //        //    if (namedeartment)
        //        //        return new ActionResultResponese<string>(-22, "Bo mon da ton tai", "Department");
        //        //    var _department = new Department
        //        //    {
        //        //        IdDepartment = Guid.NewGuid().ToString(),
        //        //        NameDepartment = item.NameDepartment?.Trim(),
        //        //        Office = item.Office?.Trim(),
        //        //        Addres = item.Addres?.Trim(),
        //        //        Email = item.Email?.Trim(),
        //        //        PhoneNumber = item.PhoneNumber?.Trim(),
        //        //        IdFaculty = item.IdFaculty?.Trim(),
        //        //        CreateDate = DateTime.Now,
        //        //        LastUpdate = null,
        //        //        IsActive = true,
        //        //        IsDelete = false,
        //        //        DeleteTime = null
        //        //    };
        //        //    var Result = await _departmentRepository.InsertAsync(_department);
        //        //    if (Result > 0)
        //        //        dem++;
        //        //}
        //        //if (dem > 0)
        //        //    return new ActionResultResponese<string>(dem, "them thanh cong", "Department", null);
        //        //return new ActionResultResponese<string>(-5, "them that bai", "Department", null);
        //        #endregion
        //    }
            
        //    List<XuatDiemPhanBienViewModel> dbdiemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc);
        //    var result = phanbien.Except(dbdiemphanbien);
        //    if (result)

        //}
    }
}
