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
            var sanPhams = db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).OrderByDescending(s => s.LuotXem).Take(8).ToList();
            var sanPhams2 = db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).OrderByDescending(s => s.LuotMua).Take(8).ToList();
            var sanPhams3 = db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).ToList();
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
        public ActionResult GioHang()
        {
            return View();
        }
        [Authorize]
        public ActionResult MuaHang(string id, int sl)
        {
            String user_id = User.Identity.GetUserId().ToString();
            var sanpham = db.sanPhams.FirstOrDefault(s => s.MaSanPham == id);
            var gh = db.gioHangs.FirstOrDefault(s => s.Id == user_id);
            var ctsp = db.chiTietGioHangs.Where(masp => masp.MaGiohang == gh.MaGioHang && masp.MaSanPham == id).First();
            
            if (sanpham != null)
            {
                if(ctsp.SoLuong == 0)
                {
                    var ct = new ChiTietGioHang();
                    ct.MaSanPham = id;
                    ct.MaGiohang = gh.MaGioHang;
                    ct.SoLuong = sl;
                    db.chiTietGioHangs.Add(ct);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var update_sp= db.chiTietGioHangs.Where(masp=>masp.MaGiohang==gh.MaGioHang && masp.MaSanPham==id).First();
                    update_sp.SoLuong = sl+ ctsp.SoLuong;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }           
            return HttpNotFound();
        }
    }
}
