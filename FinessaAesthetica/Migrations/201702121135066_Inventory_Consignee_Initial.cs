namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventory_Consignee_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BranchInventories",
                c => new
                    {
                        BranchInventoryId = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchInventoryId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Consignees",
                c => new
                    {
                        ConsigneeId = c.Int(nullable: false, identity: true),
                        ConsigneeCode = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsigneeId);
            
            CreateTable(
                "dbo.MainInventories",
                c => new
                    {
                        MainInventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MainInventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId);
            
            AddColumn("dbo.Products", "ProductCode", c => c.String());
            DropColumn("dbo.Products", "Key");
            DropColumn("dbo.Products", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Code", c => c.String());
            AddColumn("dbo.Products", "Key", c => c.String());
            DropForeignKey("dbo.MainInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MainInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BranchInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BranchInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BranchInventories", "BranchId", "dbo.Branches");
            DropIndex("dbo.MainInventories", new[] { "StatusId" });
            DropIndex("dbo.MainInventories", new[] { "ProductId" });
            DropIndex("dbo.BranchInventories", new[] { "StatusId" });
            DropIndex("dbo.BranchInventories", new[] { "ProductId" });
            DropIndex("dbo.BranchInventories", new[] { "BranchId" });
            DropColumn("dbo.Products", "ProductCode");
            DropTable("dbo.MainInventories");
            DropTable("dbo.Consignees");
            DropTable("dbo.BranchInventories");
        }
    }
}
