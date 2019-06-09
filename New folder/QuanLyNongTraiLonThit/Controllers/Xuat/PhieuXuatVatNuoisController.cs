using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TangNghiepVu;
using QuanLyNongTraiLonThit.TienIch;

namespace QuanLyNongTraiLonThit.TangGiaoDien.Controllers
{
    public class PhieuXuatVatNuoisController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuXuatVatNuois
        public ActionResult Index()
        {
            var phieuXuatVatNuois = db.PhieuXuatVatNuois.Include(p => p.KhachHang).Include(p => p.NhanVien);
            return View(phieuXuatVatNuois.ToList());
        }

        // GET: PhieuXuatVatNuois/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatVatNuoi phieuXuatVatNuoi = db.PhieuXuatVatNuois.Find(id);
            if (phieuXuatVatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatVatNuoi);
        }

        // GET: PhieuXuatVatNuois/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: PhieuXuatVatNuois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPXVN,MaKhachHang,MaNhanVien,NgayXuat")] PhieuXuatVatNuoi phieuXuatVatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuatVatNuois.Add(phieuXuatVatNuoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", phieuXuatVatNuoi.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatVatNuoi.MaNhanVien);
            return View(phieuXuatVatNuoi);
        }

        // GET: PhieuXuatVatNuois/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatVatNuoi phieuXuatVatNuoi = db.PhieuXuatVatNuois.Find(id);
            if (phieuXuatVatNuoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", phieuXuatVatNuoi.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatVatNuoi.MaNhanVien);
            return View(phieuXuatVatNuoi);
        }

        // POST: PhieuXuatVatNuois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPXVN,MaKhachHang,MaNhanVien,NgayXuat")] PhieuXuatVatNuoi phieuXuatVatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuatVatNuoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", phieuXuatVatNuoi.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatVatNuoi.MaNhanVien);
            return View(phieuXuatVatNuoi);
        }

        // GET: PhieuXuatVatNuois/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatVatNuoi phieuXuatVatNuoi = db.PhieuXuatVatNuois.Find(id);
            if (phieuXuatVatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatVatNuoi);
        }

        // POST: PhieuXuatVatNuois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuXuatVatNuoi phieuXuatVatNuoi = db.PhieuXuatVatNuois.Find(id);
            db.PhieuXuatVatNuois.Remove(phieuXuatVatNuoi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
