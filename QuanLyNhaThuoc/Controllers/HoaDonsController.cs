using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhaThuoc.Models;
using QuanLyNhaThuoc.ViewModel;

namespace QuanLyNhaThuoc.Controllers
{
    public class HoaDonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HoaDons
        public ActionResult Index()
        {
            return View(db.hoaDons.Include(s => s.NguoiDung).OrderByDescending(s => s.MaHoaDon).ToList());
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.hoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            var listCTHH = db.chiTietHoaDons.Include(s=>s.SanPham).Where(m => m.MaHoaDon == id).ToList();
            var viewModel = new ViewHoaDonModel
            {
                hoaDon = hoaDon,
                list=listCTHH,
            };
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
