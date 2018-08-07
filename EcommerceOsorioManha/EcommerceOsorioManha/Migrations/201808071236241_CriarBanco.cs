namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String());
        }
    }
}
