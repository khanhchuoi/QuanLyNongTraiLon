using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TangNghiepVu;
using QuanLyNongTraiLonThit.TienIch;
using QuanLyNongTraiLonThit.TangGiaoDien.ViewModel;
using QuanLyNongTraiLonThit.TangGiaoDien.Security;

namespace QuanLyNongTraiLonThit.TangGiaoDien.Controllers
{
    public class HomeController : Controller
    {
        // private readonly var _context =  Singleton.shared;

        //private readonly IGenericRepository<VatNuoi> vatnuoi = new GenericRepository<VatNuoi>();
        //private readonly IGenericRepository<Thuoc> thuoc = new GenericRepository<Thuoc>();
        //private readonly IGenericRepository<ChiTiet_PhieuNhapThuoc> ctPNThuoc = new GenericRepository<ChiTiet_PhieuNhapThuoc>();
        //private readonly IGenericRepository<ChiTiet_PhieuNhapThucAn> ctPNThucAn = new GenericRepository<ChiTiet_PhieuNhapThucAn>();

        private readonly QuanLyNongTraiLonDBContext context = new QuanLyNongTraiLonDBContext();

      //  [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {

            DateTime quarantineTime = DateTime.Now.AddDays(16);
            var homeViewModel = new HomeViewModel()
            {
                ConVatBiBenh = context.VatNuois.Include(v => v.Chuong).Include(v => v.Giong).Where(v => v.TrangThai == 1).ToList(),
                // Có thể lấy theo trạng thái. Nhưng chưa bắt được sự kiện trigger update. 
                ConVatXuatBan = context.VatNuois.Include(v => v.Chuong).Where(v => v.ThoiGianThuHoach < quarantineTime && v.ThoiGianCachLy <= DateTime.Now).ToList(),

                ThucAnSapHet = context.ThucAns.Where(t => t.SoLuongTon < 12).ToList(),
                ThucAnSapHetHan = context.ChiTiet_PhieuNhapThucAn.Where(c => c.HanSuDung < quarantineTime).ToList(),

                ThuocSapHet = context.Thuocs.Where(t => t.SoLuong < 12).ToList(),
                ThuocSapHetHan = context.ChiTiet_PhieuNhapThuoc.Where(c => c.HanSuDung < quarantineTime).ToList(),

            };
            homeViewModel.TongConVatBiBenh = homeViewModel.ConVatBiBenh.Count;
            homeViewModel.TongConVatXuatBan = homeViewModel.ConVatXuatBan.Count;
            homeViewModel.TongThucAnSapHet = homeViewModel.ThucAnSapHet.Count;
            homeViewModel.TongThucAnSapHetHan = homeViewModel.ThucAnSapHetHan.Count;
            homeViewModel.TongThuocSapHet = homeViewModel.ThuocSapHet.Count;
            homeViewModel.TongThuocSapHetHan = homeViewModel.ThuocSapHetHan.Count;
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}