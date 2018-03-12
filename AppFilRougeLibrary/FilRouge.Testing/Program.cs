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
            string path = "C:\\Users\\Administrateur\\Source\\Repos\\FilRouge\\AppFilRougeLibrary\\FilRouge.Services\\DataChain.xml";
            FilRouge.Services.QuizzService aService = new FilRouge.Services.QuizzService();
            var Contact = new FilRouge.Entities.Entity.Contact
            {
                Name = "Admin",
                Prenom = "Nico",
                Tel = "0000000000",
                Email = "test@test.fr",
                Type = "admin"

            };
            using (Entities.Entity.FilRougeDBContext dbContext = new Entities.Entity.FilRougeDBContext()) {
                dbContext.Contact.Add(Contact);
                dbContext.SaveChanges();
            }
            Console.WriteLine();
               Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();

        }
    }
}
