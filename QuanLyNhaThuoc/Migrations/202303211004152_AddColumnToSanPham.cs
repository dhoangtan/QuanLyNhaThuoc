namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToSanPham : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhams", "LuotMua", c => c.Int(nullable: false));
            AddColumn("dbo.SanPhams", "LuotXem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhams", "LuotXem");
            DropColumn("dbo.SanPhams", "LuotMua");
        }
    }
}
