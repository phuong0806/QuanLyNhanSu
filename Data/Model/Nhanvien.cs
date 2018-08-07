using System;
using System.Collections.Generic;

namespace QLNS.Model
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            ChucvuNhanvien = new HashSet<ChucvuNhanvien>();
            DaotaoNhanvien = new HashSet<DaotaoNhanvien>();
            KhenthuongNhanvien = new HashSet<KhenthuongNhanvien>();
            Kyhopdong = new HashSet<Kyhopdong>();
            KyluatNhanvien = new HashSet<KyluatNhanvien>();
            Lanhdao = new HashSet<Lanhdao>();
            Thannhan = new HashSet<Thannhan>();
        }

        public long Id { get; set; }
        public string Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Noisinh { get; set; }
        public string Gioitinh { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string DiachiHientai { get; set; }
        public string Email { get; set; }
        public DateTime Dateadd { get; set; }
        public long? Useradd { get; set; }
        public DateTime Dateedit { get; set; }
        public long? Useredit { get; set; }
        public int? IdChucvu { get; set; }
        public int? IdDonvi { get; set; }
        public long? IdTaikhoan { get; set; }

        public Donvi IdDonviNavigation { get; set; }
        public Taikhoan IdTaikhoanNavigation { get; set; }
        public ICollection<ChucvuNhanvien> ChucvuNhanvien { get; set; }
        public ICollection<DaotaoNhanvien> DaotaoNhanvien { get; set; }
        public ICollection<KhenthuongNhanvien> KhenthuongNhanvien { get; set; }
        public ICollection<Kyhopdong> Kyhopdong { get; set; }
        public ICollection<KyluatNhanvien> KyluatNhanvien { get; set; }
        public ICollection<Lanhdao> Lanhdao { get; set; }
        public ICollection<Thannhan> Thannhan { get; set; }
    }
}
