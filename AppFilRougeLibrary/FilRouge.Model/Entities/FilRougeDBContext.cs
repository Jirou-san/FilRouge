// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilRougeDBContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FilRougeDBContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilRouge.Model.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    //Mettre le contenue de la méthode seed dans le fichier configuration du dossier migrations
    /*public class FilRougeDbContextInit : DropCreateDatabaseIfModelChanges<FilRougeDBContext>
    {
        protected override void Seed(FilRougeDBContext context)
        {   //Data seed - Ajout des données à la création de la base

            #region Difficulty
            
            var difficult0 = new Difficulty {DifficultyName = "Easy"};
            var difficult1 = new Difficulty { DifficultyName = "Confirmed" };
            var difficult2 = new Difficulty { DifficultyName = "Expert" };

            #endregion
            #region DifficultyRate
            //Easy
            var difficultRate0 = new DifficultyRate {Rate = 0.7M, DifficultyQuestionId = 0,DifficultyRateId = 0};
            var difficultRate1 = new DifficultyRate { Rate = 0.2M, DifficultyQuestionId = 0, DifficultyRateId = 1 };
            var difficultRate2 = new DifficultyRate { Rate = 0.1M, DifficultyQuestionId = 0, DifficultyRateId = 2 };
            //Confirmed
            var difficultRate3 = new DifficultyRate { Rate = 0.25M, DifficultyQuestionId = 1, DifficultyRateId = 0 };
            var difficultRate4 = new DifficultyRate { Rate = 0.5M, DifficultyQuestionId = 1, DifficultyRateId = 1 };
            var difficultRate5 = new DifficultyRate { Rate = 0.25M, DifficultyQuestionId = 1, DifficultyRateId = 2 };
            //Expert
            var difficultRate6 = new DifficultyRate { Rate = 0.1M, DifficultyQuestionId = 2, DifficultyRateId = 0 };
            var difficultRate7 = new DifficultyRate { Rate = 0.4M, DifficultyQuestionId = 2, DifficultyRateId = 1 };
            var difficultRate8 = new DifficultyRate { Rate = 0.5M, DifficultyQuestionId = 2, DifficultyRateId = 2 };
            #endregion
            #region Technology
            var technology0 = new Technology {TechnoName = "C#", IsActive = true};
            var technology1 = new Technology { TechnoName = "Java", IsActive = true };
            var technology2 = new Technology { TechnoName = "JavaScript", IsActive = true };
            var technology3 = new Technology { TechnoName = "PhP", IsActive = true };
            var technology4 = new Technology { TechnoName = "F#", IsActive = true };
            var technology5 = new Technology { TechnoName = "VB", IsActive = true };
            var technology6 = new Technology { TechnoName = "Sql", IsActive = true };
            #endregion
            #region Contact

            var contact0 = new Contact
            {
                FirstName = "adminfirstname",
                LastName = "adminlastname",
                Mail = "admin@outlook.fr",
                Phone = "0606060606",
                Type = true
            };
            #endregion
            #region TypeQuestion
            
            var questionType0 = new TypeQuestion {NameType = "Choix Unique"};
            var questionType1 = new TypeQuestion { NameType = "Choix Multiple" };
            var questionType2 = new TypeQuestion { NameType = "Choix Ouvert" };
            #endregion
            #region Ajouts dans la base
            //Difficulties
            context.Difficulty.AddOrUpdate(x=>x.DifficultyId,difficult0,difficult1,difficult2);
            //DifficultyRates
            context.DifficultyRate.AddOrUpdate(x=>x.DifficultyRateId,difficultRate0,difficultRate1,difficultRate2,difficultRate3
            ,difficultRate4,difficultRate5,difficultRate6,difficultRate7,difficultRate8);
            //Technologies
            context.Technology.AddOrUpdate(x=>x.TechnoId,technology0,technology1,technology2,technology3,technology4
            ,technology5,technology6);
            //Contact
            context.Contact.AddOrUpdate(x=>x.UserId,contact0);
            //TypeQuestion
            context.TypeQuestion.AddOrUpdate(x=>x.TypeQuestionId, questionType0,questionType1,questionType2);
            #endregion
        }
    }*/
    public class FilRougeDBContext : IdentityDbContext<ApplicationUser>
    {
        
        public FilRougeDBContext() :base("name=ConnexionStringFilRouge")
        {
           //Database.SetInitializer(new FilRougeDbContextInit());
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilRougeDBContext, Migrations.Configuration>()); //Pour la migration
        }
        //Documentation http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx


        public DbSet<Contact> Contact { get; set; }
        public DbSet<QuestionQuizz> QuestionQuizz { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<DifficultyRate> DifficultyRate { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<TypeQuestion> TypeQuestion { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
