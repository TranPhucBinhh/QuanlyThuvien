using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class DocgiaController : Controller
    {
        // GET: Docgia
        QLThuVienEntities database = new QLThuVienEntities();
        // GET: TrangPhuTung
        public ActionResult Index()
        {
            return View(database.DocGias.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(DocGia docgia)
        {
            database.DocGias.Add(docgia); //Hàm thêm data bảng phụ tùng
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); //Lưu xong điều hướng về trang phụ tùng 
        }

        public ActionResult Details(int id)
        {
            return View(database.DocGias.Where(s => s.MaDocGia == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.DocGias.Where(s => s.MaDocGia == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, DocGia docgia)
        {
            database.Entry(docgia).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.DocGias.Where(s => s.MaDocGia == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, DocGia docgia)
        {
            docgia = database.DocGias.Where((s) => s.MaDocGia == id).FirstOrDefault();
            database.DocGias.Remove(docgia);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}