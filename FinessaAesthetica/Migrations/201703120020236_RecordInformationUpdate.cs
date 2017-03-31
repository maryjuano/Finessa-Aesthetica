namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordInformationUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Branches", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.BranchInventories", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.BranchInventories", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Products", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Categories", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Colors", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Colors", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Consignees", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Consignees", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.MainInventories", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.MainInventories", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrders", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrders", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Suppliers", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Suppliers", "LastModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Services", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Services", "LastModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Services", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MainInventories", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MainInventories", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Consignees", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Consignees", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Colors", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Colors", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BranchInventories", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BranchInventories", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Branches", "LastModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Branches", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
