using NCKH.Infrastruture.Binding.Constans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ViewModel
{
    public class TaiKhoanViewModel
    {
        public string IdAccount { get; set; }
        public string MaGiangVien { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdBoMon { get; set; }
        public UserType Type { get; set; }
        public string NameBoMon { get; set; }
    }
}
