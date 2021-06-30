using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ViewModel
{
    public class XuatDiemPhanBienViewModel
    {
        public string IdPhanBien { get; set; }
        public float Diem { get; set; }
        public string Note { get; set; }
        // public string IdDeTai { get; set; }
        //public string IdGVPB { get; set; }
        public string MaGVHD { get; set; }
        public string TenGVHD { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai  { get; set; }
        //public string IdSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string MaSinhVien { get; set; }
    }
}
