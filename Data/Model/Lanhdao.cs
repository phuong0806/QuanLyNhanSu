using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Lanhdao
    {
        public int Id { get; set; }
        public int? IdPhongban { get; set; }
        public long? IdNhanvien { get; set; }
        public int? IdLoaiLanhdao { get; set; }
        public DateTime? Batdau { get; set; }
        public DateTime? Ketthuc { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public LoaiLanhdao IdLoaiLanhdaoNavigation { get; set; }
        public Nhanvien IdNhanvienNavigation { get; set; }
        public Phongban IdPhongbanNavigation { get; set; }
    }
}
