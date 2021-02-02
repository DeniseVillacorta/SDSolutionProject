namespace TestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertToStringContactNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ContactNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ContactNo", c => c.String());
        }
    }
}
