namespace FilRouge.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeDBContext_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayNum = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DisplayNum, name: "IdxDisplayNum");
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TechnologyId = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 300),
                        Comment = c.String(maxLength: 500),
                        IsEnable = c.Boolean(nullable: false),
                        IsFreeAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId)
                .Index(t => t.TechnologyId)
                .Index(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 100),
                        Explanation = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TechnologyId = c.Int(nullable: false),
                        ContactId = c.String(maxLength: 128),
                        DifficultyId = c.Int(nullable: false),
                        QuizzState = c.Int(nullable: false),
                        UserLastName = c.String(nullable: false, maxLength: 20),
                        UserFirstName = c.String(nullable: false, maxLength: 20),
                        HasFreeQuestion = c.Boolean(nullable: false),
                        QuestionCount = c.Int(nullable: false),
                        ExternalNum = c.String(),
                        ActiveQuestionNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ContactId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyId)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId)
                .Index(t => t.TechnologyId)
                .Index(t => t.ContactId)
                .Index(t => t.DifficultyId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DifficultyRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DifficultyQuizzId = c.Int(nullable: false),
                        DifficultyQuestionId = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyQuestionId)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyQuizzId)
                .Index(t => t.DifficultyQuizzId)
                .Index(t => t.DifficultyQuestionId);
            
            CreateTable(
                "dbo.QuestionQuizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        DisplayNum = c.Int(nullable: false),
                        FreeAnswer = c.String(),
                        Comment = c.String(),
                        RefuseToAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId)
                .Index(t => new { t.QuizzId, t.DisplayNum, t.QuestionId }, name: "IdxDisplayNum")
                .Index(t => new { t.QuizzId, t.QuestionId }, unique: true, name: "IdxQuizz_Question");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserResponses", "ResponseId", "dbo.Responses");
            DropForeignKey("dbo.UserResponses", "QuestionQuizzId", "dbo.QuestionQuizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.DifficultyRates", "DifficultyQuizzId", "dbo.Difficulties");
            DropForeignKey("dbo.DifficultyRates", "DifficultyQuestionId", "dbo.Difficulties");
            DropForeignKey("dbo.Questions", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Quizzs", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Quizzs", "DifficultyId", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "ContactId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Responses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "DifficultyId", "dbo.Difficulties");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserResponses", new[] { "ResponseId" });
            DropIndex("dbo.UserResponses", new[] { "QuestionQuizzId" });
            DropIndex("dbo.QuestionQuizzs", "IdxQuizz_Question");
            DropIndex("dbo.QuestionQuizzs", "IdxDisplayNum");
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyQuestionId" });
            DropIndex("dbo.DifficultyRates", new[] { "DifficultyQuizzId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Quizzs", new[] { "DifficultyId" });
            DropIndex("dbo.Quizzs", new[] { "ContactId" });
            DropIndex("dbo.Quizzs", new[] { "TechnologyId" });
            DropIndex("dbo.Responses", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "DifficultyId" });
            DropIndex("dbo.Questions", new[] { "TechnologyId" });
            DropIndex("dbo.Difficulties", "IdxDisplayNum");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserResponses");
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.DifficultyRates");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Technologies");
            DropTable("dbo.Responses");
            DropTable("dbo.Questions");
            DropTable("dbo.Difficulties");
        }
    }
}
