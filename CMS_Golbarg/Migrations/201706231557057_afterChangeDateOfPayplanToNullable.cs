namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterChangeDateOfPayplanToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PayPlans", "StartDate", c => c.DateTime());
            AlterColumn("dbo.PayPlans", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PayPlans", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PayPlans", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
