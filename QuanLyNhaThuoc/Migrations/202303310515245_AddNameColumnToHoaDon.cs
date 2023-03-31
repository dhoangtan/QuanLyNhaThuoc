namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToHoaDon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "TenNguoiDat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoaDons", "TenNguoiDat");
        }
    }
}
