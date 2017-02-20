namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        Manager = c.String(),
                        Telephone = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 24),
                        EmployeeId = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        FullName = c.String(),
                        BranchId = c.Int(nullable: false),
                        Branch_BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchId)
                .Index(t => t.Branch_BranchId);
            
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
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BranchInventoryId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.BranchId)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
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
                        StandardRetailPrice = c.Single(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.ColorId)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ColorId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
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
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
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
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsigneeId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.MainInventories",
                c => new
                    {
                        MainInventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        MinimumThreshold = c.Int(nullable: false),
                        MaximumThreshold = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MainInventoryId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
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
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: false)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Services", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Services", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.MainInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.MainInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MainInventories", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.MainInventories", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Consignees", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Consignees", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Consignees", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.BranchInventories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BranchInventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Suppliers", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Suppliers", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Colors", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Colors", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Colors", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Categories", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Categories", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.BranchInventories", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.BranchInventories", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.BranchInventories", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Branches", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Branches", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Branch_BranchId", "dbo.Branches");
            DropIndex("dbo.Services", new[] { "StatusId" });
            DropIndex("dbo.Services", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Services", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.MainInventories", new[] { "StatusId" });
            DropIndex("dbo.MainInventories", new[] { "ProductId" });
            DropIndex("dbo.MainInventories", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.MainInventories", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Consignees", new[] { "StatusId" });
            DropIndex("dbo.Consignees", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Consignees", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.BranchInventories", new[] { "StatusId" });
            DropIndex("dbo.BranchInventories", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Suppliers", new[] { "StatusId" });
            DropIndex("dbo.Suppliers", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Suppliers", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Products", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Products", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Colors", new[] { "StatusId" });
            DropIndex("dbo.Colors", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Colors", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "StatusId" });
            DropIndex("dbo.Categories", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Categories", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.BranchInventories", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.BranchInventories", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.BranchInventories", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "StatusId" });
            DropIndex("dbo.Branches", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.Branches", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Users", new[] { "Branch_BranchId" });
            DropTable("dbo.Services");
            DropTable("dbo.MainInventories");
            DropTable("dbo.Consignees");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.BranchInventories");
            DropTable("dbo.Status");
            DropTable("dbo.Users");
            DropTable("dbo.Branches");
        }
    }
}
