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
    public class GiongsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: Giongs
        public ActionResult Index()
        {
            return View(db.Giongs.ToList());
        }

        // GET: Giongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giong giong = db.Giongs.Find(id);
            if (giong == null)
            {
                return HttpNotFound();
            }
            return View(giong);
        }

        // GET: Giongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Giongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiong,TenGiong,ThoiGianThuHoach")] Giong giong)
        {
            if (ModelState.IsValid)
            {
                db.Giongs.Add(giong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giong);
        }

        // GET: Giongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giong giong = db.Giongs.Find(id);
            if (giong == null)
            {
                return HttpNotFound();
            }
            return View(giong);
        }

        // POST: Giongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiong,TenGiong,ThoiGianThuHoach")] Giong giong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giong);
        }

        // GET: Giongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giong giong = db.Giongs.Find(id);
            if (giong == null)
            {
                return HttpNotFound();
            }
            return View(giong);
        }

        // POST: Giongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Giong giong = db.Giongs.Find(id);
            db.Giongs.Remove(giong);
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
