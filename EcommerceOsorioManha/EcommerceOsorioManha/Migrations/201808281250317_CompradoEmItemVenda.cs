namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompradoEmItemVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVenda", "Comprado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVenda", "Comprado");
        }
    }
}
