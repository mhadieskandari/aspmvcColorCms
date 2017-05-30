namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateTmeTonullableIncart : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "RegisterDate", c => c.DateTime());
            AlterColumn("dbo.Carts", "ConfirmDate", c => c.DateTime());
            AlterColumn("dbo.Carts", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Carts", "StartDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "StartDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Carts", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Carts", "ConfirmDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Carts", "RegisterDate", c => c.DateTime(nullable: false));
        }
    }
}
