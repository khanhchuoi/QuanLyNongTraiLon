namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_PhieuNhapThucAn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MaPNTA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MaThucAn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySanXuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        public int? SoLuongNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaNhap { get; set; }

        public virtual PhieuNhapThucAn PhieuNhapThucAn { get; set; }

        public virtual ThucAn ThucAn { get; set; }
    }
}
