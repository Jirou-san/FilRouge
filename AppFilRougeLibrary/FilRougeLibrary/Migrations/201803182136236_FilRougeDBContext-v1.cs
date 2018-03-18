namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeDBContextv1 : DbMigration
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
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        Timer = c.Int(nullable: false),
                        NomUser = c.String(),
                        PrenomUser = c.String(),
                        QuestionLibre = c.Boolean(nullable: false),
                        NombreQuestion = c.Int(nullable: false),
                        Contact_UserId = c.Int(),
                        Technologie_TechnoId = c.Int(),
                        Difficulty_DifficultyId = c.Int(),
                        EtatQuizz_QuizzId = c.Int(),
                        EtatQuizz_QuestionId = c.Int(),
                        UserReponse_QuizzId = c.Int(),
                        UserReponse_ReponseId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Contacts", t => t.Contact_UserId)
                .ForeignKey("dbo.Technologies", t => t.Technologie_TechnoId)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_DifficultyId)
                .ForeignKey("dbo.EtatQuizzs", t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .ForeignKey("dbo.UserReponses", t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId })
                .Index(t => t.Contact_UserId)
                .Index(t => t.Technologie_TechnoId)
                .Index(t => t.Difficulty_DifficultyId)
                .Index(t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .Index(t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId });
            
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
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Commentaire = c.String(),
                        Active = c.Boolean(nullable: false),
                        QuestionType = c.Boolean(nullable: false),
                        Difficulty_DifficultyId = c.Int(),
                        Technologie_TechnoId = c.Int(),
                        EtatQuizz_QuizzId = c.Int(),
                        EtatQuizz_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.Technologie_TechnoId)
                .ForeignKey("dbo.EtatQuizzs", t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .Index(t => t.Difficulty_DifficultyId)
                .Index(t => t.Technologie_TechnoId)
                .Index(t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId });
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Question_QuestionId = c.Int(),
                        UserReponse_QuizzId = c.Int(),
                        UserReponse_ReponseId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .ForeignKey("dbo.UserReponses", t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId })
                .Index(t => t.Question_QuestionId)
                .Index(t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId });
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        TechnoId = c.Int(nullable: false, identity: true),
                        TechnoName = c.String(),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TechnoId);
            
            CreateTable(
                "dbo.EtatQuizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.QuestionId });
            
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
                "dbo.QuestionQuizzs",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Quizz_QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" }, "dbo.UserReponses");
            DropForeignKey("dbo.Quizzs", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" }, "dbo.UserReponses");
            DropForeignKey("dbo.Quizzs", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" }, "dbo.EtatQuizzs");
            DropForeignKey("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" }, "dbo.EtatQuizzs");
            DropForeignKey("dbo.Quizzs", "Difficulty_DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "Technologie_TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Questions", "Technologie_TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Reponses", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionQuizzs", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Difficulty_DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "Contact_UserId", "dbo.Contacts");
            DropIndex("dbo.QuestionQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.QuestionQuizzs", new[] { "Question_QuestionId" });
            DropIndex("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" });
            DropIndex("dbo.Reponses", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" });
            DropIndex("dbo.Questions", new[] { "Technologie_TechnoId" });
            DropIndex("dbo.Questions", new[] { "Difficulty_DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" });
            DropIndex("dbo.Quizzs", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" });
            DropIndex("dbo.Quizzs", new[] { "Difficulty_DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "Technologie_TechnoId" });
            DropIndex("dbo.Quizzs", new[] { "Contact_UserId" });
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.UserReponses");
            DropTable("dbo.EtatQuizzs");
            DropTable("dbo.Technologies");
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Contacts");
        }
    }
}
