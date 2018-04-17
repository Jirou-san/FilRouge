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
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    
    public class FilRougeDBContext : IdentityDbContext<Contact>
    {
        
        public FilRougeDBContext() :base("name=ConnexionStringFilRouge")
        {
           //Database.SetInitializer(new FilRougeDbContextInit());
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilRougeDBContext, Migrations.Configuration>()); //Pour la migration
        }
        //Documentation http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx


        //public DbSet<Contact> Contact { get; set; }
        public DbSet<QuestionQuizz> QuestionQuizz { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<DifficultyRate> DifficultyRate { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Technology> Technology { get; set; }
        //public DbSet<TypeQuestion> TypeQuestion { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
