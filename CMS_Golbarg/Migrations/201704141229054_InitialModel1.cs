namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "MemberTypeView", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "MemberTypeView");
        }
    }
}
