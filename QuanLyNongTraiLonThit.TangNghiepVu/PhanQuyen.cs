namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaQuyen { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string MaNhanVien { get; set; }

        public bool? TrangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
