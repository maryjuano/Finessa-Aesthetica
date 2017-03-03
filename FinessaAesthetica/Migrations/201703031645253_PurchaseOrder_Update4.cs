namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrder_Update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "LastModifiedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.PurchaseOrders", new[] { "LastModifiedBy_UserId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "StatusId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropTable("dbo.PurchaseOrderItems");
            DropTable("dbo.PurchaseOrders");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        PurchaseOrderItemsId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderItemsId);
            
            CreateIndex("dbo.PurchaseOrders", "SupplierId");
            CreateIndex("dbo.PurchaseOrders", "StatusId");
            CreateIndex("dbo.PurchaseOrderItems", "PurchaseOrderId");
            CreateIndex("dbo.PurchaseOrders", "LastModifiedBy_UserId");
            CreateIndex("dbo.PurchaseOrders", "CreatedBy_UserId");
            CreateIndex("dbo.PurchaseOrderItems", "ProductId");
            AddForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseOrders", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders", "PurchaseOrderId", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseOrders", "LastModifiedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.PurchaseOrders", "CreatedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
