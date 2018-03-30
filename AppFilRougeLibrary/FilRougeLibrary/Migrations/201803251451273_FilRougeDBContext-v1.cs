namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entities.Migrations;
    
    public partial class FilRougeDBContextv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        UserId = c.Int(nullable: false, idEntities: true),
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
                        QuizzId = c.Int(nullable: false, idEntities: true),
                        Timer = c.Int(nullable: false),
                        EtatQuizz = c.Int(nullable: false),
                        NomUser = c.String(),
                        PrenomUser = c.String(),
                        QuestionLibre = c.Boolean(nullable: false),
                        NombreQuestion = c.Int(nullable: false),
                        DifficultyMasterId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.DifficultyMasters", t => t.DifficultyMasterId)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId)
                .Index(t => t.DifficultyMasterId)
                .Index(t => t.TechnologyId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.DifficultyMasters",
                c => new
                    {
                        DiffMasterId = c.Int(nullable: false, idEntities: true),
                        DiffMasterName = c.String(),
                    })
                .PrimaryKey(t => t.DiffMasterId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, idEntities: true),
                        Content = c.String(),
                        Commentaire = c.String(),
                        Active = c.Boolean(nullable: false),
                        QuestionTypeId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId)
                .ForeignKey("dbo.TypeQuestions", t => t.QuestionTypeId)
                .Index(t => t.QuestionTypeId)
                .Index(t => t.TechnologyId)
                .Index(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyId = c.Int(nullable: false, idEntities: true),
                        DifficultyName = c.String(),
                    })
                .PrimaryKey(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, idEntities: true),
                        Content = c.String(),
                        TrueReponse = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        TechnoId = c.Int(nullable: false, idEntities: true),
                        TechnoName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TechnoId);
            
            CreateTable(
                "dbo.TypeQuestions",
                c => new
                    {
                        TypeQuestionId = c.Int(nullable: false, idEntities: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.TypeQuestionId);
            
            CreateTable(
                "dbo.DifficultyRates",
                c => new
                    {
                        DifficultyMasterId = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.DifficultyMasterId, t.DifficultyId })
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId)
                .ForeignKey("dbo.DifficultyMasters", t => t.DifficultyMasterId)
                .Index(t => t.DifficultyMasterId)
                .Index(t => t.DifficultyId);
            
            CreateTable(
                "dbo.UserReponses",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        Valeur = c.String(),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.ReponseId })
                .ForeignKey("dbo.Quizzs", t => t.QuizzId)
                .ForeignKey("dbo.Reponses", t => t.ReponseId)
                .Index(t => t.QuizzId)
                .Index(t => t.ReponseId);
            
            CreateTable(
                "dbo.QuestionsQuizzs",
                c => new
                    {
                        Questions_QuestionId = c.Int(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Questions_QuestionId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Questions_QuestionId)
                .Index(t => t.Quizz_QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReponses", "ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.UserReponses", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.DifficultyRates", "DifficultyMasterId", "dbo.DifficultyMasters");
            DropForeignKey("dbo.DifficultyRates", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.TypeQuestions");
            DropForeignKey("dbo.Questions", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionsQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionsQuizzs", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "DifficultyMasterId", "dbo.DifficultyMasters");
            DropForeignKey("dbo.Quizzs", "ContactId", "dbo.Contacts");
            DropIndex("dbo.QuestionsQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.QuestionsQuizzs", new[] { "Questions_QuestionId" });
            DropIndex("dbo.UserReponses", new[] { "ReponseId" });
            DropIndex("dbo.UserReponses", new[] { "QuizzId" });
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyId" });
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyMasterId" });
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "DifficultyId" });
            DropIndex("dbo.Questions", new[] { "TechnologyId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.Quizzs", new[] { "ContactId" });
            DropIndex("dbo.Quizzs", new[] { "TechnologyId" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyMasterId" });
            DropTable("dbo.QuestionsQuizzs");
            DropTable("dbo.UserReponses");
            DropTable("dbo.DifficultyRates");
            DropTable("dbo.TypeQuestions");
            DropTable("dbo.Technologies");
            DropTable("dbo.Reponses");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Questions");
            DropTable("dbo.DifficultyMasters");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Contacts");
        }
    }
}
