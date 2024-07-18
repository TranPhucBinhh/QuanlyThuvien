using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace QuanlyThuvien.Controllers
{
    public class Muontrasach2Controller : Controller
    {
        // GET: Muontrasach2
        QLThuVienEntities database = new QLThuVienEntities();
    
        public ActionResult Index()
        {
            var muonTras = database.MuonTras.Include("DocGia").ToList();
            return View(muonTras);
        }   
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MuonTra muonTra = database.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }

            return View(muonTra);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MuonTra muonTra = database.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaDocGia = new SelectList(database.DocGias, "MaDocGia", "HoTen", muonTra.MaDocGia);
            return View(muonTra);
        }

        // POST: MuonTra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMuonTra,MaDocGia,NgayMuon,NgayTra,TinhTrang")] MuonTra muonTra)
        {
            if (ModelState.IsValid)
            {
                database.Entry(muonTra).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDocGia = new SelectList(database.DocGias, "MaDocGia", "HoTen", muonTra.MaDocGia);  /*Thả danh sách các độc giả có sẵn*/
            return View(muonTra);
        }
        public ActionResult Create()
        {
            ViewBag.MaDocGia = new SelectList(database.DocGias, "MaDocGia", "HoTen");  /*Thả danh sách các độc giả có sẵn*/
            return View();
        }

        // POST: MuonTra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMuonTra,MaDocGia,NgayMuon,NgayTra,TinhTrang")] MuonTra muonTra)
        {
            if (ModelState.IsValid)
            {
                database.MuonTras.Add(muonTra);
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDocGia = new SelectList(database.DocGias, "MaDocGia", "HoTen", muonTra.MaDocGia);  /*Thả danh sách các độc giả có sẵn*/
            return View(muonTra);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MuonTra muonTra = database.MuonTras.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }

            return View(muonTra);
        }

        // POST: MuonTra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)        
        {
            MuonTra muonTra = database.MuonTras.Find(id);
            database.MuonTras.Remove(muonTra);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)     /*Hàm giải phóng tài nguyên khi xóa controller*/
        {
            if (disposing)
            {
                database.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}