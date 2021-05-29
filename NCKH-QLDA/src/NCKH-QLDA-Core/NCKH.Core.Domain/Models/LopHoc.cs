namespace NCKH.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class LopHoc
    {
        public string Id { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaChuyenNganh { get; set; }
        public string MaChuongTrinhDaoTao { get; set; }
        public string NienKhoa { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public LopHoc()
        {
            IsActive = true;
            IsDelete = false;
            NgayTao = DateTime.Now;
            NgayCapNhat = null;
                
        }
    }
}
