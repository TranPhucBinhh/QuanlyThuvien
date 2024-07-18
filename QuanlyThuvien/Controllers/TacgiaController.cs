using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class TacgiaController : Controller
    {
        // GET: Tacgia
        QLThuVienEntities database = new QLThuVienEntities();
        public ActionResult Index()
        {
            return View(database.TacGias.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(TacGia tacgia)
        {
            database.TacGias.Add(tacgia); 
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); 
        }

        public ActionResult Details(int id)
        {
            return View(database.TacGias.Where(s => s.MaTacGia == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.TacGias.Where(s => s.MaTacGia == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, TacGia tacgia)
        {
            database.Entry(tacgia).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.TacGias.Where(s => s.MaTacGia == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, TacGia tacgia)
        {
            tacgia = database.TacGias.Where((s) => s.MaTacGia == id).FirstOrDefault();
            database.TacGias.Remove(tacgia);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}