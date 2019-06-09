namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_PhieuXuatVatNuoi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MaPXVN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MaVatNuoi { get; set; }

        public int? TrongLuongXuat { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaXuat { get; set; }

        public virtual PhieuXuatVatNuoi PhieuXuatVatNuoi { get; set; }

        public virtual VatNuoi VatNuoi { get; set; }
    }
}
