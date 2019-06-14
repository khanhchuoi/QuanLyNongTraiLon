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
    public class ThuocsController : Controller
    {
        private QuanLyNongTraiLonDBContext db = new QuanLyNongTraiLonDBContext();

        // GET: Thuocs
        public ActionResult Index()
        {
            return View(db.Thuocs.OrderBy(t=>t.SoLuong).ToList());
        }

        // GET: Thuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // GET: Thuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formCollection)
        {
            Thuoc thuoc = new Thuoc();
            thuoc.SoLuong = Int32.Parse( formCollection["SoLuong"]);
            thuoc.TenThuoc = formCollection["TenThuoc"];
            thuoc.ThoiGianCachLy = Int32.Parse(formCollection["ThoiGianCachLy"]);
            thuoc.DonViTinh = formCollection["DonViTinh"];

            int mahientai = 0;
            string maht = db.Database.SqlQuery<string>("Select MAX(RIGHT(MaThuoc, 3)) FROM dbo.Thuoc").FirstOrDefault();
            if (maht != null)
            {
                mahientai = Int32.Parse(maht);
            }

            thuoc.MaThuoc = Helper.TaoMa("TH", mahientai);
            if (thuoc != null)
            {
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(thuoc);
        }

        // GET: Thuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Thuocs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection formCollection)
        {
            Thuoc thuoc = new Thuoc();
            //thuoc.SoLuong = Int32.Parse(formCollection["SoLuong"]);
            thuoc.TenThuoc = formCollection["TenThuoc"];
            thuoc.ThoiGianCachLy = Int32.Parse(formCollection["ThoiGianCachLy"]);
            thuoc.DonViTinh = formCollection["DonViTinh"];

            if (thuoc != null)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuoc);
        }

        // GET: Thuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Thuoc thuoc = db.Thuocs.Find(id);
            db.Thuocs.Remove(thuoc);
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
