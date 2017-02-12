namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSupplier_InitialStatus : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Key = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "StatusId", "dbo.Status");
            DropIndex("dbo.Suppliers", new[] { "StatusId" });
            DropTable("dbo.Status");
            DropTable("dbo.Suppliers");
        }
    }
}
