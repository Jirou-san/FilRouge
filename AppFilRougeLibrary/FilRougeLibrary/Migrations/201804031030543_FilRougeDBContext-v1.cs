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
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 10),
                        Mail = c.String(nullable: false, maxLength: 30),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        QuizzState = c.Int(nullable: false),
                        UserLastName = c.String(nullable: false, maxLength: 20),
                        UserFirstName = c.String(nullable: false, maxLength: 20),
                        HasFreeQuestion = c.Boolean(nullable: false),
                        QuestionCount = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId)
                .Index(t => t.TechnologyId)
                .Index(t => t.ContactId)
                .Index(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyId = c.Int(nullable: false, identity: true),
                        DifficultyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 200),
                        Comment = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
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
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 100),
                        IsTrue = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        TechnoId = c.Int(nullable: false, identity: true),
                        TechnoName = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TechnoId);
            
            CreateTable(
                "dbo.TypeQuestions",
                c => new
                    {
                        TypeQuestionId = c.Int(nullable: false, identity: true),
                        NameType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TypeQuestionId);
            
            CreateTable(
                "dbo.DifficultyRates",
                c => new
                    {
                        DifficultyRateId = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DifficultyQuizzId = c.Int(nullable: false),
                        DifficultyQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DifficultyRateId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyQuestionId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyQuizzId)
                .Index(t => t.DifficultyQuizzId)
                .Index(t => t.DifficultyQuestionId);
            
            CreateTable(
                "dbo.QuestionQuizzs",
                c => new
                    {
                        QuestionQuizzId = c.Int(nullable: false, identity: true),
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Value = c.String(),
                        Comment = c.String(),
                        IsFreeAnswer = c.Boolean(nullable: false),
                        RefuseToAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionQuizzId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId)
                .Index(t => new { t.QuizzId, t.QuestionId }, unique: true, name: "IndexQuizz_Question");
            
            CreateTable(
                "dbo.UserResponses",
                c => new
                    {
                        QuestionQuizzId = c.Int(nullable: false),
                        ResponseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionQuizzId, t.ResponseId })
                .ForeignKey("dbo.QuestionQuizzs", t => t.QuestionQuizzId)
                .ForeignKey("dbo.Responses", t => t.ResponseId)
                .Index(t => t.QuestionQuizzId)
                .Index(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResponses", "ResponseId", "dbo.Responses");
            DropForeignKey("dbo.UserResponses", "QuestionQuizzId", "dbo.QuestionQuizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.DifficultyRates", "DifficultyQuizzId", "dbo.Difficulties");
            DropForeignKey("dbo.DifficultyRates", "DifficultyQuestionId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Quizzs", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.TypeQuestions");
            DropForeignKey("dbo.Questions", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Responses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "ContactId", "dbo.Contacts");
            DropIndex("dbo.UserResponses", new[] { "ResponseId" });
            DropIndex("dbo.UserResponses", new[] { "QuestionQuizzId" });
            DropIndex("dbo.QuestionQuizzs", "IndexQuizz_Question");
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyQuestionId" });
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyQuizzId" });
            DropIndex("dbo.Responses", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "DifficultyId" });
            DropIndex("dbo.Questions", new[] { "TechnologyId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "ContactId" });
            DropIndex("dbo.Quizzs", new[] { "TechnologyId" });
            DropTable("dbo.UserResponses");
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.DifficultyRates");
            DropTable("dbo.TypeQuestions");
            DropTable("dbo.Technologies");
            DropTable("dbo.Responses");
            DropTable("dbo.Questions");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Contacts");
        }
    }
}
