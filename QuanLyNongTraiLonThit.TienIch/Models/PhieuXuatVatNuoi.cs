namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuatVatNuoi")]
    public partial class PhieuXuatVatNuoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuatVatNuoi()
        {
            ChiTiet_PhieuXuatVatNuoi = new HashSet<ChiTiet_PhieuXuatVatNuoi>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Mã phiếu xuất vật nuôi")]

        public string MaPXVN { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã khách hàng")]

        public string MaKhachHang { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã nhân viên")]

        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày xuất")]

        public DateTime? NgayXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatVatNuoi> ChiTiet_PhieuXuatVatNuoi { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
