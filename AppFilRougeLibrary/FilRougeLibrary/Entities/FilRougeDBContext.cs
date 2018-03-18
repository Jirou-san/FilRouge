using System.Data.Entity;

namespace FilRouge.Entities.Entity
{
    public class FilRougeDBContext : DbContext
    {
        //Documentation http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx
        public FilRougeDBContext(/*string connString*/) :base("BDDAppliFilRouge")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<FilRougeDBContext>()); //Pour la création de la base
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilRougeDBContext, Migrations.Configuration>()); //Pour la migration
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Reponse> Reponse { get; set; }
        public DbSet<Technologie> Technologies { get; set; }
        public DbSet<UserReponse> UserReponse { get; set; }
        public DbSet<EtatQuizz> EtatQuizz { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
