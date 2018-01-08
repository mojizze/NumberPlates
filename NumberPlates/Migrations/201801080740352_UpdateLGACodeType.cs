namespace NumberPlates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLGACodeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocalGovernments", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocalGovernments", "Code", c => c.Int(nullable: false));
        }
    }
}
