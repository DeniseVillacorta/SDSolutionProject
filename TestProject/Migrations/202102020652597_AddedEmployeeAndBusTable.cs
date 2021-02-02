namespace TestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeAndBusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusNo = c.Int(nullable: false),
                        PlateNo = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmployeeNo = c.Int(nullable: false),
                        ContactNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Buses", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Buses");
        }
    }
}
