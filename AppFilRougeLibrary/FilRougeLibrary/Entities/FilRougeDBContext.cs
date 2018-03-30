// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilRougeDBContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FilRougeDBContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FilRouge.Model.Entities
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class FilRougeDBContext : DbContext
    {
        
        public FilRougeDBContext() :base("StringBDDAppliFilRouge")
        {
           //Database.SetInitializer(new DropCreateDatabaseAlways<FilRougeDBContext>()); //Pour la création de la base
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilRougeDBContext, Migrations.Configuration>()); //Pour la migration
        }
        //Documentation http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx


        public DbSet<Contact> Contact { get; set; }
        public DbSet<DifficultyMaster> DifficultyMaster { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<DifficultyRate> DifficultyRate { get; set; }
        public DbSet<Questions> Question { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Reponses> Reponse { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<TypeQuestion> TypeQuestion { get; set; }
        public DbSet<UserReponse> UserReponse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
