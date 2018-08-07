using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class LoaiDaotao
    {
        public LoaiDaotao()
        {
            ChitietDaotao = new HashSet<ChitietDaotao>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public string Mota { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public ICollection<ChitietDaotao> ChitietDaotao { get; set; }
    }
}
