using QuanlyThuvien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThuvien.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        QLThuVienEntities database = new QLThuVienEntities();
        public ActionResult Index()
        {
            var thongKe = new ThongKeViewModel
            {
                TongSoDocGia = database.DocGias.Count(),
                TongSoSach = database.Saches.Count(),
                TongSoMuonTra = database.MuonTras.Count(),
                TongSoNhanVien = database.NhanViens.Count(),
                DanhSachSach = database.Saches.ToList(), //xuat danh sach sach
            };
            return View(thongKe);

        }

        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
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
    // ViewModel cho trang thống kê
    public class ThongKeViewModel
    {
        public int TongSoDocGia { get; set; }
        public int TongSoSach { get; set; }
        public int TongSoMuonTra { get; set; }
        public int TongSoNhanVien { get; set; }
        public List<Sach> DanhSachSach { get; set; }  //Lay du lieu sach
        // TThem cac thuoc tinh
    }

}