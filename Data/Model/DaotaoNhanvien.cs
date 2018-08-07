using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class DaotaoNhanvien
    {
        public int Id { get; set; }
        public long? IdNhanvien { get; set; }
        public int? IdChitietDaotao { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public ChitietDaotao IdChitietDaotaoNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
