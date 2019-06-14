namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuatThucAn")]
    public partial class PhieuXuatThucAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuatThucAn()
        {
            ChiTiet_PhieuXuatThucAn = new HashSet<ChiTiet_PhieuXuatThucAn>();
        }

        [Key]
        [StringLength(15)]
        public string MaPXTA { get; set; }

        [StringLength(6)]
        public string MaVatNuoi { get; set; }

        [StringLength(6)]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatThucAn> ChiTiet_PhieuXuatThucAn { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual VatNuoi VatNuoi { get; set; }
    }
}
