using NCKH.Infrastruture.Binding.Constans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ModelMeta
{
    public class UserAccountInsertMeta
    {
        public string MaGiangVien { get; set; }
        public UserType Type { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdBoMon { get; set; }
        public string NameBoMon { get; set; }
        public bool IsActive { get; set; }
       // public string CreatorId { get; set; }
        //public string CreatorFullName { get; set; }
    }
}
