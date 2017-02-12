namespace FinessaAesthetica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Branch_Service_InitialCreate : DbMigration
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
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        Amount = c.Double(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            DropColumn("dbo.Status", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "Key", c => c.Int(nullable: false));
            DropForeignKey("dbo.Services", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Branches", "StatusId", "dbo.Status");
            DropIndex("dbo.Services", new[] { "StatusId" });
            DropIndex("dbo.Branches", new[] { "StatusId" });
            DropTable("dbo.Services");
            DropTable("dbo.Branches");
        }
    }
}
