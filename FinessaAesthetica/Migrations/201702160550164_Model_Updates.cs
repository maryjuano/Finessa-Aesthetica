namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BranchInventories", "TotalAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "UnitPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.MainInventories", "TotalAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Services", "Amount", c => c.Single(nullable: false));
            DropColumn("dbo.BranchInventories", "UnitPrice");
            DropColumn("dbo.MainInventories", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainInventories", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.BranchInventories", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Services", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.MainInventories", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.BranchInventories", "TotalAmount", c => c.Double(nullable: false));
        }
    }
}
