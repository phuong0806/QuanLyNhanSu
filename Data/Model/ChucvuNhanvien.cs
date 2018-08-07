using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class ChucvuNhanvien
    {
        public long Id { get; set; }
        public long IdNhanvien { get; set; }
        public int IdChucvu { get; set; }
        public DateTime? ThoigianBatdau { get; set; }
        public DateTime? ThoigianKetthuc { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Chucvu IdChucvuNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
    }
}
