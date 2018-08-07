using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Kyhopdong
    {
        public long Id { get; set; }
        public string Sohopdong { get; set; }
        public string Trangthai { get; set; }
        public DateTime? NgayKy { get; set; }
        public string Thoihan { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }
        public long? IdHopdong { get; set; }
        public long IdNhanvien { get; set; }

        public Hopdong IdHopdongNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
