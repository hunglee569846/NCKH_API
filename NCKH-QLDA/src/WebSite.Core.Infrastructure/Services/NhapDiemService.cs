using Microsoft.AspNetCore.Hosting;
using NCKH.Infrastruture.Binding.Models;
using NCKH.Infrastruture.Binding.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Core.Domain.IRepository;
using WebSite.Core.Domain.IServices;
using WebSite.Core.Domain.Models;
using WebSite.Core.Domain.ViewModel;
using WebSite.Core.Infrastructure.Repository;

namespace WebSite.Core.Infrastructure.Services
{
    public class NhapDiemService : INhapDiemService
    {

        private readonly IPhanBienRepository _phanBienRepository;
        private readonly IBangDiemRepository _bangdiemRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NhapDiemService(IPhanBienRepository phanBienRepository,
                               IBangDiemRepository bangdiemRepository,
                               IFileRepository fileRepository,
                               IWebHostEnvironment webHostEnvironment)
        {
            _phanBienRepository = phanBienRepository;
            _bangdiemRepository = bangdiemRepository;
            _fileRepository = fileRepository;
            _webHostEnvironment = webHostEnvironment;
    }

        /// <summary>
        /// chu y duong dan lay file excel la lay tu upload cua API upFile
        /// 
        /// </summary>
        /// <param name="NhapDiemService"></param>
        /// <returns></returns>
        public async Task<ActionResultResponese<string>> InsertListExcelAsync(string idhocky, string idmonhoc, string idfile, string idBoMon, string lastUpdateUserId, string lastUpdateFullName)
        {
            var infofile = await _fileRepository.GetInfo(idfile);
            if (infofile == null)
                return new ActionResultResponese<string>(-2, "File điểm không tồn tại.", "File điểm.");

            List<XuatDiemPhanBienViewModel> phanbien = new List<XuatDiemPhanBienViewModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using (var pakage = new ExcelPackage(new FileInfo(_webHostEnvironment.ContentRootPath + infofile.Url)))
            {
                //var worsheet = pakage.Workbook.Worksheets.First()
                
                ExcelWorksheet worsheet = pakage.Workbook.Worksheets["DiemPhanBien"];
                int row = worsheet.Dimension.End.Row;
                for (int i = worsheet.Dimension.Start.Row + 1; i <= 10 ; i++)
                {
                    int z = i;
                    if (worsheet.Cells[z, 1].Value.ToString() != null || worsheet.Cells[z, 1].Value.ToString() != string.Empty)
                    {
                        int j = 1;
                        string idPhanBien = worsheet.Cells[i, j++].Value.ToString();
                        string diem = worsheet.Cells[i, j++].Value.ToString();
                        string note = worsheet.Cells[i, j++].Value.ToString();
                        float diemphanbien = float.Parse(diem);
                        XuatDiemPhanBienViewModel _phanbienlist = new XuatDiemPhanBienViewModel()
                        {
                            IdPhanBien = idPhanBien?.Trim(),
                            Diem = diemphanbien,
                            Note = note?.Trim(),
                        };
                        phanbien.Add(_phanbienlist);
                    } 
                    else break;
                }
            }

            
          //  List<XuatDiemPhanBienViewModel> dbdiemphanbien = await _bangdiemRepository.XuatDiemPhanBienExcel(idhocky, idmonhoc, idBoMon);
            //if(dbdiemphanbien.Count() != phanbien.Count())
            int dem = 0;
            foreach (var item in phanbien)
            {
                var info = await _phanBienRepository.GetInfoAsync(item.IdPhanBien?.Trim());
                if (info == null)
                {
                    dem++;
                    continue;
                }
                info.Diem = item.Diem;
                info.Note = item.Note?.Trim();
                info.IdPhanBien = item.IdPhanBien?.Trim();

                await _phanBienRepository.Update(info);

            }
            if (dem > 0)
                return new ActionResultResponese<string>(-2, "Có lỗi khi vào điểm có " + dem + " giảng viên không vào được điểm", "Điểm phản biện");
            else if (dem == phanbien.Count())
                return new ActionResultResponese<string>(-3, "File điểm lỗi không thển vào điểm, vui lòng liên hệ quản trị viên", "File diem phản biện.");
            else
                return new ActionResultResponese<string>(1, "Vào điểm thành công", "Điểm phản biện");
        }
    }
}
