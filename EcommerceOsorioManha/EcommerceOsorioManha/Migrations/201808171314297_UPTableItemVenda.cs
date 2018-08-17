namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPTableItemVenda : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemVenda", new[] { "produto_ProdutoId" });
            CreateIndex("dbo.ItemVenda", "Produto_ProdutoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemVenda", new[] { "Produto_ProdutoId" });
            CreateIndex("dbo.ItemVenda", "produto_ProdutoId");
        }
    }
}
