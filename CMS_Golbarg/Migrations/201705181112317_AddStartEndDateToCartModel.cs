namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartEndDateToCartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "StartDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "StartDay");
            DropColumn("dbo.Carts", "EndDate");
        }
    }
}
