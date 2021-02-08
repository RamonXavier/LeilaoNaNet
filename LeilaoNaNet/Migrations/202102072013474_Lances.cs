namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lances : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LancesLeilao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(),
                        IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.IdProduto)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdProduto)
                .Index(t => t.IdUsuario);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LancesLeilao", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.LancesLeilao", "IdProduto", "dbo.Produtos");
            DropIndex("dbo.LancesLeilao", new[] { "IdUsuario" });
            DropIndex("dbo.LancesLeilao", new[] { "IdProduto" });
            DropTable("dbo.LancesLeilao");
        }
    }
}
