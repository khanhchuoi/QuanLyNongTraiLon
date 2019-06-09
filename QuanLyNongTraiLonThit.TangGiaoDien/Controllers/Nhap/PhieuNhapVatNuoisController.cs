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
    public class PhieuNhapVatNuoisController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuNhapVatNuois
        public ActionResult Index()
        {
            var phieuNhapVatNuois = db.PhieuNhapVatNuois.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
            return View(phieuNhapVatNuois.ToList());
        }

        // GET: PhieuNhapVatNuois/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapVatNuoi phieuNhapVatNuoi = db.PhieuNhapVatNuois.Find(id);
            if (phieuNhapVatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapVatNuoi);
        }

        // GET: PhieuNhapVatNuois/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: PhieuNhapVatNuois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPNVN,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapVatNuoi phieuNhapVatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapVatNuois.Add(phieuNhapVatNuoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapVatNuoi.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapVatNuoi.MaNhanVien);
            return View(phieuNhapVatNuoi);
        }

        // GET: PhieuNhapVatNuois/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapVatNuoi phieuNhapVatNuoi = db.PhieuNhapVatNuois.Find(id);
            if (phieuNhapVatNuoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapVatNuoi.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapVatNuoi.MaNhanVien);
            return View(phieuNhapVatNuoi);
        }

        // POST: PhieuNhapVatNuois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPNVN,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapVatNuoi phieuNhapVatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapVatNuoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapVatNuoi.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapVatNuoi.MaNhanVien);
            return View(phieuNhapVatNuoi);
        }

        // GET: PhieuNhapVatNuois/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapVatNuoi phieuNhapVatNuoi = db.PhieuNhapVatNuois.Find(id);
            if (phieuNhapVatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapVatNuoi);
        }

        // POST: PhieuNhapVatNuois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapVatNuoi phieuNhapVatNuoi = db.PhieuNhapVatNuois.Find(id);
            db.PhieuNhapVatNuois.Remove(phieuNhapVatNuoi);
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
