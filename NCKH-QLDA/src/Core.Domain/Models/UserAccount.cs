using NCKH.Infrastruture.Binding.Constans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class UserAccount
    {
        public string IdAccount { get; set; }
        public string MaGiangVien { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IdBoMon { get; set; }
        public string NameBoMon { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateTime { get; set; }
        public UserType Type { get; set; }
        public string CreatorId { get; set; }
        public string CreatorFullName { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateUserId { get; set; }
        public string LastUpdateFullName { get; set; }
        public UserAccount()
        {
            AccessFailedCount = 0;
            IsActive = true;
            IsDelete = false;
            LockoutEnabled = true;
            PhoneNumber = "+84";
            CreateTime = DateTime.Now;
            Type = UserType.GiangVien;
            LastUpdate = null;
        }
    }
}
