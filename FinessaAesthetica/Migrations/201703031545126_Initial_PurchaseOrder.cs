namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_PurchaseOrder : DbMigration
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
                        TotalNumberOfProducts = c.Int(nullable: false),
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
            
            AddColumn("dbo.Products", "PurchaseOrder_PurchaseOrderId", c => c.Int());
            CreateIndex("dbo.Products", "PurchaseOrder_PurchaseOrderId");
            AddForeignKey("dbo.Products", "PurchaseOrder_PurchaseOrderId", "dbo.PurchaseOrders", "PurchaseOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "PurchaseOrder_PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "PurchaseOrder_PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductId" });
            DropColumn("dbo.Products", "PurchaseOrder_PurchaseOrderId");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderItems");
        }
    }
}
