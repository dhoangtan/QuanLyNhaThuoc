namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdata : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GioHangs", name: "NguoiDung_Id", newName: "Id");
            RenameColumn(table: "dbo.HoaDons", name: "NguoiDung_Id", newName: "Id");
            RenameIndex(table: "dbo.GioHangs", name: "IX_NguoiDung_Id", newName: "IX_Id");
            RenameIndex(table: "dbo.HoaDons", name: "IX_NguoiDung_Id", newName: "IX_Id");
            DropColumn("dbo.GioHangs", "MaNguoiDung");
            DropColumn("dbo.HoaDons", "MaNguoiDung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoaDons", "MaNguoiDung", c => c.String());
            AddColumn("dbo.GioHangs", "MaNguoiDung", c => c.String());
            RenameIndex(table: "dbo.HoaDons", name: "IX_Id", newName: "IX_NguoiDung_Id");
            RenameIndex(table: "dbo.GioHangs", name: "IX_Id", newName: "IX_NguoiDung_Id");
            RenameColumn(table: "dbo.HoaDons", name: "Id", newName: "NguoiDung_Id");
            RenameColumn(table: "dbo.GioHangs", name: "Id", newName: "NguoiDung_Id");
        }
    }
}
