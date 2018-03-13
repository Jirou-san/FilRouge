using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FilRouge.Services;
using FilRouge.Entities;
 

namespace FilRouge.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizzService aService = new FilRouge.Services.QuizzService();
            ReferencesService aReferenceService = new FilRouge.Services.ReferencesService();

            /*var Contact = new FilRouge.Entities.Entity.Contact
            {
                Name = "Admin",
                Prenom = "Nico",
                Tel = "0000000000",
                Email = "test@test.fr",
                Type = "admin"

            };*/

            /*var Technologie = new FilRouge.Entities.Entity.Technologies
            {
                TechnoName = "C#",
                Active = true
            };
            var Technologie1 = new FilRouge.Entities.Entity.Technologies
            {
                TechnoName = "Java",
                Active = true
            };
            
            var Difficult = new FilRouge.Entities.Entity.Difficulties
            {
                DifficultyName = "Junior",
                TauxJunior=0.7m,
                TauxConfirmed = 0.2m,
                TauxExpert = 0.1m,
            };
            var Difficult1 = new FilRouge.Entities.Entity.Difficulties
            {
                DifficultyName = "Confirmed",
                TauxJunior = 0.25m,
                TauxConfirmed = 0.5m,
                TauxExpert = 0.25m,
            };
            var Difficult2 = new FilRouge.Entities.Entity.Difficulties
            {
                DifficultyName = "Expert",
                TauxJunior = 0.1m,
                TauxConfirmed = 0.4m,
                TauxExpert = 0.5m,
            };
            FilRouge.Entities.Entity.FilRougeDBContext dbContext = new Entities.Entity.FilRougeDBContext();
            dbContext.Technologies.Add(Technologie1);
            dbContext.Technologies.Add(Technologie);
            dbContext.Difficulties.Add(Difficult);
            dbContext.Difficulties.Add(Difficult1);
            dbContext.Difficulties.Add(Difficult2);
            dbContext.SaveChanges();
            dbContext.Dispose();*/
            /*foreach (var item in aReferenceService.GetTechnologies())
            {
                Console.WriteLine(item);
            }
            
            
            */
            /*aService.CreateQuizz(2, 1, 1, "John", "Test", false, 40);*/
            Console.WriteLine(Environment.NewLine+"Appuyez sur une touche pour quitter...");
            Console.ReadKey();

        }
    }
}
