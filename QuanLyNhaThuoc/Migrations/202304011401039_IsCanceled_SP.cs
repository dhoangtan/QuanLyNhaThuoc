namespace QuanLyNhaThuoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCanceled_SP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhams", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhams", "IsCanceled");
        }
    }
}
