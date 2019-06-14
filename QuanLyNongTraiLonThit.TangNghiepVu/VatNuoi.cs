namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VatNuoi")]
    public partial class VatNuoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VatNuoi()
        {
            ChiTiet_PhieuNhapVatNuoi = new HashSet<ChiTiet_PhieuNhapVatNuoi>();
            ChiTiet_PhieuXuatVatNuoi = new HashSet<ChiTiet_PhieuXuatVatNuoi>();
            PhieuXuatThucAns = new HashSet<PhieuXuatThucAn>();
            PhieuXuatThuocs = new HashSet<PhieuXuatThuoc>();
        }

        [Key]
        [StringLength(6)]
        public string MaVatNuoi { get; set; }

        [StringLength(6)]
        public string MaChuong { get; set; }

        [StringLength(6)]
        public string MaGiong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianThuHoach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianCachLy { get; set; }

        public byte? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapVatNuoi> ChiTiet_PhieuNhapVatNuoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatVatNuoi> ChiTiet_PhieuXuatVatNuoi { get; set; }

        public virtual Chuong Chuong { get; set; }

        public virtual Giong Giong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatThucAn> PhieuXuatThucAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatThuoc> PhieuXuatThuocs { get; set; }
    }
}
