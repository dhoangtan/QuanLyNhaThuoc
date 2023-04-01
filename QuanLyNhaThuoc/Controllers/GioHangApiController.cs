using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Antlr.Runtime;
using Microsoft.AspNet.Identity;
using QuanLyNhaThuoc.DTOs;
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
        [Authorize]
        [HttpPost]        
        [Route("api/GioHangApi/AddToCart")]
        public IHttpActionResult AddToCart(CartItemDto dto)
        {
            string userId = User.Identity.GetUserId();
            
            // insert or update ChiTietGioHang
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            if (cart == null)
            {
                cart = new GioHang
                {
                    Id = userId,
                    NgayLap = DateTime.Now
                };
                _dbContext.gioHangs.Add(cart);
            }

            ChiTietGioHang cartDetail =
                _dbContext.chiTietGioHangs.FirstOrDefault(cd =>
                    cd.MaGiohang == cart.MaGioHang && cd.MaSanPham == dto.productId);
            if (cartDetail == null)
                cartDetail = new ChiTietGioHang
                {
                    MaGiohang = cart.MaGioHang,
                    MaSanPham = dto.productId,
                    SoLuong = dto.amount
                };
            else
                cartDetail.SoLuong += dto.amount;
            
            _dbContext.chiTietGioHangs.AddOrUpdate(cartDetail);
            
            _dbContext.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("api/GioHangApi/RemoveFromCart")]
        public IHttpActionResult RemoveFromCart(CartItemDto dto)
        {
            string userId = User.Identity.GetUserId();
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            if (cart == null)
            {
                return BadRequest();
            }
            var cartDetail = _dbContext.chiTietGioHangs.FirstOrDefault(c => c.MaSanPham == dto.productId && c.MaGiohang == cart.MaGioHang);
            _dbContext.chiTietGioHangs.Remove(cartDetail);
            _dbContext.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpPost]
        [Route("api/GioHangApi/UpdateCart")]
        public IHttpActionResult UpdateCart(CartItemDto dto)
        {
            string userId = User.Identity.GetUserId();
            var cart = _dbContext.gioHangs.FirstOrDefault(c => c.Id == userId);
            if (cart == null)
            {
                return BadRequest();
            }
            var cartDetail = _dbContext.chiTietGioHangs.FirstOrDefault(c => c.MaSanPham == dto.productId && c.MaGiohang == cart.MaGioHang);
            if (cartDetail == null)
                cartDetail.SoLuong = dto.amount;


            if (dto.amount == 0)
                _dbContext.chiTietGioHangs.Remove(cartDetail);
            else 
                _dbContext.chiTietGioHangs.AddOrUpdate(cartDetail);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}