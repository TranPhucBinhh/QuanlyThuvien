using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using QuanlyThuvien.Models;
using System.Web.Razor.Tokenizer.Symbols;
using System.Net;
using System.Data;

namespace QuanlyThuvien.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QLThuVienEntities database = new QLThuVienEntities();
        // GET: TrangChu
        public ActionResult Index()
        {
            var Sach = database.Saches.Include(c => c.TacGia).Include(c => c.TheLoai).ToList();
            return View(Sach);
        }
        public ActionResult Them()
        {
            ViewBag.MaTacGia = new SelectList(database.TacGias, "MaTacGia", "TenTacGia");
            ViewBag.MaTheLoai = new SelectList(database.TheLoais, "MaTheLoai", "TenTheLoai");
            ViewBag.MaNhaCungCap = new SelectList(database.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            /*Thả danh sách các tác giả có sẵn*/
            return View();
        }
        [HttpPost] //ghi nhận dữ liệu
        public ActionResult Them(Sach sach)
        {
            database.Saches.Add(sach); //Hàm thêm data bảng phụ tùng
            database.SaveChanges(); //Lưu vào data
            return RedirectToAction("Index"); //Lưu xong điều hướng về trang phụ tùng 
        }

        public ActionResult Details(int id)
        {
            return View(database.Saches.Where(s => s.MaSach == id).FirstOrDefault());
        }
        public ActionResult Edit(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sach muonTra = database.Saches.Find(id);
            if (muonTra == null)
            {
                return HttpNotFound();
            }
                     //Tạo dữ liệu tacgia và theloai từ 2 bảng TheLoai và TacGia
            ViewBag.MaTacGia = new SelectList(database.TacGias, "MaTacGia", "TenTacGia", muonTra.MaTacGia);
            ViewBag.MaTheLoai = new SelectList(database.TheLoais, "MaTheLoai", "TenTheLoai", muonTra.MaTheLoai);
            ViewBag.MaNhaCungCap = new SelectList(database.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap",muonTra.MaNhaCungCap);
            return View(muonTra);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,MaTacGia,MaTheLoai,NamXuatBan,NhaXuatBan,SoLuong,MaNhaCungCap,HinhAnh")] Sach muonTra)
        {
            if (ModelState.IsValid)
            {
                database.Entry(muonTra).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTacGia = new SelectList(database.Saches, "MaTacGia", "TenTacGia", muonTra.MaTacGia);  /*Thả danh sách các tacgia có sẵn*/
            ViewBag.MaTheLoai = new SelectList(database.TheLoais, "MaTheLoai", "TenTheLoai", muonTra.MaTheLoai); /*Thả danh sách các theloai có sẵn*/
            ViewBag.MaNhaCungCap = new SelectList(database.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", muonTra.MaNhaCungCap); //danh sach nhacungcap
            return View(muonTra);
        }
        public ActionResult Delete(int id)
        {
            return View(database.Saches.Where(s => s.MaSach == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Sach sach)
        {
            sach = database.Saches.Where((s) => s.MaSach == id).FirstOrDefault();  
            database.Saches.Remove(sach);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TimKiemSach(string keyword)  /*  truyền thuộc tính keyword ở model*/
        {
            var viewModel = new TimKiemSach();      /*khai báo biến timkiemsach ở model*/

            if (!string.IsNullOrEmpty(keyword))
            {
                viewModel.Results = database.Saches.Where(s => s.TenSach.Contains(keyword)).ToList();
            }
            return View(viewModel);
        }   
    }
}