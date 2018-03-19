namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeDBContextv2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserReponses");
            AddPrimaryKey("dbo.UserReponses", new[] { "QuizzId", "ReponseId" });
            DropColumn("dbo.UserReponses", "UserReponseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserReponses", "UserReponseId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserReponses");
            AddPrimaryKey("dbo.UserReponses", "UserReponseId");
        }
    }
}
