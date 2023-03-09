using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<ChiTietGioHang> chiTietGioHangs { get; set; }
        public DbSet<ChiTietHoaDon> chiTietHoaDons { get; set; }
        public DbSet<LoaiSanPham> loaiSanPhams { get; set; }
        public DbSet<NhaSanXuat> nhaSanXuats { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}