using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLNS.Model
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChitietDaotao> ChitietDaotao { get; set; }
        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<ChucvuNhanvien> ChucvuNhanvien { get; set; }
        public virtual DbSet<Chuyennganh> Chuyennganh { get; set; }
        public virtual DbSet<Daotaochuyennganh> Daotaochuyennganh { get; set; }
        public virtual DbSet<DaotaoNhanvien> DaotaoNhanvien { get; set; }
        public virtual DbSet<Donvi> Donvi { get; set; }
        public virtual DbSet<Hopdong> Hopdong { get; set; }
        public virtual DbSet<Khenthuong> Khenthuong { get; set; }
        public virtual DbSet<KhenthuongNhanvien> KhenthuongNhanvien { get; set; }
        public virtual DbSet<Kyhopdong> Kyhopdong { get; set; }
        public virtual DbSet<Kyluat> Kyluat { get; set; }
        public virtual DbSet<KyluatNhanvien> KyluatNhanvien { get; set; }
        public virtual DbSet<Lanhdao> Lanhdao { get; set; }
        public virtual DbSet<LoaiDaotao> LoaiDaotao { get; set; }
        public virtual DbSet<LoaiLanhdao> LoaiLanhdao { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phongban> Phongban { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Thannhan> Thannhan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-62473AB\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitietDaotao>(entity =>
            {
                entity.ToTable("chitiet_daotao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batdau)
                    .HasColumnName("batdau")
                    .HasColumnType("date");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(250);

                entity.Property(e => e.Gia)
                    .HasColumnName("gia")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdLoaiDaotao).HasColumnName("id_loai_daotao");

                entity.Property(e => e.Ketthuc)
                    .HasColumnName("ketthuc")
                    .HasColumnType("date");

                entity.Property(e => e.Noidung)
                    .HasColumnName("noidung")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdLoaiDaotaoNavigation)
                    .WithMany(p => p.ChitietDaotao)
                    .HasForeignKey(d => d.IdLoaiDaotao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitiet_daotao_loai_daotao");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.ToTable("chucvu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Phucap)
                    .HasColumnName("phucap")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<ChucvuNhanvien>(entity =>
            {
                entity.ToTable("chucvu_nhanvien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdChucvu).HasColumnName("id_chucvu");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.ThoigianBatdau)
                    .HasColumnName("thoigian_batdau")
                    .HasColumnType("date");

                entity.Property(e => e.ThoigianKetthuc)
                    .HasColumnName("thoigian_ketthuc")
                    .HasColumnType("date");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdChucvuNavigation)
                    .WithMany(p => p.ChucvuNhanvien)
                    .HasForeignKey(d => d.IdChucvu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_position_position");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.ChucvuNhanvien)
                    .HasForeignKey(d => d.IdNhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_position_employee");
            });

            modelBuilder.Entity<Chuyennganh>(entity =>
            {
                entity.ToTable("chuyennganh");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(50);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<Daotaochuyennganh>(entity =>
            {
                entity.ToTable("daotaochuyennganh");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batdau)
                    .HasColumnName("batdau")
                    .HasColumnType("date");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdChucvu).HasColumnName("id_chucvu");

                entity.Property(e => e.IdChuyennganh).HasColumnName("id_chuyennganh");

                entity.Property(e => e.IdPhongban).HasColumnName("id_phongban");

                entity.Property(e => e.Ketthuc)
                    .HasColumnName("ketthuc")
                    .HasColumnType("date");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(50);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdChucvuNavigation)
                    .WithMany(p => p.Daotaochuyennganh)
                    .HasForeignKey(d => d.IdChucvu)
                    .HasConstraintName("FK_major_training_position");

                entity.HasOne(d => d.IdChuyennganhNavigation)
                    .WithMany(p => p.Daotaochuyennganh)
                    .HasForeignKey(d => d.IdChuyennganh)
                    .HasConstraintName("FK_major_training_major");

                entity.HasOne(d => d.IdPhongbanNavigation)
                    .WithMany(p => p.Daotaochuyennganh)
                    .HasForeignKey(d => d.IdPhongban)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_major_training_department");
            });

            modelBuilder.Entity<DaotaoNhanvien>(entity =>
            {
                entity.ToTable("daotao_nhanvien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdChitietDaotao).HasColumnName("id_chitiet_daotao");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdChitietDaotaoNavigation)
                    .WithMany(p => p.DaotaoNhanvien)
                    .HasForeignKey(d => d.IdChitietDaotao)
                    .HasConstraintName("FK_daotao_nhanvien_chitiet_daotao");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.DaotaoNhanvien)
                    .HasForeignKey(d => d.IdNhanvien)
                    .HasConstraintName("FK_daotao_nhanvien_nhanvien");
            });

            modelBuilder.Entity<Donvi>(entity =>
            {
                entity.ToTable("donvi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<Hopdong>(entity =>
            {
                entity.ToTable("hopdong");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("ngaylap")
                    .HasColumnType("date");

                entity.Property(e => e.Noidung).HasColumnName("noidung");

                entity.Property(e => e.Sohopdong)
                    .HasColumnName("sohopdong")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<Khenthuong>(entity =>
            {
                entity.ToTable("khenthuong");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaycapnhat)
                    .HasColumnName("ngaycapnhat")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("ngaylap")
                    .HasColumnType("date");

                entity.Property(e => e.Noidung)
                    .HasColumnName("noidung")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<KhenthuongNhanvien>(entity =>
            {
                entity.ToTable("khenthuong_nhanvien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdKhenthuong).HasColumnName("id_khenthuong");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.Ngay)
                    .HasColumnName("ngay")
                    .HasColumnType("date");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdKhenthuongNavigation)
                    .WithMany(p => p.KhenthuongNhanvien)
                    .HasForeignKey(d => d.IdKhenthuong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_reward_reward");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.KhenthuongNhanvien)
                    .HasForeignKey(d => d.IdNhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_reward_employee");
            });

            modelBuilder.Entity<Kyhopdong>(entity =>
            {
                entity.ToTable("kyhopdong");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdHopdong).HasColumnName("id_hopdong");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.NgayKy)
                    .HasColumnName("ngay_ky")
                    .HasColumnType("date");

                entity.Property(e => e.Sohopdong)
                    .HasColumnName("sohopdong")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Thoihan)
                    .HasColumnName("thoihan")
                    .HasMaxLength(50);

                entity.Property(e => e.Trangthai)
                    .HasColumnName("trangthai")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdHopdongNavigation)
                    .WithMany(p => p.Kyhopdong)
                    .HasForeignKey(d => d.IdHopdong)
                    .HasConstraintName("FK_kyhopdong_hopdong");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.Kyhopdong)
                    .HasForeignKey(d => d.IdNhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_kyhopdong_nhanvien");
            });

            modelBuilder.Entity<Kyluat>(entity =>
            {
                entity.ToTable("kyluat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<KyluatNhanvien>(entity =>
            {
                entity.ToTable("kyluat_nhanvien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdKyluat).HasColumnName("id_kyluat");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.Ngay)
                    .HasColumnName("ngay")
                    .HasColumnType("date");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdKyluatNavigation)
                    .WithMany(p => p.KyluatNhanvien)
                    .HasForeignKey(d => d.IdKyluat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_discipline_discipline");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.KyluatNhanvien)
                    .HasForeignKey(d => d.IdNhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_discipline_employee");
            });

            modelBuilder.Entity<Lanhdao>(entity =>
            {
                entity.ToTable("lanhdao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batdau)
                    .HasColumnName("batdau")
                    .HasColumnType("date");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdLoaiLanhdao).HasColumnName("id_loai_lanhdao");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.IdPhongban).HasColumnName("id_phongban");

                entity.Property(e => e.Ketthuc)
                    .HasColumnName("ketthuc")
                    .HasColumnType("date");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdLoaiLanhdaoNavigation)
                    .WithMany(p => p.Lanhdao)
                    .HasForeignKey(d => d.IdLoaiLanhdao)
                    .HasConstraintName("FK_lead_type_lead");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.Lanhdao)
                    .HasForeignKey(d => d.IdNhanvien)
                    .HasConstraintName("FK_lead_employee");

                entity.HasOne(d => d.IdPhongbanNavigation)
                    .WithMany(p => p.Lanhdao)
                    .HasForeignKey(d => d.IdPhongban)
                    .HasConstraintName("FK_lead_department");
            });

            modelBuilder.Entity<LoaiDaotao>(entity =>
            {
                entity.ToTable("loai_daotao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasColumnName("ten");

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<LoaiLanhdao>(entity =>
            {
                entity.ToTable("loai_lanhdao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(50);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.ToTable("nhanvien");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(250);

                entity.Property(e => e.DiachiHientai)
                    .HasColumnName("diachi_hientai")
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("gioitinh")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hoten)
                    .HasColumnName("hoten")
                    .HasMaxLength(250);

                entity.Property(e => e.IdChucvu).HasColumnName("id_chucvu");

                entity.Property(e => e.IdDonvi).HasColumnName("id_donvi");

                entity.Property(e => e.IdTaikhoan).HasColumnName("id_taikhoan");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Noisinh)
                    .HasColumnName("noisinh")
                    .HasMaxLength(250);

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdDonviNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.IdDonvi)
                    .HasConstraintName("FK_employee_unit");

                entity.HasOne(d => d.IdTaikhoanNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.IdTaikhoan)
                    .HasConstraintName("FK_nhanvien_taikhoan");
            });

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.ToTable("phongban");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mota)
                    .HasColumnName("mota")
                    .HasColumnType("text");

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.ToTable("taikhoan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Khoa)
                    .HasColumnName("khoa")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LydoKhoa)
                    .HasColumnName("lydo_khoa")
                    .HasColumnType("text");

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasColumnName("matkhau")
                    .HasColumnType("text");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Taikhoan1)
                    .HasColumnName("taikhoan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThoigianMokhoa)
                    .HasColumnName("thoigian_mokhoa")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Thannhan>(entity =>
            {
                entity.ToTable("thannhan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateadd)
                    .HasColumnName("dateadd")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdNhanvien).HasColumnName("id_nhanvien");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("ngaysinh")
                    .HasColumnType("date");

                entity.Property(e => e.Nghenghiep)
                    .HasColumnName("nghenghiep")
                    .HasMaxLength(250);

                entity.Property(e => e.Ten)
                    .HasColumnName("ten")
                    .HasMaxLength(250);

                entity.Property(e => e.Useradd).HasColumnName("useradd");

                entity.Property(e => e.Useredit).HasColumnName("useredit");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.Thannhan)
                    .HasForeignKey(d => d.IdNhanvien)
                    .HasConstraintName("FK_thannhan_nhanvien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
