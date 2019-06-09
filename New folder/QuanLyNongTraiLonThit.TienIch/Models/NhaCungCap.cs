namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            PhieuNhapVatNuois = new HashSet<PhieuNhapVatNuoi>();
            PhieuNhapThucAns = new HashSet<PhieuNhapThucAn>();
            PhieuNhapThuocs = new HashSet<PhieuNhapThuoc>();
        }

        [Key]
        [StringLength(6)]
        [Display(Name = "Mã nhà cung cấp")]

        public string MaNCC { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên nhà cung cấp")]

        public string TenNCC { get; set; }

        [StringLength(255)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapVatNuoi> PhieuNhapVatNuois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapThucAn> PhieuNhapThucAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapThuoc> PhieuNhapThuocs { get; set; }
    }
}
