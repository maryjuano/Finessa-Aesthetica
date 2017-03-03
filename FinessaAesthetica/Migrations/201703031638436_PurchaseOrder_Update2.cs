namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrder_Update2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        PurchaseOrderItemsId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderItemsId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderId = c.Int(nullable: false, identity: true),
                        Remarks = c.String(),
                        PurchaseOrderStatus = c.String(),
                        SupplierId = c.Int(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        TotalProductQuantity = c.Int(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                        LastModifiedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Users", t => t.LastModifiedBy_UserId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.LastModifiedBy_UserId)
                .Index(t => t.StatusId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "StatusId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductId" });
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderItems");
        }
    }
}
