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
                        EtatQuizz = c.Int(nullable: false),
                        NomUser = c.String(),
                        PrenomUser = c.String(),
                        QuestionLibre = c.Boolean(nullable: false),
                        NombreQuestion = c.Int(nullable: false),
                        Contact_UserId = c.Int(),
                        Technologies_TechnoId = c.Int(),
                        Difficulties_DifficultyId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Contacts", t => t.Contact_UserId)
                .ForeignKey("dbo.Technologies", t => t.Technologies_TechnoId)
                .ForeignKey("dbo.Difficulties", t => t.Difficulties_DifficultyId)
                .Index(t => t.Contact_UserId)
                .Index(t => t.Technologies_TechnoId)
                .Index(t => t.Difficulties_DifficultyId);
            
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
                        Difficulties_DifficultyId = c.Int(),
                        Technologies_TechnoId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Difficulties", t => t.Difficulties_DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.Technologies_TechnoId)
                .Index(t => t.Difficulties_DifficultyId)
                .Index(t => t.Technologies_TechnoId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Questions_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId)
                .Index(t => t.Questions_QuestionId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        TechnoId = c.Int(nullable: false, identity: true),
                        TechnoName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TechnoId);
            
            CreateTable(
                "dbo.UserReponses",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        UserReponseId = c.Int(nullable: false, identity: true),
                        Valeur = c.String(),
                    })
                .PrimaryKey(t => t.UserReponseId)
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
            DropForeignKey("dbo.Quizzs", "Difficulties_DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "Technologies_TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Questions", "Technologies_TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Reponses", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionsQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionsQuizzs", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Difficulties_DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "Contact_UserId", "dbo.Contacts");
            DropIndex("dbo.QuestionsQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.QuestionsQuizzs", new[] { "Questions_QuestionId" });
            DropIndex("dbo.UserReponses", new[] { "ReponseId" });
            DropIndex("dbo.UserReponses", new[] { "QuizzId" });
            DropIndex("dbo.Reponses", new[] { "Questions_QuestionId" });
            DropIndex("dbo.Questions", new[] { "Technologies_TechnoId" });
            DropIndex("dbo.Questions", new[] { "Difficulties_DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "Difficulties_DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "Technologies_TechnoId" });
            DropIndex("dbo.Quizzs", new[] { "Contact_UserId" });
            DropTable("dbo.QuestionsQuizzs");
            DropTable("dbo.UserReponses");
            DropTable("dbo.Technologies");
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Contacts");
        }
    }
}
