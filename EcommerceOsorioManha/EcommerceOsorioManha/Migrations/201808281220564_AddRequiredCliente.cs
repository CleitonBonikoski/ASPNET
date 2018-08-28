namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredCliente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "NomeCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "EnderecoCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "TelefoneCliente", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "TelefoneCliente", c => c.String());
            AlterColumn("dbo.Cliente", "EnderecoCliente", c => c.String());
            AlterColumn("dbo.Cliente", "NomeCliente", c => c.String());
        }
    }
}
