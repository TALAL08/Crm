namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIlistOfIntInNumberTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Numbers", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Numbers", "Quantity", c => c.Int(nullable: false));
        }
    }
}
