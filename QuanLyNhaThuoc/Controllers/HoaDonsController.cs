using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QuanLyNhaThuoc.Models;
using QuanLyNhaThuoc.ViewModel;

namespace QuanLyNhaThuoc.Controllers
{
    public class HoaDonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HoaDons
        [Authorize]
        public ActionResult Index()
        {
            return View(db.hoaDons.Include(s => s.NguoiDung).OrderByDescending(s => s.MaHoaDon).ToList());
        }
        [Authorize]
        public ActionResult Index_KH()
        {
            var id = User.Identity.GetUserId();
            return View(db.hoaDons.Where(s=>s.Id==id).Include(s => s.NguoiDung).OrderByDescending(s => s.MaHoaDon).ToList());
        }

        // GET: HoaDons/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Details_KH(int? id)
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
            var listCTHH = db.chiTietHoaDons.Include(s => s.SanPham).Where(m => m.MaHoaDon == id).ToList();
            var viewModel = new ViewHoaDonModel
            {
                hoaDon = hoaDon,
                list = listCTHH,
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
