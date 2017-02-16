namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventory_Consignee_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        Manager = c.String(),
                        Telephone = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.BranchInventories",
                c => new
                    {
                        BranchInventoryId = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchInventoryId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Desciption = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        UnitMeasurement = c.Double(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        StandardRetailPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ColorId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ColorId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        TelephoneNumber = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        ContactPerson = c.String(),
                        TIN = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
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
                        TotalAmount = c.Single(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MainInventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        Amount = c.Single(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 24),
                        EmployeeId = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MainInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MainInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BranchInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BranchInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Colors", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BranchInventories", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "StatusId", "dbo.Status");
            DropIndex("dbo.Services", new[] { "StatusId" });
            DropIndex("dbo.MainInventories", new[] { "StatusId" });
            DropIndex("dbo.MainInventories", new[] { "ProductId" });
            DropIndex("dbo.BranchInventories", new[] { "StatusId" });
            DropIndex("dbo.BranchInventories", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Suppliers", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Colors", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "StatusId" });
            DropIndex("dbo.BranchInventories", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "StatusId" });
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.MainInventories");
            DropTable("dbo.Consignees");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.BranchInventories");
            DropTable("dbo.Status");
            DropTable("dbo.Branches");
        }
    }
}
