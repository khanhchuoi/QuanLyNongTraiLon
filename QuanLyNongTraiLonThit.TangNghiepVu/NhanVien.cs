namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
            PhieuNhapVatNuois = new HashSet<PhieuNhapVatNuoi>();
            PhieuNhapThucAns = new HashSet<PhieuNhapThucAn>();
            PhieuNhapThuocs = new HashSet<PhieuNhapThuoc>();
            PhieuXuatVatNuois = new HashSet<PhieuXuatVatNuoi>();
            PhieuXuatThucAns = new HashSet<PhieuXuatThucAn>();
            PhieuXuatThuocs = new HashSet<PhieuXuatThuoc>();
        }

        [Key]
        [StringLength(6)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapVatNuoi> PhieuNhapVatNuois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapThucAn> PhieuNhapThucAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapThuoc> PhieuNhapThuocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatVatNuoi> PhieuXuatVatNuois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatThucAn> PhieuXuatThucAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuatThuoc> PhieuXuatThuocs { get; set; }
    }
}
