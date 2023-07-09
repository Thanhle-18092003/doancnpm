using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLyTapHoa.Models;

namespace WebQuanLyTapHoa.Controllers
{
    public class NhapHangsController : Controller
    {
        private QuanLyTapHoaEntities db = new QuanLyTapHoaEntities();

        // GET: NhapHangs
        public ActionResult Index()
        {
            var nhapHangs = db.NhapHangs.Include(n => n.SanPham);
            return View(nhapHangs.ToList());
        }

        // GET: NhapHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapHang nhapHang = db.NhapHangs.Find(id);
            if (nhapHang == null)
            {
                return HttpNotFound();
            }
            return View(nhapHang);
        }

        // GET: NhapHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: NhapHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhapHang,MaSP,NgayNhapSP,SoLuongNhap")] NhapHang nhapHang)
        {
            if (ModelState.IsValid)
            {
                db.NhapHangs.Add(nhapHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", nhapHang.MaSP);
            return View(nhapHang);
        }

        // GET: NhapHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapHang nhapHang = db.NhapHangs.Find(id);
            if (nhapHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", nhapHang.MaSP);
            return View(nhapHang);
        }

        // POST: NhapHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhapHang,MaSP,NgayNhapSP,SoLuongNhap")] NhapHang nhapHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", nhapHang.MaSP);
            return View(nhapHang);
        }

        // GET: NhapHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapHang nhapHang = db.NhapHangs.Find(id);
            if (nhapHang == null)
            {
                return HttpNotFound();
            }
            return View(nhapHang);
        }

        // POST: NhapHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhapHang nhapHang = db.NhapHangs.Find(id);
            db.NhapHangs.Remove(nhapHang);
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
