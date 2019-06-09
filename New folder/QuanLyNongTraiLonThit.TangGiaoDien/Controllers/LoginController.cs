using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TangNghiepVu;
using QuanLyNongTraiLonThit.TienIch;
using QuanLyNongTraiLonThit.TangGiaoDien.ViewModel;

namespace QuanLyNongTraiLonThit.TangGiaoDien.Controllers
{
    public class LoginController : Controller
    {
       private readonly QuanLyNongTraiLonDBContext context;

      public LoginController()
        {
            context = new QuanLyNongTraiLonDBContext();
        }
        public ActionResult DangNhap()
        {
            string url = null;
            try
            {
                url = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }
            ViewBag.ReturnURL = url;
            //ViewBag.ReturnURL = ReturnUrl;
            return View();

        }
        [HttpPost]
        public ActionResult DangNhap(NhanVien model, string ReturnURL)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            ViewBag.Login = true;

            if (String.IsNullOrEmpty(model.TaiKhoan))
            {
                ModelState.AddModelError("", "Chưa nhập tên đăng nhập");
                return View("DangNhap");
            }
            if (String.IsNullOrEmpty(model.MatKhau))
            {
                ModelState.AddModelError("", "Chưa nhập mật khẩu");
                return View("DangNhap");
            }

            var acc = context.NhanViens.Where(s => s.TaiKhoan == model.TaiKhoan && s.MatKhau == model.MatKhau).FirstOrDefault();

            if (acc == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("DangNhap");
            }
            else
            {
                // MyContext context = new MyContext();
                var ac = context.PhanQuyens.Where(p => p.NhanVien.TaiKhoan == acc.TaiKhoan & p.TrangThai == true ).FirstOrDefault();
                if (ac != null)
                {
                    Session[Common.Session.USER_SESSION] = acc;
                    if (string.IsNullOrEmpty(ReturnURL))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(ReturnURL);
                }
                else { return RedirectToAction("DangNhap", "Login"); }

            }
        }
        public ActionResult DangXuat()
        {
            Session[Common.Session.USER_SESSION] = null;
            return RedirectToAction("DangNhap", "Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}