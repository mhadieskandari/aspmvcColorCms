namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "Date_Register", c => c.DateTime());
            AlterColumn("dbo.Contents", "Date_Publish", c => c.DateTime());
            AlterColumn("dbo.Contents", "UserID_Creator", c => c.Int());
            AlterColumn("dbo.Contents", "MemberTypeView", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "MemberTypeView", c => c.Int(nullable: false));
            AlterColumn("dbo.Contents", "UserID_Creator", c => c.Int(nullable: false));
            AlterColumn("dbo.Contents", "Date_Publish", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contents", "Date_Register", c => c.DateTime(nullable: false));
        }
    }
}
