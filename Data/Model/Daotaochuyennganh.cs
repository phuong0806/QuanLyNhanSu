using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Daotaochuyennganh
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public DateTime? Batdau { get; set; }
        public DateTime? Ketthuc { get; set; }
        public string Mota { get; set; }
        public int? IdChucvu { get; set; }
        public int? IdChuyennganh { get; set; }
        public int IdPhongban { get; set; }
        public DateTime? Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime? Dateedit { get; set; }
        public long? Useredit { get; set; }

        public Chucvu IdChucvuNavigation { get; set; }
        public Chuyennganh IdChuyennganhNavigation { get; set; }
        public Phongban IdPhongbanNavigation { get; set; }
    }
}
