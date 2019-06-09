namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using QuanLyNongTraiLonThit.TienIch;
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyNongTraiLonDBContext : DbContext
    {
        public QuanLyNongTraiLonDBContext()
            : base("name=QuanLyNongTraiLonDBContext")
        {
        }

        public virtual DbSet<ChiTiet_PhieuNhapThucAn> ChiTiet_PhieuNhapThucAn { get; set; }
        public virtual DbSet<ChiTiet_PhieuNhapThuoc> ChiTiet_PhieuNhapThuoc { get; set; }
        public virtual DbSet<ChiTiet_PhieuNhapVatNuoi> ChiTiet_PhieuNhapVatNuoi { get; set; }
        public virtual DbSet<ChiTiet_PhieuXuatThucAn> ChiTiet_PhieuXuatThucAn { get; set; }
        public virtual DbSet<ChiTiet_PhieuXuatThuoc> ChiTiet_PhieuXuatThuoc { get; set; }
        public virtual DbSet<ChiTiet_PhieuXuatVatNuoi> ChiTiet_PhieuXuatVatNuoi { get; set; }
        public virtual DbSet<Chuong> Chuongs { get; set; }
        public virtual DbSet<Giong> Giongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhieuNhapThucAn> PhieuNhapThucAns { get; set; }
        public virtual DbSet<PhieuNhapThuoc> PhieuNhapThuocs { get; set; }
        public virtual DbSet<PhieuNhapVatNuoi> PhieuNhapVatNuois { get; set; }
        public virtual DbSet<PhieuXuatThucAn> PhieuXuatThucAns { get; set; }
        public virtual DbSet<PhieuXuatThuoc> PhieuXuatThuocs { get; set; }
        public virtual DbSet<PhieuXuatVatNuoi> PhieuXuatVatNuois { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<ThucAn> ThucAns { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }
        public virtual DbSet<VatNuoi> VatNuois { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTiet_PhieuNhapThucAn>()
                .Property(e => e.MaPNTA)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapThucAn>()
                .Property(e => e.MaThucAn)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapThucAn>()
                .Property(e => e.GiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ChiTiet_PhieuNhapThuoc>()
                .Property(e => e.MaPNT)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapThuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapThuoc>()
                .Property(e => e.GiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ChiTiet_PhieuNhapVatNuoi>()
                .Property(e => e.MaPNVN)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapVatNuoi>()
                .Property(e => e.MaVatNuoi)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuNhapVatNuoi>()
                .Property(e => e.GiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ChiTiet_PhieuXuatThucAn>()
                .Property(e => e.MaPXTA)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatThucAn>()
                .Property(e => e.MaThucAn)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatThuoc>()
                .Property(e => e.MaPXTA)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatThuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatVatNuoi>()
                .Property(e => e.MaPXVN)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatVatNuoi>()
                .Property(e => e.MaVatNuoi)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTiet_PhieuXuatVatNuoi>()
                .Property(e => e.GiaXuat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Chuong>()
                .Property(e => e.MaChuong)
                .IsUnicode(false);

            modelBuilder.Entity<Chuong>()
                .Property(e => e.DayChuong)
                .IsUnicode(false);

            modelBuilder.Entity<Giong>()
                .Property(e => e.MaGiong)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhanQuyens)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThucAn>()
                .Property(e => e.MaPNTA)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThucAn>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThucAn>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThucAn>()
                .HasMany(e => e.ChiTiet_PhieuNhapThucAn)
                .WithRequired(e => e.PhieuNhapThucAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapThuoc>()
                .Property(e => e.MaPNT)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThuoc>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThuoc>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapThuoc>()
                .HasMany(e => e.ChiTiet_PhieuNhapThuoc)
                .WithRequired(e => e.PhieuNhapThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapVatNuoi>()
                .Property(e => e.MaPNVN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapVatNuoi>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapVatNuoi>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapVatNuoi>()
                .HasMany(e => e.ChiTiet_PhieuNhapVatNuoi)
                .WithRequired(e => e.PhieuNhapVatNuoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuatThucAn>()
                .Property(e => e.MaPXTA)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThucAn>()
                .Property(e => e.MaVatNuoi)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThucAn>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThucAn>()
                .HasMany(e => e.ChiTiet_PhieuXuatThucAn)
                .WithRequired(e => e.PhieuXuatThucAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuatThuoc>()
                .Property(e => e.MaPXT)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThuoc>()
                .Property(e => e.MaVatNuoi)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThuoc>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatThuoc>()
                .HasMany(e => e.ChiTiet_PhieuXuatThuoc)
                .WithRequired(e => e.PhieuXuatThuoc)
                .HasForeignKey(e => e.MaPXTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuatVatNuoi>()
                .Property(e => e.MaPXVN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatVatNuoi>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatVatNuoi>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuatVatNuoi>()
                .HasMany(e => e.ChiTiet_PhieuXuatVatNuoi)
                .WithRequired(e => e.PhieuXuatVatNuoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.PhanQuyens)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucAn>()
                .Property(e => e.MaThucAn)
                .IsUnicode(false);

            modelBuilder.Entity<ThucAn>()
                .HasMany(e => e.ChiTiet_PhieuNhapThucAn)
                .WithRequired(e => e.ThucAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThucAn>()
                .HasMany(e => e.ChiTiet_PhieuXuatThucAn)
                .WithRequired(e => e.ThucAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.MaThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.ChiTiet_PhieuNhapThuoc)
                .WithRequired(e => e.Thuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.ChiTiet_PhieuXuatThuoc)
                .WithRequired(e => e.Thuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatNuoi>()
                .Property(e => e.MaVatNuoi)
                .IsUnicode(false);

            modelBuilder.Entity<VatNuoi>()
                .Property(e => e.MaChuong)
                .IsUnicode(false);

            modelBuilder.Entity<VatNuoi>()
                .Property(e => e.MaGiong)
                .IsUnicode(false);

            modelBuilder.Entity<VatNuoi>()
                .HasMany(e => e.ChiTiet_PhieuNhapVatNuoi)
                .WithRequired(e => e.VatNuoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatNuoi>()
                .HasMany(e => e.ChiTiet_PhieuXuatVatNuoi)
                .WithRequired(e => e.VatNuoi)
                .WillCascadeOnDelete(false);
        }
    }
}
