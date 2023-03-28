namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2ColumNgay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhams", "NgayNhap", c => c.DateTime(nullable: false));
            AddColumn("dbo.SanPhams", "HSD", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhams", "HSD");
            DropColumn("dbo.SanPhams", "NgayNhap");
        }
    }
}
