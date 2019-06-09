namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapThuoc")]
    public partial class PhieuNhapThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapThuoc()
        {
            ChiTiet_PhieuNhapThuoc = new HashSet<ChiTiet_PhieuNhapThuoc>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Mã phiếu nhập thuốc")]

        public string MaPNT { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã nhà cung cấp")]

        public string MaNCC { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã nhân viên")]

        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày nhập")]

        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapThuoc> ChiTiet_PhieuNhapThuoc { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
