using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Chuyennganh
    {
        public Chuyennganh()
        {
            Daotaochuyennganh = new HashSet<Daotaochuyennganh>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public ICollection<Daotaochuyennganh> Daotaochuyennganh { get; set; }
    }
}
