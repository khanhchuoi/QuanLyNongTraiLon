namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuatThuoc")]
    public partial class PhieuXuatThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuatThuoc()
        {
            ChiTiet_PhieuXuatThuoc = new HashSet<ChiTiet_PhieuXuatThuoc>();
        }

        [Key]
        [StringLength(15)]
        [Display(Name = "Mã phiếu xuất thuốc")]

        public string MaPXT { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã vật nuôi")]

        public string MaVatNuoi { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã nhân viên")]

        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày xuất")]

        public DateTime? NgayXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatThuoc> ChiTiet_PhieuXuatThuoc { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual VatNuoi VatNuoi { get; set; }
    }
}
