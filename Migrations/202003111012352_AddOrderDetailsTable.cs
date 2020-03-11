namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        OrderItemId = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.OrderItemId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderItems", t => t.OrderItemId)
                .Index(t => t.OrderId)
                .Index(t => t.OrderItemId);
            
            DropColumn("dbo.Orders", "CustomerName");
            DropColumn("dbo.Orders", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.OrderDetails", "OrderItemId", "dbo.OrderItems");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderItemId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.OrderDetails");
        }
    }
}
