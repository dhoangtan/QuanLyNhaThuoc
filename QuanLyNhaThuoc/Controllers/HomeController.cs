using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using QuanLyNhaThuoc.Models;
using QuanLyNhaThuoc.ViewModel;

namespace QuanLyNhaThuoc.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (User.Identity.Name == "admin@newty.com")
            {
                return RedirectToAction("Index", "SanPhams");
            }
            var sanPhams = db.sanPhams.Where(s => s.SoLuong > 0 && s.HSD > DateTime.Now && s.IsCanceled==false).Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).OrderByDescending(s => s.LuotXem).Take(8).ToList();
            var sanPhams2 = db.sanPhams.Where(s=>s.SoLuong>0 && s.HSD > DateTime.Now && s.IsCanceled == false).Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).OrderByDescending(s => s.LuotMua).Take(10).ToList();
            var sanPhams3 = db.sanPhams.Where(s=>s.SoLuong>0 && s.HSD > DateTime.Now && s.IsCanceled == false).Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).ToList();
            var viewIndexModel = new ViewIndexModel
            {
                Object1 = sanPhams,
                Object2 = sanPhams2,
                Object3 = sanPhams3
            };
            return View(viewIndexModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams
                                .Where(item => item.MaSanPham == id)
                                .Include(loai => loai.LoaiSanPham)
                                .Include(sanXuat => sanXuat.NhaSanXuat).First();
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            sanPham.LuotXem = sanPham.LuotXem + 1;
            db.SaveChanges();
            return View(sanPham);
        }
        
    }
}
