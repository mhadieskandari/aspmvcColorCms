namespace CMS_Golbarg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeValidationContent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "Title", c => c.String(maxLength: 100));
        }
    }
}
