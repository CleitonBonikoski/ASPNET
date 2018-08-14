namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Imagem = c.String(),
                        Categoria_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaID)
                .Index(t => t.Categoria_CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaID" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Categoria");
        }
    }
}
