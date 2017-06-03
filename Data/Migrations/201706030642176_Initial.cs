namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "ProviderTypeId", "dbo.PictureProviderTypes");
            DropForeignKey("dbo.AspNetUsers", "ProfilePicture_Id", "dbo.Pictures");
            DropIndex("dbo.Pictures", new[] { "ProviderTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfilePicture_Id" });
            AddColumn("dbo.AspNetUsers", "ProfilePicture_FilePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture_FileName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture_FileFormat", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture_ProviderTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ProfilePicture_Id");
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        FileName = c.String(),
                        FileFormat = c.String(),
                        ProviderTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "ProfilePicture_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "ProfilePicture_ProviderTypeId");
            DropColumn("dbo.AspNetUsers", "ProfilePicture_FileFormat");
            DropColumn("dbo.AspNetUsers", "ProfilePicture_FileName");
            DropColumn("dbo.AspNetUsers", "ProfilePicture_FilePath");
            CreateIndex("dbo.AspNetUsers", "ProfilePicture_Id");
            CreateIndex("dbo.Pictures", "ProviderTypeId");
            AddForeignKey("dbo.AspNetUsers", "ProfilePicture_Id", "dbo.Pictures", "Id");
            AddForeignKey("dbo.Pictures", "ProviderTypeId", "dbo.PictureProviderTypes", "Id", cascadeDelete: true);
        }
    }
}
