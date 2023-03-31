namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGioHangAndHoaDonFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "SoDienThoai", c => c.String());
            AddColumn("dbo.HoaDons", "DiaChi", c => c.String());
            DropColumn("dbo.GioHangs", "SoDienThoai");
            DropColumn("dbo.GioHangs", "DiaChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GioHangs", "DiaChi", c => c.String());
            AddColumn("dbo.GioHangs", "SoDienThoai", c => c.String());
            DropColumn("dbo.HoaDons", "DiaChi");
            DropColumn("dbo.HoaDons", "SoDienThoai");
        }
    }
}
