using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class KhenthuongNhanvien
    {
        public int Id { get; set; }
        public long IdNhanvien { get; set; }
        public int IdKhenthuong { get; set; }
        public DateTime? Ngay { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Khenthuong IdKhenthuongNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
