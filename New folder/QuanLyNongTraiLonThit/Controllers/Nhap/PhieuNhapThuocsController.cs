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
    public class PhieuNhapThuocsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuNhapThuocs
        public ActionResult Index()
        {
            var phieuNhapThuocs = db.PhieuNhapThuocs.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
            return View(phieuNhapThuocs.ToList());
        }

        // GET: PhieuNhapThuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThuoc phieuNhapThuoc = db.PhieuNhapThuocs.Find(id);
            if (phieuNhapThuoc == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapThuoc);
        }

        // GET: PhieuNhapThuocs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: PhieuNhapThuocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPNT,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapThuoc phieuNhapThuoc)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapThuocs.Add(phieuNhapThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThuoc.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThuoc.MaNhanVien);
            return View(phieuNhapThuoc);
        }

        // GET: PhieuNhapThuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThuoc phieuNhapThuoc = db.PhieuNhapThuocs.Find(id);
            if (phieuNhapThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThuoc.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThuoc.MaNhanVien);
            return View(phieuNhapThuoc);
        }

        // POST: PhieuNhapThuocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPNT,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapThuoc phieuNhapThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThuoc.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThuoc.MaNhanVien);
            return View(phieuNhapThuoc);
        }

        // GET: PhieuNhapThuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThuoc phieuNhapThuoc = db.PhieuNhapThuocs.Find(id);
            if (phieuNhapThuoc == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapThuoc);
        }

        // POST: PhieuNhapThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapThuoc phieuNhapThuoc = db.PhieuNhapThuocs.Find(id);
            db.PhieuNhapThuocs.Remove(phieuNhapThuoc);
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
