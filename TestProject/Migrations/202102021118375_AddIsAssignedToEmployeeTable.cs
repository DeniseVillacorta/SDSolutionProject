namespace TestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAssignedToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsAssigned", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Buses", "PlateNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buses", "PlateNo", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "IsAssigned");
        }
    }
}
