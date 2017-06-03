namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureProviderTypeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture_ProviderType", c => c.Int(nullable: false));
            DropTable("dbo.PictureProviderTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PictureProviderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "ProfilePicture_ProviderType");
        }
    }
}
