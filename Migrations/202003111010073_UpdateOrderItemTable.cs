namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderItemTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderItemId", "dbo.OrderItems");
            DropIndex("dbo.Orders", new[] { "OrderItemId" });
            DropColumn("dbo.OrderItems", "Quantity");
            DropColumn("dbo.OrderItems", "TotalPrice");
            DropColumn("dbo.Orders", "OrderItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderItemId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "TotalPrice", c => c.Single(nullable: false));
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrderItemId");
            AddForeignKey("dbo.Orders", "OrderItemId", "dbo.OrderItems", "Id", cascadeDelete: true);
        }
    }
}
