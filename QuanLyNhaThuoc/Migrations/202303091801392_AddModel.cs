namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietGioHangs",
                c => new
                    {
                        MaGiohang = c.Int(nullable: false),
                        MaSanPham = c.String(nullable: false, maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaGiohang, t.MaSanPham })
                .ForeignKey("dbo.GioHangs", t => t.MaGiohang, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.MaSanPham, cascadeDelete: true)
                .Index(t => t.MaGiohang)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaGioHang = c.Int(nullable: false, identity: true),
                        MaNguoiDung = c.String(),
                        NgayLap = c.DateTime(nullable: false),
                        NguoiDung_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaGioHang)
                .ForeignKey("dbo.AspNetUsers", t => t.NguoiDung_Id)
                .Index(t => t.NguoiDung_Id);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSanPham = c.String(nullable: false, maxLength: 128),
                        TenSanPham = c.String(nullable: false),
                        MaLoai = c.String(nullable: false, maxLength: 128),
                        MaNhaSanXuat = c.Int(nullable: false),
                        ThanhPhanChinh = c.String(),
                        DoTuoi = c.String(),
                        CongDung = c.String(nullable: false),
                        DonViTinh = c.String(),
                        SoLuong = c.Int(nullable: false),
                        MoTa = c.String(),
                        GiaBan = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPhams", t => t.MaLoai, cascadeDelete: true)
                .Index(t => t.MaLoai);
            
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        MaLoai = c.String(nullable: false, maxLength: 128),
                        TenLoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false),
                        MaSanPham = c.String(nullable: false, maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaHoaDon, t.MaSanPham });
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        MaNguoiDung = c.String(),
                        NgayXuat = c.DateTime(nullable: false),
                        NguoiDung_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.AspNetUsers", t => t.NguoiDung_Id)
                .Index(t => t.NguoiDung_Id);
            
            CreateTable(
                "dbo.NhaSanXuats",
                c => new
                    {
                        MaNhaSanXuat = c.Int(nullable: false, identity: true),
                        TenNhaSanXuat = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhaSanXuat);
            
            AddColumn("dbo.AspNetUsers", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "NguoiDung_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChiTietGioHangs", "MaSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "MaLoai", "dbo.LoaiSanPhams");
            DropForeignKey("dbo.ChiTietGioHangs", "MaGiohang", "dbo.GioHangs");
            DropForeignKey("dbo.GioHangs", "NguoiDung_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HoaDons", new[] { "NguoiDung_Id" });
            DropIndex("dbo.SanPhams", new[] { "MaLoai" });
            DropIndex("dbo.GioHangs", new[] { "NguoiDung_Id" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "MaGiohang" });
            DropColumn("dbo.AspNetUsers", "Role");
            DropTable("dbo.NhaSanXuats");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
            DropTable("dbo.LoaiSanPhams");
            DropTable("dbo.SanPhams");
            DropTable("dbo.GioHangs");
            DropTable("dbo.ChiTietGioHangs");
        }
    }
}
