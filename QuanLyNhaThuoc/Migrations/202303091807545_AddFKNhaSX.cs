namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKNhaSX : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SanPhams", "MaNhaSanXuat");
            AddForeignKey("dbo.SanPhams", "MaNhaSanXuat", "dbo.NhaSanXuats", "MaNhaSanXuat", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MaNhaSanXuat", "dbo.NhaSanXuats");
            DropIndex("dbo.SanPhams", new[] { "MaNhaSanXuat" });
        }
    }
}
