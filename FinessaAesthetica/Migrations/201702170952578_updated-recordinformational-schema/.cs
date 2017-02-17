namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedrecordinformationalschema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Branches", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Branches", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.BranchInventories", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.BranchInventories", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.BranchInventories", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Colors", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Colors", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Colors", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suppliers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suppliers", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Consignees", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Consignees", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Consignees", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Consignees", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.MainInventories", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MainInventories", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.MainInventories", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UsersId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastModifiedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "StatusId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "UsersId");
            CreateIndex("dbo.Users", "UserId");
            CreateIndex("dbo.Users", "StatusId");
            CreateIndex("dbo.Branches", "UserId");
            CreateIndex("dbo.BranchInventories", "UserId");
            CreateIndex("dbo.Categories", "UserId");
            CreateIndex("dbo.Colors", "UserId");
            CreateIndex("dbo.Products", "UserId");
            CreateIndex("dbo.Products", "StatusId");
            CreateIndex("dbo.Suppliers", "UserId");
            CreateIndex("dbo.Consignees", "UserId");
            CreateIndex("dbo.Consignees", "StatusId");
            CreateIndex("dbo.MainInventories", "UserId");
            CreateIndex("dbo.Services", "UserId");
            AddForeignKey("dbo.Users", "UserId", "dbo.Users", "UsersId");
            AddForeignKey("dbo.Users", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Branches", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.BranchInventories", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Colors", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Consignees", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Consignees", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.MainInventories", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            AddForeignKey("dbo.Services", "UserId", "dbo.Users", "UsersId", cascadeDelete: true);
            DropColumn("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Services", "UserId", "dbo.Users");
            DropForeignKey("dbo.MainInventories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Consignees", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Consignees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Suppliers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Colors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Categories", "UserId", "dbo.Users");
            DropForeignKey("dbo.BranchInventories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Branches", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Users", "UserId", "dbo.Users");
            DropIndex("dbo.Services", new[] { "UserId" });
            DropIndex("dbo.MainInventories", new[] { "UserId" });
            DropIndex("dbo.Consignees", new[] { "StatusId" });
            DropIndex("dbo.Consignees", new[] { "UserId" });
            DropIndex("dbo.Suppliers", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Colors", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "UserId" });
            DropIndex("dbo.BranchInventories", new[] { "UserId" });
            DropIndex("dbo.Branches", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Users", new[] { "UserId" });
            DropPrimaryKey("dbo.Users");
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Users", "StatusId");
            DropColumn("dbo.Users", "LastModifiedBy");
            DropColumn("dbo.Users", "CreatedOn");
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Users", "UsersId");
            DropColumn("dbo.Services", "LastModifiedBy");
            DropColumn("dbo.Services", "CreatedOn");
            DropColumn("dbo.Services", "UserId");
            DropColumn("dbo.MainInventories", "LastModifiedBy");
            DropColumn("dbo.MainInventories", "CreatedOn");
            DropColumn("dbo.MainInventories", "UserId");
            DropColumn("dbo.Consignees", "StatusId");
            DropColumn("dbo.Consignees", "LastModifiedBy");
            DropColumn("dbo.Consignees", "CreatedOn");
            DropColumn("dbo.Consignees", "UserId");
            DropColumn("dbo.Suppliers", "LastModifiedBy");
            DropColumn("dbo.Suppliers", "CreatedOn");
            DropColumn("dbo.Suppliers", "UserId");
            DropColumn("dbo.Colors", "LastModifiedBy");
            DropColumn("dbo.Colors", "CreatedOn");
            DropColumn("dbo.Colors", "UserId");
            DropColumn("dbo.Categories", "LastModifiedBy");
            DropColumn("dbo.Categories", "CreatedOn");
            DropColumn("dbo.Categories", "UserId");
            DropColumn("dbo.Products", "StatusId");
            DropColumn("dbo.Products", "LastModifiedBy");
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Products", "UserId");
            DropColumn("dbo.BranchInventories", "LastModifiedBy");
            DropColumn("dbo.BranchInventories", "CreatedOn");
            DropColumn("dbo.BranchInventories", "UserId");
            DropColumn("dbo.Branches", "LastModifiedBy");
            DropColumn("dbo.Branches", "CreatedOn");
            DropColumn("dbo.Branches", "UserId");
        }
    }
}
