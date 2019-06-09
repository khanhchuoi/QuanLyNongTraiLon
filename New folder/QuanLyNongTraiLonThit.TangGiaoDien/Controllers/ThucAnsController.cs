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
    public class ThucAnsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: ThucAns
        public ActionResult Index()
        {
            return View(db.ThucAns.ToList());
        }

        // GET: ThucAns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucAn thucAn = db.ThucAns.Find(id);
            if (thucAn == null)
            {
                return HttpNotFound();
            }
            return View(thucAn);
        }

        // GET: ThucAns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThucAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThucAn,TenThucAn,SoLuongTon,DonViTinh")] ThucAn thucAn)
        {
            if (ModelState.IsValid)
            {
                db.ThucAns.Add(thucAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thucAn);
        }

        // GET: ThucAns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucAn thucAn = db.ThucAns.Find(id);
            if (thucAn == null)
            {
                return HttpNotFound();
            }
            return View(thucAn);
        }

        // POST: ThucAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThucAn,TenThucAn,SoLuongTon,DonViTinh")] ThucAn thucAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thucAn);
        }

        // GET: ThucAns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucAn thucAn = db.ThucAns.Find(id);
            if (thucAn == null)
            {
                return HttpNotFound();
            }
            return View(thucAn);
        }

        // POST: ThucAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThucAn thucAn = db.ThucAns.Find(id);
            db.ThucAns.Remove(thucAn);
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
