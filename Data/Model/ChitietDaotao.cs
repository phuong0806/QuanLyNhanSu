using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class ChitietDaotao
    {
        public ChitietDaotao()
        {
            DaotaoNhanvien = new HashSet<DaotaoNhanvien>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Batdau { get; set; }
        public DateTime? Ketthuc { get; set; }
        public string Diachi { get; set; }
        public string Noidung { get; set; }
        public decimal? Gia { get; set; }
        public int IdLoaiDaotao { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public LoaiDaotao IdLoaiDaotaoNavigation { get; set; }
        public ICollection<DaotaoNhanvien> DaotaoNhanvien { get; set; }
    }
}
