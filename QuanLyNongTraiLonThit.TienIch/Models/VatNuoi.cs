namespace QuanLyNongTraiLonThit.TienIch
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
        [Display(Name = "Mã vật nuôi")]

        public string MaVatNuoi { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã chuồng")]

        public string MaChuong { get; set; }

        [StringLength(6)]
        [Display(Name = "Mã giống")]

        public string MaGiong { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Thời gian thu hoạch")]

        public DateTime? ThoiGianThuHoach { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Thời gian cách ly")]

        public DateTime? ThoiGianCachLy { get; set; }
        /// <summary>
        ///  0 : Dang nuoi 1 Dang bi benh 2 Co the xuat 3 Da xuat
        /// </summary>
        [Display(Name = "Trạng thái")]
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
