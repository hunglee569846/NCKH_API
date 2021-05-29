//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace NCKH.Infrastruture.Binding.ImportDataFunction
//{
//   public class ExcelImport
//    {
//        public async Task<ActionResultReponese<string>> InsertListExcelAsync(string NameFaculty)
//        {
//            List<DepartmentMeta> departmentlist = new List<DepartmentMeta>();
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            using (var pakage = new ExcelPackage(new FileInfo("Exceltest\\ExceltestDepartment.xlsx")))
//            {
//                ExcelWorksheet worsheet = pakage.Workbook.Worksheets[0];
//                for (int i = worsheet.Dimension.Start.Row + 1; i <= worsheet.Dimension.End.Row; i++)
//                {
//                    //StudentTest st1 = new StudentTest();
//                    int j = 1;
//                    string Email = worsheet.Cells[i, j++].Value.ToString();
//                    string adress = worsheet.Cells[i, j++].Value.ToString();
//                    string namedepartment = worsheet.Cells[i, j++].Value.ToString();
//                    string office = worsheet.Cells[i, j++].Value.ToString();
//                    string phonnumber = worsheet.Cells[i, j++].Value.ToString();
//                    string idfacultymeta = worsheet.Cells[i, j++].Value.ToString();
//                    DepartmentMeta _depart = new DepartmentMeta()
//                    {
//                        Email = Email,
//                        Addres = adress,
//                        NameDepartment = namedepartment,
//                        Office = office,
//                        PhoneNumber = phonnumber,
//                        IdFaculty = idfacultymeta,


//                    };
//                    departmentlist.Add(_depart);
//                }
//                int dem = 0;
//                foreach (var item in departmentlist)
//                {
//                    var idfaculty = await _facultyRepository.CheckExitsFacult(NameFaculty);
//                    if (!idfaculty)
//                        return new ActionResultReponese<string>(-21, "khoa khong ton tai", "Faculty");

//                    var namedeartment = await _departmentRepository.CheckExitsDepartment(item.NameDepartment);
//                    if (namedeartment)
//                        return new ActionResultReponese<string>(-22, "Bo mon da ton tai", "Department");
//                    var _department = new Department
//                    {
//                        IdDepartment = Guid.NewGuid().ToString(),
//                        NameDepartment = item.NameDepartment?.Trim(),
//                        Office = item.Office?.Trim(),
//                        Addres = item.Addres?.Trim(),
//                        Email = item.Email?.Trim(),
//                        PhoneNumber = item.PhoneNumber?.Trim(),
//                        IdFaculty = item.IdFaculty?.Trim(),
//                        CreateDate = DateTime.Now,
//                        LastUpdate = null,
//                        IsActive = true,
//                        IsDelete = false,
//                        DeleteTime = null
//                    };
//                    var Result = await _departmentRepository.InsertAsync(_department);
//                    if (Result > 0)
//                        dem++;
//                }
//                if (dem > 0)
//                    return new ActionResultReponese<string>(dem, "them thanh cong", "Department", null);
//                return new ActionResultReponese<string>(-5, "them that bai", "Department", null);

//            }

//        }
//    }
//}
