namespace TestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueDataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Buses", "BusNo", unique: true, name: "BusNo");
            CreateIndex("dbo.Employees", "EmployeeNo", unique: true, name: "EmployeeNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", "EmployeeNumber");
            DropIndex("dbo.Buses", "BusNo");
        }
    }
}
