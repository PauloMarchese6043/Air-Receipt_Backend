namespace WebServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DEVICE_USES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DEVICE_ID = c.Int(nullable: false),
                        RECEIPT_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DEVICES", t => t.DEVICE_ID, cascadeDelete: true)
                .ForeignKey("dbo.RECEIPTS", t => t.RECEIPT_ID, cascadeDelete: true)
                .Index(t => t.DEVICE_ID)
                .Index(t => t.RECEIPT_ID);
            
            CreateTable(
                "dbo.DEVICES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IS_ENABLED = c.Boolean(nullable: false),
                        MAC_ADDRESS = c.String(nullable: false),
                        STORE_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.STORES", t => t.STORE_ID, cascadeDelete: true)
                .Index(t => t.STORE_ID);
            
            CreateTable(
                "dbo.STORES",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false),
                        ADDRESS = c.String(nullable: false),
                        LOGO = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RECEIPTS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DATE = c.DateTime(nullable: false),
                        FILE = c.String(nullable: false),
                        VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TITLE = c.String(),
                        STORE_ID = c.Int(nullable: false),
                        USER_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.STORES", t => t.STORE_ID)
                .ForeignKey("dbo.USERS", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.STORE_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false),
                        EMAIL = c.String(nullable: false),
                        LAST_UPDATE = c.DateTime(nullable: false),
                        PICTURE_URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DEVICE_USES", "RECEIPT_ID", "dbo.RECEIPTS");
            DropForeignKey("dbo.RECEIPTS", "USER_ID", "dbo.USERS");
            DropForeignKey("dbo.RECEIPTS", "STORE_ID", "dbo.STORES");
            DropForeignKey("dbo.DEVICE_USES", "DEVICE_ID", "dbo.DEVICES");
            DropForeignKey("dbo.DEVICES", "STORE_ID", "dbo.STORES");
            DropIndex("dbo.RECEIPTS", new[] { "USER_ID" });
            DropIndex("dbo.RECEIPTS", new[] { "STORE_ID" });
            DropIndex("dbo.DEVICES", new[] { "STORE_ID" });
            DropIndex("dbo.DEVICE_USES", new[] { "RECEIPT_ID" });
            DropIndex("dbo.DEVICE_USES", new[] { "DEVICE_ID" });
            DropTable("dbo.USERS");
            DropTable("dbo.RECEIPTS");
            DropTable("dbo.STORES");
            DropTable("dbo.DEVICES");
            DropTable("dbo.DEVICE_USES");
        }
    }
}
