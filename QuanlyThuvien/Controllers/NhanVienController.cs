using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        QLThuVienEntities database = new QLThuVienEntities();
        // GET: TrangPhuTung
        public ActionResult Index()
        {
            return View(database.NhanViens.ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(NhanVien nhanvien)
        {
            database.NhanViens.Add(nhanvien); //Hàm thêm data bảng phụ tùng
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); //Lưu xong điều hướng về trang phụ tùng 
        }

        public ActionResult Details(int id)
        {
            return View(database.NhanViens.Where(s => s.MaNhanVien == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.NhanViens.Where(s => s.MaNhanVien == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, NhanVien nhanvien)
        {
            database.Entry(nhanvien).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.NhanViens.Where(s => s.MaNhanVien == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, NhanVien nhanvien)
        {
            nhanvien = database.NhanViens.Where((s) => s.MaNhanVien == id).FirstOrDefault();
            database.NhanViens.Remove(nhanvien);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}