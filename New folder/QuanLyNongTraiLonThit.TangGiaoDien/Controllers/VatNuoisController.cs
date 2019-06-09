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
    public class VatNuoisController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: VatNuois
        public ActionResult Index()
        {
            var vatNuois = db.VatNuois.Include(v => v.Chuong).Include(v => v.Giong);
            return View(vatNuois.ToList());
        }

        // GET: VatNuois/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatNuoi vatNuoi = db.VatNuois.Find(id);
            if (vatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(vatNuoi);
        }

        // GET: VatNuois/Create
        public ActionResult Create()
        {
            ViewBag.MaChuong = new SelectList(db.Chuongs, "MaChuong", "DayChuong");
            ViewBag.MaGiong = new SelectList(db.Giongs, "MaGiong", "TenGiong");
            return View();
        }

        // POST: VatNuois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVatNuoi,MaChuong,MaGiong,ThoiGianThuHoach,ThoiGianCachLy,TrangThai")] VatNuoi vatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.VatNuois.Add(vatNuoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuong = new SelectList(db.Chuongs, "MaChuong", "DayChuong", vatNuoi.MaChuong);
            ViewBag.MaGiong = new SelectList(db.Giongs, "MaGiong", "TenGiong", vatNuoi.MaGiong);
            return View(vatNuoi);
        }

        // GET: VatNuois/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatNuoi vatNuoi = db.VatNuois.Find(id);
            if (vatNuoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuong = new SelectList(db.Chuongs, "MaChuong", "DayChuong", vatNuoi.MaChuong);
            ViewBag.MaGiong = new SelectList(db.Giongs, "MaGiong", "TenGiong", vatNuoi.MaGiong);
            return View(vatNuoi);
        }

        // POST: VatNuois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVatNuoi,MaChuong,MaGiong,ThoiGianThuHoach,ThoiGianCachLy,TrangThai")] VatNuoi vatNuoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vatNuoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuong = new SelectList(db.Chuongs, "MaChuong", "DayChuong", vatNuoi.MaChuong);
            ViewBag.MaGiong = new SelectList(db.Giongs, "MaGiong", "TenGiong", vatNuoi.MaGiong);
            return View(vatNuoi);
        }

        // GET: VatNuois/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatNuoi vatNuoi = db.VatNuois.Find(id);
            if (vatNuoi == null)
            {
                return HttpNotFound();
            }
            return View(vatNuoi);
        }

        // POST: VatNuois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VatNuoi vatNuoi = db.VatNuois.Find(id);
            db.VatNuois.Remove(vatNuoi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BiBenh()
        {
            var conVatBiBenh = db.VatNuois.Include(v => v.Chuong).Include(v => v.Giong).Where(v => v.TrangThai == 1).ToList();
                // Có thể lấy theo trạng thái. Nhưng chưa bắt được sự kiện trigger update. 

            return View("Index", conVatBiBenh);
        }
        public ActionResult XuatBan()
        {
            DateTime quarantineTime = DateTime.Now.AddDays(16);
            // Có thể lấy theo trạng thái. Nhưng chưa bắt được sự kiện trigger update. 
            var conVatXuatBan = db.VatNuois.Include(v => v.Chuong).Where(v => v.ThoiGianThuHoach < quarantineTime && v.ThoiGianCachLy <= DateTime.Now).ToList();

            return View("Index", conVatXuatBan);
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
