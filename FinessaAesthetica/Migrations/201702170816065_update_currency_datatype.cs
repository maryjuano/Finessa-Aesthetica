namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_currency_datatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "StandardRetailPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "StandardRetailPrice", c => c.Double(nullable: false));
        }
    }
}
