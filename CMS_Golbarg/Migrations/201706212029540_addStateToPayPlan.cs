namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStateToPayPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayPlans", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayPlans", "State");
        }
    }
}
