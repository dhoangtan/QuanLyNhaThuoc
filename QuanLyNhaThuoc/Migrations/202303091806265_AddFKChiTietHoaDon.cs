namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKChiTietHoaDon : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ChiTietHoaDons", "MaHoaDon");
            CreateIndex("dbo.ChiTietHoaDons", "MaSanPham");
            AddForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons", "MaHoaDon", cascadeDelete: true);
            AddForeignKey("dbo.ChiTietHoaDons", "MaSanPham", "dbo.SanPhams", "MaSanPham", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
        }
    }
}
