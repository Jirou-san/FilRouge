using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Entities.Entity;
using System.Data.Entity;

namespace FilRouge.Entities.Entities
{
    public class FilRougeDBContext : DbContext
    {
        public FilRougeDBContext() :base("BDDFilRouge")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<FilRougeDBContext>());
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Quizz> Quizz { get; set; }
        public DbSet<Reponse> Reponse { get; set; }
        public DbSet<Technologies> Technologies { get; set; }

    }
}
