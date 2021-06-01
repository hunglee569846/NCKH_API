using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Core.Domain.ViewModel
{
    public class LopSearchViewModel
    {
        public string Id { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaChuyenNganh { get; set; }
        public string MaChuongTrinhDaoTao { get; set; }
        public string IdChuyenNganh { get; set; }
        public string IdChuongTrinhDaoTao { get; set; }
        public string NienKhoa { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
