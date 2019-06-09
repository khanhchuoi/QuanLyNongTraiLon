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
    public class PhieuXuatThuocsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuXuatThuocs
        public ActionResult Index()
        {
            var phieuXuatThuocs = db.PhieuXuatThuocs.Include(p => p.NhanVien).Include(p => p.VatNuoi);
            return View(phieuXuatThuocs.ToList());
        }

        // GET: PhieuXuatThuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThuoc phieuXuatThuoc = db.PhieuXuatThuocs.Find(id);
            if (phieuXuatThuoc == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatThuoc);
        }

        // GET: PhieuXuatThuocs/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong");
            return View();
        }

        // POST: PhieuXuatThuocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPXT,MaVatNuoi,MaNhanVien,NgayXuat")] PhieuXuatThuoc phieuXuatThuoc)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuatThuocs.Add(phieuXuatThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThuoc.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThuoc.MaVatNuoi);
            return View(phieuXuatThuoc);
        }

        // GET: PhieuXuatThuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThuoc phieuXuatThuoc = db.PhieuXuatThuocs.Find(id);
            if (phieuXuatThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThuoc.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThuoc.MaVatNuoi);
            return View(phieuXuatThuoc);
        }

        // POST: PhieuXuatThuocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPXT,MaVatNuoi,MaNhanVien,NgayXuat")] PhieuXuatThuoc phieuXuatThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuatThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThuoc.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThuoc.MaVatNuoi);
            return View(phieuXuatThuoc);
        }

        // GET: PhieuXuatThuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThuoc phieuXuatThuoc = db.PhieuXuatThuocs.Find(id);
            if (phieuXuatThuoc == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatThuoc);
        }

        // POST: PhieuXuatThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuXuatThuoc phieuXuatThuoc = db.PhieuXuatThuocs.Find(id);
            db.PhieuXuatThuocs.Remove(phieuXuatThuoc);
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
