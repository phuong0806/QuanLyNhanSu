using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class LoaiLanhdao
    {
        public LoaiLanhdao()
        {
            Lanhdao = new HashSet<Lanhdao>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public ICollection<Lanhdao> Lanhdao { get; set; }
    }
}
