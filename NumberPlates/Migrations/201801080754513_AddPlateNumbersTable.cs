namespace NumberPlates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlateNumbersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlateNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LGA = c.String(),
                        Number = c.Int(nullable: false),
                        Letter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialNumbers");
            DropTable("dbo.PlateNumbers");
        }
    }
}
