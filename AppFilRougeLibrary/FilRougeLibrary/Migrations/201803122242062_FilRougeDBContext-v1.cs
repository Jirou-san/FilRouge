namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeDBContextv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyId = c.Int(nullable: false, identity: true),
                        DifficultyName = c.String(),
                        Questions_QuestionId = c.Int(),
                        Quizz_QuizzId = c.Int(),
                    })
                .PrimaryKey(t => t.DifficultyId)
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId)
                .Index(t => t.Questions_QuestionId)
                .Index(t => t.Quizz_QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Difficulties", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.Difficulties", "Questions_QuestionId", "dbo.Questions");
            DropIndex("dbo.Difficulties", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.Difficulties", new[] { "Questions_QuestionId" });
            DropTable("dbo.Difficulties");
        }
    }
}
