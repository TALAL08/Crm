namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersAndOrderItemsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        OrderItemId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItems", t => t.OrderItemId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.StoreId)
                .Index(t => t.OrderItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Orders", "OrderItemId", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "OrderItemId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
