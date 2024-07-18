using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        QLThuVienEntities database = new QLThuVienEntities();
        public ActionResult Index()
        {
            return View(database.NhaCungCaps.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(NhaCungCap nhacungcap)
        {
            database.NhaCungCaps.Add(nhacungcap); 
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); //điều hướng
        }

        public ActionResult Details(int id)
        {
            return View(database.NhaCungCaps.Where(s => s.MaNhaCungCap == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.NhaCungCaps.Where(s => s.MaNhaCungCap == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, NhaCungCap nhacungcap)
        {
            database.Entry(nhacungcap).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.NhaCungCaps.Where(s => s.MaNhaCungCap == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, NhaCungCap nhacungcap)
        {
            nhacungcap = database.NhaCungCaps.Where((s) => s.MaNhaCungCap == id).FirstOrDefault();
            database.NhaCungCaps.Remove(nhacungcap);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}