namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WS_CEP1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Cep", c => c.String());
            AddColumn("dbo.Cliente", "Logradouro", c => c.String());
            AddColumn("dbo.Cliente", "Bairro", c => c.String());
            AddColumn("dbo.Cliente", "Localidade", c => c.String());
            AddColumn("dbo.Cliente", "Uf", c => c.String());
            DropColumn("dbo.Cliente", "EnderecoCliente");
            DropColumn("dbo.Login", "Cep");
            DropColumn("dbo.Login", "Logradouro");
            DropColumn("dbo.Login", "Bairro");
            DropColumn("dbo.Login", "Localidade");
            DropColumn("dbo.Login", "Uf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Login", "Uf", c => c.String());
            AddColumn("dbo.Login", "Localidade", c => c.String());
            AddColumn("dbo.Login", "Bairro", c => c.String());
            AddColumn("dbo.Login", "Logradouro", c => c.String());
            AddColumn("dbo.Login", "Cep", c => c.String());
            AddColumn("dbo.Cliente", "EnderecoCliente", c => c.String(nullable: false));
            DropColumn("dbo.Cliente", "Uf");
            DropColumn("dbo.Cliente", "Localidade");
            DropColumn("dbo.Cliente", "Bairro");
            DropColumn("dbo.Cliente", "Logradouro");
            DropColumn("dbo.Cliente", "Cep");
        }
    }
}
