using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Entities.Entity;
using System.Data.Entity;


namespace FilRouge.Entities.Entity
{
    public class FilRougeDBContext : DbContext
    {
        
        public FilRougeDBContext() :base("BDDAppliFilRouge")
        {
           //Database.SetInitializer(new DropCreateDatabaseAlways<FilRougeDBContext>()); //Pour la création de la base
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilRougeDBContext, Migrations.Configuration>()); //Pour la migration
        }
        //Documentation http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx


        public DbSet<Contact> Contact { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Reponse> Reponse { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<UserReponse> UserReponse { get; set; }
        //public DbSet<EtatQuizz> EtatQuizz { get; set; }
        public DbSet<Difficulties> Difficulties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
