using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class KyluatNhanvien
    {
        public int Id { get; set; }
        public int IdKyluat { get; set; }
        public long IdNhanvien { get; set; }
        public DateTime? Ngay { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Kyluat IdKyluatNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
