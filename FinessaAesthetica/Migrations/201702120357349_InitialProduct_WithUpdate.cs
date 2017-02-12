namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialProduct_WithUpdate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Code = c.String(),
                        Desciption = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        UnitMeasurement = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        StandardRetailPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: false)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.ColorId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Colors", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Categories", "StatusId", "dbo.Status");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "ColorId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Colors", new[] { "StatusId" });
            DropIndex("dbo.Categories", new[] { "StatusId" });
            DropTable("dbo.Products");
            DropTable("dbo.Colors");
            DropTable("dbo.Categories");
        }
    }
}
