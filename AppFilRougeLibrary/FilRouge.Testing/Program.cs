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

namespace FilRouge.Testing
{

    class Program
    {
        static void Main(string[] args)
        {
            QuizzService aService = new FilRouge.Services.QuizzService();
            ReferencesService aReferenceService = new FilRouge.Services.ReferencesService();
            IListExtensions unOutil = new IListExtensions();
            
            var Contact = new Contact
            {
                Name = "Admin",
                Prenom = "Nico",
                Tel = "0000000000",
                Email = "test@test.fr",
                Type = "admin"

            };

            var Technologie = new Technologies
            {
                TechnoName = "C#",
                Active = true
            };
            var Technologie1 = new Technologies
            {
                TechnoName = "Java",
                Active = true
            };
            
            var Difficult = new Difficulties
            {
                DifficultyName = "Junior",
                TauxJunior=0.7m,
                TauxConfirmed = 0.2m,
                TauxExpert = 0.1m,
            };
            var Difficult1 = new Difficulties
            {
                DifficultyName = "Confirmed",
                TauxJunior = 0.25m,
                TauxConfirmed = 0.5m,
                TauxExpert = 0.25m,
            };
            var Difficult2 = new Difficulties
            {
                DifficultyName = "Expert",
                TauxJunior = 0.1m,
                TauxConfirmed = 0.4m,
                TauxExpert = 0.5m,
            };

            FilRouge.Entities.Entity.FilRougeDBContext dbContext = new Entities.Entity.FilRougeDBContext();
            dbContext.Contact.Add(Contact);
            dbContext.Technologies.Add(Technologie1);
            dbContext.Technologies.Add(Technologie);
            dbContext.Difficulties.Add(Difficult);
            dbContext.Difficulties.Add(Difficult1);
            dbContext.Difficulties.Add(Difficult2);
            dbContext.SaveChanges();
            dbContext.Dispose();

            //aService.CreateQuizz(2, 1, 1, "John", "Test", false, 40);
            /*unOutil.Shuffle(uneListe);
            foreach (var item in uneListe)
            {
                Console.WriteLine(item);
            }*/
            Console.WriteLine(Environment.NewLine+"Appuyez sur une touche pour quitter...");
            Console.ReadKey();

        }
    }
}
