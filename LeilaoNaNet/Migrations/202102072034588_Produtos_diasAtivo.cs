namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produtos_diasAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "dias_ativo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "dias_ativo");
        }
    }
}
