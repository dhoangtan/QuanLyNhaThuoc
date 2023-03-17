namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapNhatDiaChi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DiaChi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DiaChi");
        }
    }
}
