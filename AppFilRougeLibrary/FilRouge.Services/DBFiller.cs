using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FilRouge.Services;
using FilRouge.Entities.Entity;
using System.Collections;
using System.Collections.Generic;

namespace FilRouge.Services
{
    public sealed class DBFiller
    {
        static Contact Contact = new Contact
        {
            Name = "Admin",
            Prenom = "Nico",
            Tel = "0000000000",
            Email = "test@test.fr",
            Type = "admin"

        };

        static Technologies Technologie = new Technologies
        {
            TechnoName = "C#",
            Active = true
        };
        static Technologies Technologie1 = new Technologies
        {
            TechnoName = "Java",
            Active = true
        };

        static Difficulties Difficult = new Difficulties
        {
            DifficultyName = "Junior",
            TauxJunior = 0.7m,
            TauxConfirmed = 0.2m,
            TauxExpert = 0.1m,
        };
        static Difficulties Difficult1 = new Difficulties
        {
            DifficultyName = "Confirmed",
            TauxJunior = 0.25m,
            TauxConfirmed = 0.5m,
            TauxExpert = 0.25m,
        };
        static Difficulties Difficult2 = new Difficulties
        {
            DifficultyName = "Expert",
            TauxJunior = 0.1m,
            TauxConfirmed = 0.4m,
            TauxExpert = 0.5m,
        };

        public static void AddDatas()
        {
            FilRougeDBContext dbContext = new FilRougeDBContext();
            dbContext.Contact.Add(Contact);
            dbContext.Technologies.Add(Technologie1);
            dbContext.Technologies.Add(Technologie);
            dbContext.Difficulties.Add(Difficult);
            dbContext.Difficulties.Add(Difficult1);
            dbContext.Difficulties.Add(Difficult2);
            dbContext.SaveChanges();
            dbContext.Dispose();
        }
    }
}
