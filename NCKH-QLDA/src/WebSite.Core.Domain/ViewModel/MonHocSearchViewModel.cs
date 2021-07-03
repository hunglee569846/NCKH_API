using System;
using System.Collections.Generic;
using System.Text;
using WebSite.Core.Domain.Constansts;

namespace WebSite.Core.Domain.ViewModel
{
    public class MonHocSearchViewModel
    {
        public string IdMonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoLuongGVHD { get; set; }
        public int SoLuongPhanBien { get; set; }
        public string IdMonTienQuyet { get; set; }
        public string NameMonTienQuyet { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorFullName { get; set; }
        public TypeDataApprover TypeApprover { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
