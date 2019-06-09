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
    public class PhieuXuatThucAnsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuXuatThucAns
        public ActionResult Index()
        {
            var phieuXuatThucAns = db.PhieuXuatThucAns.Include(p => p.NhanVien).Include(p => p.VatNuoi);
            return View(phieuXuatThucAns.ToList());
        }

        // GET: PhieuXuatThucAns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThucAn phieuXuatThucAn = db.PhieuXuatThucAns.Find(id);
            if (phieuXuatThucAn == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatThucAn);
        }

        // GET: PhieuXuatThucAns/Create
        public ActionResult Create()
        {
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong");
            return View();
        }

        // POST: PhieuXuatThucAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPXTA,MaVatNuoi,MaNhanVien,NgayXuat")] PhieuXuatThucAn phieuXuatThucAn)
        {
            if (ModelState.IsValid)
            {
                db.PhieuXuatThucAns.Add(phieuXuatThucAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThucAn.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThucAn.MaVatNuoi);
            return View(phieuXuatThucAn);
        }

        // GET: PhieuXuatThucAns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThucAn phieuXuatThucAn = db.PhieuXuatThucAns.Find(id);
            if (phieuXuatThucAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThucAn.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThucAn.MaVatNuoi);
            return View(phieuXuatThucAn);
        }

        // POST: PhieuXuatThucAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPXTA,MaVatNuoi,MaNhanVien,NgayXuat")] PhieuXuatThucAn phieuXuatThucAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuXuatThucAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuXuatThucAn.MaNhanVien);
            ViewBag.MaVatNuoi = new SelectList(db.VatNuois, "MaVatNuoi", "MaChuong", phieuXuatThucAn.MaVatNuoi);
            return View(phieuXuatThucAn);
        }

        // GET: PhieuXuatThucAns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuXuatThucAn phieuXuatThucAn = db.PhieuXuatThucAns.Find(id);
            if (phieuXuatThucAn == null)
            {
                return HttpNotFound();
            }
            return View(phieuXuatThucAn);
        }

        // POST: PhieuXuatThucAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuXuatThucAn phieuXuatThucAn = db.PhieuXuatThucAns.Find(id);
            db.PhieuXuatThucAns.Remove(phieuXuatThucAn);
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
