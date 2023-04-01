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

namespace QuanLyNhaThuoc.Views.Home
{
    public class SanPhamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SanPhams
        [Authorize]
        public ActionResult Index()
        {
            var spHetSL = db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).Where(sl=>sl.SoLuong<=5).ToList();
            var spHetHSD= db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).Where(n=>n.HSD<=DateTime.Now).ToList();
            var listsanPhams = db.sanPhams.Include(s => s.LoaiSanPham).Include(s => s.NhaSanXuat).ToList();
            var viewModel = new ViewIndexModel
            {
                Object1 = spHetSL,
                Object2 = spHetHSD,
                Object3 = listsanPhams
            };
            return View(viewModel);
        }

        // GET: SanPhams/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams
                .Where(item => item.MaSanPham == id)
                .Include(loai=> loai.LoaiSanPham)
                .Include(sanXuat=>sanXuat.NhaSanXuat)
                .First();
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.loaiSanPhams, "MaLoai", "TenLoai");
            ViewBag.MaNhaSanXuat = new SelectList(db.nhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MaLoai,MaNhaSanXuat,ThanhPhanChinh,DoTuoi,CongDung,DonViTinh,NgayNhap,HSD,SoLuong,MoTa,GiaBan,LuotMua,LuotXem,IsCanceled=false")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.sanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.loaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaSanXuat = new SelectList(db.nhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.loaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaSanXuat = new SelectList(db.nhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,MaLoai,MaNhaSanXuat,ThanhPhanChinh,DoTuoi,CongDung,DonViTinh,NgayNhap,HSD,SoLuong,MoTa,GiaBan,LuotMua,LuotXem,IsCanceled=false")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.loaiSanPhams, "MaLoai", "TenLoai", sanPham.MaLoai);
            ViewBag.MaNhaSanXuat = new SelectList(db.nhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams
                .Where(item => item.MaSanPham == id)
                .Include(loai => loai.LoaiSanPham)
                .Include(sanXuat => sanXuat.NhaSanXuat)
                .First();
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.sanPhams.Find(id);
            sanPham.IsCanceled = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize]
        public ActionResult ThongKe()
        {
            return View();
        }
    }
}
