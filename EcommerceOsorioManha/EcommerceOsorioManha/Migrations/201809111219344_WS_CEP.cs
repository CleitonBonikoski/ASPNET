namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WS_CEP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Login", "Cep", c => c.String());
            AddColumn("dbo.Login", "Logradouro", c => c.String());
            AddColumn("dbo.Login", "Bairro", c => c.String());
            AddColumn("dbo.Login", "Localidade", c => c.String());
            AddColumn("dbo.Login", "Uf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Login", "Uf");
            DropColumn("dbo.Login", "Localidade");
            DropColumn("dbo.Login", "Bairro");
            DropColumn("dbo.Login", "Logradouro");
            DropColumn("dbo.Login", "Cep");
        }
    }
}
