namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucAn")]
    public partial class ThucAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucAn()
        {
            ChiTiet_PhieuNhapThucAn = new HashSet<ChiTiet_PhieuNhapThucAn>();
            ChiTiet_PhieuXuatThucAn = new HashSet<ChiTiet_PhieuXuatThucAn>();
        }

        [Key]
        [StringLength(6)]
        public string MaThucAn { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThucAn { get; set; }

        public int? SoLuongTon { get; set; }

        [StringLength(15)]
        public string DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapThucAn> ChiTiet_PhieuNhapThucAn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatThucAn> ChiTiet_PhieuXuatThucAn { get; set; }
    }
}
