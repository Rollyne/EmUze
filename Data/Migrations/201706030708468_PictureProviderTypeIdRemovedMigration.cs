namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureProviderTypeIdRemovedMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture_ProviderTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture_ProviderTypeId", c => c.Int(nullable: false));
        }
    }
}
