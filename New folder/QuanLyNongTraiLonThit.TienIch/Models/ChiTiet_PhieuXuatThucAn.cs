namespace QuanLyNongTraiLonThit.TienIch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_PhieuXuatThucAn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MaPXTA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MaThucAn { get; set; }

        public int? SoLuongXuat { get; set; }

        public virtual PhieuXuatThucAn PhieuXuatThucAn { get; set; }

        public virtual ThucAn ThucAn { get; set; }
    }
}
