﻿namespace LeilaoNaNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lance_valor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LancesLeilao", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LancesLeilao", "Valor");
        }
    }
}
