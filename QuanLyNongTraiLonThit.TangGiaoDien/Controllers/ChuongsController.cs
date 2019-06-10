using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TangNghiepVu;
using QuanLyNongTraiLonThit.TienIch;

namespace QuanLyNongTraiLonThit.TangGiaoDien.Controllers
{
    public class ChuongsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: Chuongs
        public ActionResult Index()
        {
            return View(db.Chuongs.ToList());
        }

        // GET: Chuongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong chuong = db.Chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            return View(chuong);
        }

        // GET: Chuongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chuongs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formCollection)
        {
            Chuong chuong = new Chuong();
            chuong.DayChuong = formCollection["DayChuong"];
            chuong.TrangThai = byte.Parse(formCollection["TrangThai"]);

            int mahientai = 0;
            string maht = db.Database.SqlQuery<string>("Select MAX(RIGHT(MaChuong, 3)) FROM dbo.Chuong WHERE MaChuong LIKE @prefix", new SqlParameter("@prefix", "C" + chuong.DayChuong + "%")).FirstOrDefault();
            if (maht != null)
            {
                mahientai = Int32.Parse(maht);
            }

            chuong.MaChuong = Helper.TaoMa("C" + chuong.DayChuong, mahientai);
            if (chuong != null)
            {
                db.Chuongs.Add(chuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(chuong);
        }

        // GET: Chuongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong chuong = db.Chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            return View(chuong);
        }

        // POST: Chuongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection formCollection)
        {
            Chuong chuong = new Chuong();
            chuong.MaChuong = formCollection["MaChuong"];
            chuong.DayChuong = formCollection["DayChuong"];
            chuong.TrangThai = byte.Parse(formCollection["TrangThai"]);
            if (chuong != null)
            {
                db.Entry(chuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuong);
        }

        // GET: Chuongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong chuong = db.Chuongs.Find(id);
            if (chuong == null)
            {
                return HttpNotFound();
            }
            return View(chuong);
        }

        // POST: Chuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        //ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chuong chuong = db.Chuongs.Find(id);
            db.Chuongs.Remove(chuong);
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
