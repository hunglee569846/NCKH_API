using NCKH.Infrastruture.Binding.Constans;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Infrastruture.Binding.Models
{
    public class BriefUser
    {
        /// <summary>
        /// Mã trùng với mã của tài khoản.
        /// </summary>
        public string IdAcount { get; set; }
        public string MaGiangVien { get; set; }

        /// <summary>
        /// Mã Bộ môn đăng nhập
        /// </summary>
        public string IdBoMon { get; set; }

        /// <summary>
        /// Mã Bộ môn đăng nhập
        /// </summary>
        public string NameBoMon { get; set; }

        /// <summary>
        /// Tên đăng nhập.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Họ tên.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ảnh đại diện.
        /// </summary>
       // public string Avatar { get; set; }

        public UserType Type { get; set; }

        public List<string> Languages { get; set; }
    }
}
