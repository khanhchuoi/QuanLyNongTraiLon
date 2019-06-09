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
    public class PhieuNhapThucAnsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: PhieuNhapThucAns
        public ActionResult Index()
        {
            var phieuNhapThucAns = db.PhieuNhapThucAns.Include(p => p.NhaCungCap).Include(p => p.NhanVien);
            return View(phieuNhapThucAns.ToList());
        }

        // GET: PhieuNhapThucAns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThucAn phieuNhapThucAn = db.PhieuNhapThucAns.Find(id);
            if (phieuNhapThucAn == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapThucAn);
        }

        // GET: PhieuNhapThucAns/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: PhieuNhapThucAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPNTA,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapThucAn phieuNhapThucAn)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapThucAns.Add(phieuNhapThucAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThucAn.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThucAn.MaNhanVien);
            return View(phieuNhapThucAn);
        }

        // GET: PhieuNhapThucAns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThucAn phieuNhapThucAn = db.PhieuNhapThucAns.Find(id);
            if (phieuNhapThucAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThucAn.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThucAn.MaNhanVien);
            return View(phieuNhapThucAn);
        }

        // POST: PhieuNhapThucAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPNTA,MaNCC,MaNhanVien,NgayNhap")] PhieuNhapThucAn phieuNhapThucAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapThucAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", phieuNhapThucAn.MaNCC);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuNhapThucAn.MaNhanVien);
            return View(phieuNhapThucAn);
        }

        // GET: PhieuNhapThucAns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapThucAn phieuNhapThucAn = db.PhieuNhapThucAns.Find(id);
            if (phieuNhapThucAn == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapThucAn);
        }

        // POST: PhieuNhapThucAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapThucAn phieuNhapThucAn = db.PhieuNhapThucAns.Find(id);
            db.PhieuNhapThucAns.Remove(phieuNhapThucAn);
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
