using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Khenthuong
    {
        public Khenthuong()
        {
            KhenthuongNhanvien = new HashSet<KhenthuongNhanvien>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaylap { get; set; }
        public DateTime? Ngaycapnhat { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public ICollection<KhenthuongNhanvien> KhenthuongNhanvien { get; set; }
    }
}
