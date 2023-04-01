using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QuanLyNhaThuoc.DTOs;
using QuanLyNhaThuoc.Models;

namespace QuanLyNhaThuoc.Controllers
{
    public class GioHangController : Controller
    {
        private ApplicationDbContext _dbContext;

        public GioHangController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: GioHang
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.Name == "admin@newty.com")
            {
                return RedirectToAction("Index", "SanPhams");
            }
            string userId = User.Identity.GetUserId();
            ApplicationUser user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            ViewBag.Name = user.Name;
            ViewBag.Phone = user.PhoneNumber;
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            if (cart == null)
            {
                cart = new GioHang
                {
                    Id = userId,
                    NgayLap = DateTime.Now,
                };
                _dbContext.gioHangs.Add(cart);
                _dbContext.SaveChanges();
            }
            var cartDetail = _dbContext
                .chiTietGioHangs.Where(cd => cd.MaGiohang == cart.MaGioHang)
                .Include(s => s.SanPham)
                .ToList();
            return View(cartDetail);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Buy(string name, string address, string phone)
        {
            var userId = User.Identity.GetUserId();
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            List<ChiTietGioHang> cartDetail =
                _dbContext.chiTietGioHangs.Where(cd => cd.MaGiohang == cart.MaGioHang).ToList();
            
            if (cartDetail.Count == 0 || cartDetail == null)
                return RedirectToAction("Index", "GioHang");

            HoaDon bill = new HoaDon
            {
                Id = userId,
                NgayXuat = DateTime.Now,
                TenNguoiDat = name,
                DiaChi = address,
                SoDienThoai = phone
            };

            _dbContext.hoaDons.Add(bill);
            _dbContext.SaveChanges();


            foreach (var item in cartDetail)
            {
                var billDetail = new ChiTietHoaDon();

                billDetail.HoaDon = bill;
                billDetail.MaSanPham = item.MaSanPham;
                billDetail.SoLuong = item.SoLuong;
                var sanPham =  _dbContext.sanPhams.FirstOrDefault(sp => sp.MaSanPham == item.MaSanPham);
                sanPham.SoLuong -= item.SoLuong;
                billDetail.DonGia = sanPham.GiaBan;
                _dbContext.chiTietHoaDons.AddOrUpdate(billDetail);
                _dbContext.sanPhams.AddOrUpdate(sanPham);
            }

            foreach (var item in cartDetail)
            {
                _dbContext.chiTietGioHangs.Remove(item);
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveItem(CartItemDto dto)
        {
            string userId = User.Identity.GetUserId();
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            var cartDetail =
                _dbContext.chiTietGioHangs.FirstOrDefault(
                    c => c.MaSanPham == dto.productId && c.MaGiohang == cart.MaGioHang);
            if (cartDetail != null)
                cartDetail.SoLuong = dto.amount;

            _dbContext.chiTietGioHangs.Remove(cartDetail);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "GioHang");
        }
    }
}