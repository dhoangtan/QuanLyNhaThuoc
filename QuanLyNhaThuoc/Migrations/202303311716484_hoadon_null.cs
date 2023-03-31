namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoadon_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDons", "TenNguoiDat", c => c.String());
            AlterColumn("dbo.HoaDons", "SoDienThoai", c => c.String());
            AlterColumn("dbo.HoaDons", "DiaChi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoaDons", "DiaChi", c => c.String(nullable: false));
            AlterColumn("dbo.HoaDons", "SoDienThoai", c => c.String(nullable: false));
            AlterColumn("dbo.HoaDons", "TenNguoiDat", c => c.String(nullable: false));
        }
    }
}
