namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapThucAn")]
    public partial class PhieuNhapThucAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapThucAn()
        {
            ChiTiet_PhieuNhapThucAn = new HashSet<ChiTiet_PhieuNhapThucAn>();
        }

        [Key]
        [StringLength(15)]
        public string MaPNTA { get; set; }

        [StringLength(6)]
        public string MaNCC { get; set; }

        [StringLength(6)]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_PhieuNhapThucAn> ChiTiet_PhieuNhapThucAn { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
