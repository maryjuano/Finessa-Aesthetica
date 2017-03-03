namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BranchInventory_Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MainInventories", "BranchId", "dbo.Branches");
            DropIndex("dbo.MainInventories", new[] { "BranchId" });
            DropColumn("dbo.MainInventories", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainInventories", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.MainInventories", "BranchId");
            AddForeignKey("dbo.MainInventories", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
    }
}
