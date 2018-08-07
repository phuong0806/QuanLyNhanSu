using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Thannhan
    {
        public long Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Nghenghiep { get; set; }
        public long? IdNhanvien { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
