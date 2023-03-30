using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Antlr.Runtime;
using Microsoft.AspNet.Identity;
using QuanLyNhaThuoc.Models;

namespace QuanLyNhaThuoc.Controllers
{
    public class GioHangApiController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public GioHangApiController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpGet]        
        public IHttpActionResult AddToCart(string productId, int amount)
        {
            string userId = User.Identity.GetUserId();
            var gioHang = _dbContext.gioHangs.FirstOrDefault(cart => cart.Id == userId);
            if (gioHang == null)
            {
                gioHang = new GioHang
                {
                    Id = userId,
                    NgayLap = DateTime.Now
                };
                _dbContext.gioHangs.Add(gioHang);
            }
            ChiTietGioHang cartDetail = new ChiTietGioHang
            {
                MaGiohang = gioHang.MaGioHang,
                MaSanPham = productId,
                SoLuong = amount
            };
            _dbContext.chiTietGioHangs.Add(cartDetail);
            _dbContext.SaveChanges();
           return Ok();
        }

        [HttpPost]
        public IHttpActionResult RemoveFromCart(string productId, int cartId)
        {
            var cart = _dbContext.gioHangs.Where(c => c.MaGioHang == cartId).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest();
            }
            var cartDetail = _dbContext.chiTietGioHangs.Where(c => c.MaSanPham == productId && c.MaGiohang == cartId).FirstOrDefault();
            _dbContext.chiTietGioHangs.Remove(cartDetail);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateCart(string productId, int amount, int cartId)
        {
            var cart = _dbContext.gioHangs.Where(c => c.MaGioHang == cartId).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest();
            }
            var cartDetail = _dbContext.chiTietGioHangs.Where(c => c.MaSanPham == productId && c.MaGiohang == cartId).FirstOrDefault();
            cartDetail.SoLuong = amount;
            _dbContext.chiTietGioHangs.AddOrUpdate(cartDetail);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}