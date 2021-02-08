namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produtos_imagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "imagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "imagem");
        }
    }
}
