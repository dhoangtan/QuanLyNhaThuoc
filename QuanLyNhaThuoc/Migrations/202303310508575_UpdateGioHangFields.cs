namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGioHangFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GioHangs", "SoDienThoai", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GioHangs", "SoDienThoai");
        }
    }
}
