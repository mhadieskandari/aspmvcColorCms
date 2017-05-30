namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeContentUserCreatorIdToString128 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "UserID_Creator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "UserID_Creator", c => c.Int());
        }
    }
}
