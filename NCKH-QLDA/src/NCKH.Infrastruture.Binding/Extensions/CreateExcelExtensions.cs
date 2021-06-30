using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace NCKH.Infrastruture.Binding.Extensions
{
    public class CreateExcelExtensions
    {

        public Stream CreateExcel<T>(List<T> p, string sheetName, Stream stream = null)
        {
            //var list = new List<T>();
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                // Tạo author cho file Excel
                excelPackage.Workbook.Properties.Author = "Quản lý đồ án.";
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bảng điểm.";
                // thêm tí comments vào làm màu 
                excelPackage.Workbook.Properties.Comments = "This is my fucking generated Comments";
                // Add Sheet vào file Excel
                excelPackage.Workbook.Worksheets.Add(sheetName?.Trim().ToString());
                // Lấy Sheet bạn vừa mới tạo ra để thao tác 
                var workSheet = excelPackage.Workbook.Worksheets[0];
                //độ dài cột
                workSheet.DefaultColWidth = 40;
                // Tự động xuống hàng khi text quá dài
                workSheet.Cells.Style.WrapText = true;
                //workSheet.OutLineApplyStyle = true;
                workSheet.Cells.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                workSheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                // Đổ data vào Excel file
                workSheet.Cells[1, 1].LoadFromCollection(p, true, TableStyles.Light14);
                // BindingFormatForExcel(workSheet, list);
                excelPackage.Save();
                return excelPackage.Stream;
            }

        }

    }
}
