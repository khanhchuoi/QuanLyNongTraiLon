namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            ChiTiet_PhieuNhapThuoc = new HashSet<ChiTiet_PhieuNhapThuoc>();
            ChiTiet_PhieuXuatThuoc = new HashSet<ChiTiet_PhieuXuatThuoc>();
        }

        [Key]
        [StringLength(6)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenThuoc { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(15)]
        public string DonViTinh { get; set; }

        public int? ThoiGianCachLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapThuoc> ChiTiet_PhieuNhapThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatThuoc> ChiTiet_PhieuXuatThuoc { get; set; }
    }
}
