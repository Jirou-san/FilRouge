namespace FilRouge.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeV1 : DbMigration
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
                        IsFreeAnswer = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
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
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
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
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
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
