namespace Crm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeAccountDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        AccountNo = c.String(),
                        IFSC = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qalificaiton = c.String(),
                        WorkExperience = c.Int(nullable: false),
                        WorkFeild = c.String(),
                        IdCardNo = c.String(),
                        GuardianName = c.String(),
                        GuardianRealation = c.String(),
                        GuardianContactNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        EmployeeDetailsId = c.Int(nullable: false),
                        EmployeeAccountDetailsId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeAccountDetails", t => t.EmployeeAccountDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeDetailsId, cascadeDelete: true)
                .Index(t => t.EmployeeDetailsId)
                .Index(t => t.EmployeeAccountDetailsId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeDetailsId", "dbo.EmployeeDetails");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "EmployeeAccountDetailsId", "dbo.EmployeeAccountDetails");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "EmployeeAccountDetailsId" });
            DropIndex("dbo.Employees", new[] { "EmployeeDetailsId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.EmployeeAccountDetails");
            DropTable("dbo.Designations");
        }
    }
}
