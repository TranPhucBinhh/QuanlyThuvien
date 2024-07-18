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
    public class ChitietphieumuonController : Controller
    {
        QLThuVienEntities database = new QLThuVienEntities();
        // GET: Chitietphieumuon
        public ActionResult Index()
        {
            var Chitietmuon = database.ChiTietPhieuMuonTras.Include("MuonTra").ToList();
            return View(Chitietmuon);
        }
        public ActionResult Create()
        {
            ViewBag.MaMuonTra = new SelectList(database.MuonTras, "MaMuonTra", "MaMuonTra");
            ViewBag.MaSach = new SelectList(database.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: ChiTietMuonTra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTiet,MaMuonTra,MaSach,NgayMuon,NgayTra,So_Luong")] ChiTietPhieuMuonTra chiTietMuonTra)
        {
            if (ModelState.IsValid)
            {
                database.ChiTietPhieuMuonTras.Add(chiTietMuonTra);
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMuonTra = new SelectList(database.MuonTras, "MaMuonTra", "MaMuonTra", chiTietMuonTra.MaMuonTra);
            ViewBag.MaSach = new SelectList(database.Saches, "MaSach", "TenSach", chiTietMuonTra.MaSach);
            return View(chiTietMuonTra);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuMuonTra chiTietMuonTra = database.ChiTietPhieuMuonTras.Find(id);
            if (chiTietMuonTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMuonTra = new SelectList(database.MuonTras, "MaMuonTra", "MaMuonTra", chiTietMuonTra.MaMuonTra);
            ViewBag.MaSach = new SelectList(database.Saches, "MaSach", "TenSach", chiTietMuonTra.MaSach);
            return View(chiTietMuonTra);
        }

        // POST: ChiTietMuonTra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTiet,MaMuonTra,MaSach,NgayMuon,NgayTra,So_Luong")] ChiTietPhieuMuonTra chiTietMuonTra)
        {
            if (ModelState.IsValid)
            {
                database.Entry(chiTietMuonTra).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMuonTra = new SelectList(database.MuonTras, "MaMuonTra", "MaMuonTra", chiTietMuonTra.MaMuonTra);
            ViewBag.MaSach = new SelectList(database.Saches, "MaSach", "TenSach", chiTietMuonTra.MaSach);
            return View(chiTietMuonTra);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuMuonTra chiTietMuonTra = database.ChiTietPhieuMuonTras.Find(id);
            if (chiTietMuonTra == null)
            {
                return HttpNotFound();
            }
            return View(chiTietMuonTra);
        }

        // POST: ChiTietMuonTra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuMuonTra chiTietMuonTra = database.ChiTietPhieuMuonTras.Find(id);
            database.ChiTietPhieuMuonTras.Remove(chiTietMuonTra);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}