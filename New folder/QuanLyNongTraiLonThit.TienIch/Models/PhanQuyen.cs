namespace QuanLyNongTraiLonThit.TienIch
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
        [Display(Name = "Mã quyền")]
        public int MaQuyen { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        [Display(Name = "Mã nhân viên")]

        public string MaNhanVien { get; set; }

        /// <summary>
        /// 1 Co the su dung 0 la bi khoa
        /// </summary>
        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
