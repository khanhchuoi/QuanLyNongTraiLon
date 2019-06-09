namespace QuanLyNongTraiLonThit.TienIch
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
        [Display(Name = "Mã thuốc")]

        public string MaThuoc { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên thuốc")]

        public string TenThuoc { get; set; }

        [Display(Name = "Số lượng")]

        public int? SoLuong { get; set; }

        [StringLength(15)]
        [Display(Name = "Đơn vị tính")]

        public string DonViTinh { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Thời gian cách ly")]

        public DateTime? ThoiGianCachLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapThuoc> ChiTiet_PhieuNhapThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuXuatThuoc> ChiTiet_PhieuXuatThuoc { get; set; }
    }
}
