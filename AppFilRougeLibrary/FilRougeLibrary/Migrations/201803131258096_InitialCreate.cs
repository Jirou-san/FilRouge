namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        Quizz_QuizzId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId)
                .Index(t => t.Quizz_QuizzId);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyId = c.Int(nullable: false, identity: true),
                        DifficultyName = c.String(),
                        TauxJunior = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TauxConfirmed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TauxExpert = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DifficultyId);
            
            CreateTable(
                "dbo.EtatQuizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.QuestionId });
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Commentaire = c.String(),
                        Active = c.Boolean(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        Difficulty = c.String(),
                        TechnoId = c.String(),
                        QuizzId = c.String(),
                        ReponseId = c.String(),
                        EtatQuizz_QuizzId = c.Int(),
                        EtatQuizz_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.EtatQuizzs", t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .Index(t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId });
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        Timer = c.DateTime(nullable: false),
                        EtatQuizz = c.Int(nullable: false),
                        Difficulty = c.String(),
                        TechnoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        NomUser = c.String(),
                        PrenomUser = c.String(),
                        QuestionLibre = c.Boolean(nullable: false),
                        NombreQuestion = c.Int(nullable: false),
                        Questions_QuestionId = c.Int(),
                        EtatQuizz_QuizzId = c.Int(),
                        EtatQuizz_QuestionId = c.Int(),
                        UserReponse_QuizzId = c.Int(),
                        UserReponse_ReponseId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId)
                .ForeignKey("dbo.EtatQuizzs", t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .ForeignKey("dbo.UserReponses", t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId })
                .Index(t => t.Questions_QuestionId)
                .Index(t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .Index(t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId });
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        TechnoId = c.Int(nullable: false, identity: true),
                        TechnoName = c.String(),
                        Active = c.Boolean(nullable: false),
                        Quizz_QuizzId = c.Int(),
                        Questions_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.TechnoId)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId)
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId)
                .Index(t => t.Quizz_QuizzId)
                .Index(t => t.Questions_QuestionId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        QuestionId = c.Int(nullable: false),
                        UserReponse_QuizzId = c.Int(),
                        UserReponse_ReponseId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.UserReponses", t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId })
                .Index(t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId });
            
            CreateTable(
                "dbo.UserReponses",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        Valeur = c.String(),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.ReponseId });
            
            CreateTable(
                "dbo.QuestionsReponses",
                c => new
                    {
                        Questions_QuestionId = c.Int(nullable: false),
                        Reponse_ReponseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Questions_QuestionId, t.Reponse_ReponseId })
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Reponses", t => t.Reponse_ReponseId, cascadeDelete: true)
                .Index(t => t.Questions_QuestionId)
                .Index(t => t.Reponse_ReponseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" }, "dbo.UserReponses");
            DropForeignKey("dbo.Quizzs", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" }, "dbo.UserReponses");
            DropForeignKey("dbo.Quizzs", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" }, "dbo.EtatQuizzs");
            DropForeignKey("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" }, "dbo.EtatQuizzs");
            DropForeignKey("dbo.Technologies", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionsReponses", "Reponse_ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuestionsReponses", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Quizzs", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Technologies", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.Contacts", "Quizz_QuizzId", "dbo.Quizzs");
            DropIndex("dbo.QuestionsReponses", new[] { "Reponse_ReponseId" });
            DropIndex("dbo.QuestionsReponses", new[] { "Questions_QuestionId" });
            DropIndex("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" });
            DropIndex("dbo.Technologies", new[] { "Questions_QuestionId" });
            DropIndex("dbo.Technologies", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.Quizzs", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" });
            DropIndex("dbo.Quizzs", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" });
            DropIndex("dbo.Quizzs", new[] { "Questions_QuestionId" });
            DropIndex("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" });
            DropIndex("dbo.Contacts", new[] { "Quizz_QuizzId" });
            DropTable("dbo.QuestionsReponses");
            DropTable("dbo.UserReponses");
            DropTable("dbo.Reponses");
            DropTable("dbo.Technologies");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Questions");
            DropTable("dbo.EtatQuizzs");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Contacts");
        }
    }
}
