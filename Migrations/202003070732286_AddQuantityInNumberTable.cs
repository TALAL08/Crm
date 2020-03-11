namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityInNumberTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Numbers", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Numbers", "Quantity");
        }
    }
}
