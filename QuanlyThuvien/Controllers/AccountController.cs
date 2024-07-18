using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private QLThuVienEntities db = new QLThuVienEntities(); 
        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string TenDangNhap, string MatKhau)
        {   
            if (ModelState.IsValid)
            {
                var taiKhoan = db.TaiKhoans.SingleOrDefault(t => t.TenDangNhap == TenDangNhap && t.MatKhau == MatKhau);
                if (taiKhoan != null)
                {
                    // Đăng nhập thành công
                    // Lưu thông tin đăng nhập vào Session 
                    Session["MaTaiKhoan"] = taiKhoan.MaTaiKhoan;
                    Session["TenDangNhap"] = taiKhoan.TenDangNhap;
                    Session["HoTen"] = taiKhoan.HoTen;
                    return RedirectToAction("Index", "TrangChu"); // Chuyển hướng đến trang chủ 
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }

            return View();
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem Tên đăng nhập đã tồn tại chưa
                if (db.TaiKhoans.Any(t => t.TenDangNhap == taiKhoan.TenDangNhap))
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    // Thêm mới tài khoản vào cơ sở dữ liệu 
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();
                    return RedirectToAction("Login"); // Chuyển hướng đến trang đăng nhập
                }
            }
            return View(taiKhoan);
        }
        // GET: /Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            // Xóa Session để đăng xuất
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}