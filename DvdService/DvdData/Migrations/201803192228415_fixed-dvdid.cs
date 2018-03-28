namespace DvdData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddvdid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        ReleaseYear = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DvdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
