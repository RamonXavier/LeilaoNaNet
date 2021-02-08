namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_imagemProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagemProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.IdProduto)
                .Index(t => t.IdProduto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagemProduto", "IdProduto", "dbo.Produtos");
            DropIndex("dbo.ImagemProduto", new[] { "IdProduto" });
            DropTable("dbo.ImagemProduto");
        }
    }
}
