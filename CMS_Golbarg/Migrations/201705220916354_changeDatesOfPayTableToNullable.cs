namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatesOfPayTableToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pays", "PayDate", c => c.DateTime());
            AlterColumn("dbo.Pays", "ConfirmDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pays", "ConfirmDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pays", "PayDate", c => c.DateTime(nullable: false));
        }
    }
}
