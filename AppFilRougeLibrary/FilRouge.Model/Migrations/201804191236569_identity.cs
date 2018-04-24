namespace FilRouge.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserResponses", "Question_Id", c => c.Int());
            CreateIndex("dbo.UserResponses", "Question_Id");
            AddForeignKey("dbo.UserResponses", "Question_Id", "dbo.Questions", "Id");
            DropColumn("dbo.Questions", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Comment", c => c.String(maxLength: 500));
            DropForeignKey("dbo.UserResponses", "Question_Id", "dbo.Questions");
            DropIndex("dbo.UserResponses", new[] { "Question_Id" });
            DropColumn("dbo.UserResponses", "Question_Id");
        }
    }
}
