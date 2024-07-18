using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class TheloaiController : Controller
    {
        // GET: Theloai
        QLThuVienEntities database = new QLThuVienEntities();
        public ActionResult Index()
        {
            return View(database.TheLoais.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(TheLoai theLoai)
        {
            database.TheLoais.Add(theLoai); //Hàm thêm data bảng phụ tùng
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); //Lưu xong điều hướng về trang phụ tùng 
        }

        public ActionResult Details(int id)
        {
            return View(database.TheLoais.Where(s => s.MaTheLoai == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.TheLoais.Where(s => s.MaTheLoai == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, TheLoai theLoai)
        {
            database.Entry( theLoai).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.TheLoais.Where(s => s.MaTheLoai == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, TheLoai theLoai)
        {
            theLoai = database.TheLoais.Where((s) => s.MaTheLoai == id).FirstOrDefault();
            database.TheLoais.Remove(theLoai);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}