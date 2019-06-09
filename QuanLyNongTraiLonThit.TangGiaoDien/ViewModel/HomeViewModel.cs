using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyNongTraiLonThit.TienIch;
using QuanLyNongTraiLonThit.TangNghiepVu;
namespace QuanLyNongTraiLonThit.TangGiaoDien.ViewModel
{
    /// <summary>
    /// Con vật sắp xuất bán được
    /// Thức ăn sắp hết hạn hoặc sắp hết
    /// Thuốc sắp hết hạn hoặc sắp hết
    /// </summary>
    public class HomeViewModel
    {
        #region Property
        public ICollection<VatNuoi> ConVatXuatBan { get; set; }
        public ICollection<VatNuoi>  ConVatBiBenh { get; set; }

        public ICollection<ChiTiet_PhieuNhapThucAn> ThucAnSapHetHan { get; set; }
        public ICollection<ThucAn> ThucAnSapHet { get; set; }

        public ICollection<ChiTiet_PhieuNhapThuoc> ThuocSapHetHan { get; set; }
        public ICollection<Thuoc> ThuocSapHet { get; set; }
        #endregion

        public int TongConVatXuatBan { get; set; }
        public int TongConVatBiBenh { get; set; }
        public int TongThucAnSapHetHan { get; set; }
        public int TongThucAnSapHet { get; set; }
        public int TongThuocSapHet { get; set; }
        public int TongThuocSapHetHan { get; set; }

    }
}