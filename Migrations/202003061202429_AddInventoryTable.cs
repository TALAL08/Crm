namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "InventoryId");
            AddForeignKey("dbo.Products", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Products", new[] { "InventoryId" });
            DropColumn("dbo.Products", "InventoryId");
            DropTable("dbo.Inventories");
        }
    }
}
