namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giong")]
    public partial class Giong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giong()
        {
            VatNuois = new HashSet<VatNuoi>();
        }

        [Key]
        [StringLength(6)]
        [Display(Name = "Mã giống")]

        public string MaGiong { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên giống")]
        public string TenGiong { get; set; }

        [Display(Name = "Thời gian thu hoạch")]
        public int? ThoiGianThuHoach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatNuoi> VatNuois { get; set; }
    }
}
