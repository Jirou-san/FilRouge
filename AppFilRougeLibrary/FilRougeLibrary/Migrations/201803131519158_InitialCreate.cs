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
                    })
                .PrimaryKey(t => t.UserId);
            
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
                .PrimaryKey(t => new { t.QuizzId, t.QuestionId })
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId);
            
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
                        TechnoId = c.Int(nullable: false),
                        QuizzId = c.String(),
                        ReponseId = c.String(),
                        EtatQuizz_QuizzId = c.Int(),
                        EtatQuizz_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Technologies", t => t.TechnoId, cascadeDelete: true)
                .ForeignKey("dbo.EtatQuizzs", t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId })
                .Index(t => t.TechnoId)
                .Index(t => new { t.EtatQuizz_QuizzId, t.EtatQuizz_QuestionId });
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        Timer = c.Int(nullable: false),
                        EtatQuizz = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                        TechnoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        NomUser = c.String(),
                        PrenomUser = c.String(),
                        QuestionLibre = c.Boolean(nullable: false),
                        NombreQuestion = c.Int(nullable: false),
                        Questions_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Contacts", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.TechnoId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Questions_QuestionId)
                .Index(t => t.DifficultyId)
                .Index(t => t.TechnoId)
                .Index(t => t.UserId)
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
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.UserReponses", t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId })
                .Index(t => t.QuestionId)
                .Index(t => new { t.UserReponse_QuizzId, t.UserReponse_ReponseId });
            
            CreateTable(
                "dbo.UserReponses",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        Valeur = c.String(),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.ReponseId })
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" }, "dbo.UserReponses");
            DropForeignKey("dbo.UserReponses", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.EtatQuizzs", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" }, "dbo.EtatQuizzs");
            DropForeignKey("dbo.Questions", "TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Quizzs", "Questions_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Quizzs", "TechnoId", "dbo.Technologies");
            DropForeignKey("dbo.Quizzs", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "UserId", "dbo.Contacts");
            DropIndex("dbo.UserReponses", new[] { "QuizzId" });
            DropIndex("dbo.Reponses", new[] { "UserReponse_QuizzId", "UserReponse_ReponseId" });
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.Quizzs", new[] { "Questions_QuestionId" });
            DropIndex("dbo.Quizzs", new[] { "UserId" });
            DropIndex("dbo.Quizzs", new[] { "TechnoId" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyId" });
            DropIndex("dbo.Questions", new[] { "EtatQuizz_QuizzId", "EtatQuizz_QuestionId" });
            DropIndex("dbo.Questions", new[] { "TechnoId" });
            DropIndex("dbo.EtatQuizzs", new[] { "QuizzId" });
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
