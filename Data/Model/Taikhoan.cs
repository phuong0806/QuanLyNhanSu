using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Nhanvien = new HashSet<Nhanvien>();
        }

        public long Id { get; set; }
        public string Taikhoan1 { get; set; }
        public string Matkhau { get; set; }
        public string Salt { get; set; }
        public string Khoa { get; set; }
        public DateTime? ThoigianMokhoa { get; set; }
        public string LydoKhoa { get; set; }

        public ICollection<Nhanvien> Nhanvien { get; set; }
    }
}
