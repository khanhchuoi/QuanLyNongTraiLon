namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chuong")]
    public partial class Chuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chuong()
        {
            VatNuois = new HashSet<VatNuoi>();
        }

        [Key]
        [StringLength(6)]
        public string MaChuong { get; set; }

        [Required]
        [StringLength(1)]
        public string DayChuong { get; set; }

        public byte? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatNuoi> VatNuois { get; set; }
    }
}
