namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        InventoryName = c.String(),
                    })
                .PrimaryKey(t => new { t.InventoryId, t.ProductId })
                .ForeignKey("dbo.Inventories", t => t.InventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryProducts", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.InventoryProducts", new[] { "ProductId" });
            DropIndex("dbo.InventoryProducts", new[] { "InventoryId" });
            DropTable("dbo.InventoryProducts");
        }
    }
}
