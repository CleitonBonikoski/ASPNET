namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        produto_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.produto_ProdutoId)
                .Index(t => t.produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItemVenda", new[] { "produto_ProdutoId" });
            DropTable("dbo.ItemVenda");
        }
    }
}
