namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderItems", "TotalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderItems", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
