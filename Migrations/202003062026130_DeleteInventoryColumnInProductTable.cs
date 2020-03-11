namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteInventoryColumnInProductTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Products", new[] { "InventoryId" });
            DropColumn("dbo.Inventories", "ProductId");
            DropColumn("dbo.Products", "InventoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "InventoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Inventories", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "InventoryId");
            AddForeignKey("dbo.Products", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
        }
    }
}
