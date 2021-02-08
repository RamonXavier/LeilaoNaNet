namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produtos_remove_imagem_addTable_imagemProduto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produtos", "imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "imagem", c => c.String());
        }
    }
}
