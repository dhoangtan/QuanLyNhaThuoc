namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapNhatDiaChiGioHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GioHangs", "DiaChi", c => c.String());
            DropColumn("dbo.AspNetUsers", "DiaChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DiaChi", c => c.String());
            DropColumn("dbo.GioHangs", "DiaChi");
        }
    }
}
