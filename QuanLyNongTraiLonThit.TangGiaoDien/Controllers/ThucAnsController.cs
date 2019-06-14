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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formCollection)
        {
            ThucAn thucAn = new ThucAn();

            thucAn.TenThucAn = formCollection["TenThucAn"];
            thucAn.SoLuongTon = 0;
            thucAn.DonViTinh = formCollection["DonViTinh"];
          
            int mahientai = 0;
            string maht = db.Database.SqlQuery<string>("Select MAX(RIGHT(MaThucAn, 3)) FROM dbo.ThucAn").FirstOrDefault();
            if (maht != null)
            {
                mahientai = Int32.Parse(maht);
            }

            thucAn.MaThucAn = Helper.TaoMa("TA", mahientai);
            if (thucAn != null)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection formCollection)
        {
            ThucAn thucAn = new ThucAn();

            thucAn.TenThucAn = formCollection["TenThucAn"];
           // thucAn.SoLuongTon = 0;
            thucAn.DonViTinh = formCollection["DonViTinh"];

            if (thucAn != null)
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
        //[ValidateAntiForgeryToken]
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
