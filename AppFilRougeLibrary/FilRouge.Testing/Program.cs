using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FilRouge.Services;
using FilRouge.Entities.Entity;
 

namespace FilRouge.Testing
{
    class Program
    {
        //Projet console pour effectuer des tests
        static void Main(string[] args)
        {
            #region Properties
            QuizzService quizzService = new QuizzService();
            ReferencesService referencesService = new ReferencesService();
            int choix = 0;
            int noQuizz = 0;
            string question = "Souhaitez-vous effectuer une autre action?";
            string choixQuestion = "OUI";
            #endregion
            /*var Contact = new Contact
            {
                Name = "Admin",
                Prenom = "Nico",
                Tel = "0000000000",
                Email = "test@test.fr",
                Type = "admin"

            };
            
            var Technologie1 = new Technologie
            {
                TechnoName = "C#",
                Active = 1
            };
            var Technologie2 = new Technologie
            {
                TechnoName = "Java",
                Active = 1
            };
            
            var Difficult1 = new Difficulty
            {
                DifficultyName = "Junior",
                TauxJunior=0.7m,
                TauxConfirmed = 0.2m,
                TauxExpert = 0.1m,
            };
            var Difficult2 = new Difficulty
            {
                DifficultyName = "Confirmed",
                TauxJunior = 0.25m,
                TauxConfirmed = 0.5m,
                TauxExpert = 0.25m,
            };
            var Difficult3 = new Difficulty
            {
                DifficultyName = "Expert",
                TauxJunior = 0.1m,
                TauxConfirmed = 0.4m,
                TauxExpert = 0.5m,
            };
            FilRougeDBContext dbContext = new FilRougeDBContext();
            dbContext.Contact.Add(Contact);
            dbContext.Technologies.Add(Technologie1);
            dbContext.Technologies.Add(Technologie2);
            dbContext.Difficulties.Add(Difficult1);
            dbContext.Difficulties.Add(Difficult2);
            dbContext.Difficulties.Add(Difficult3);
            dbContext.SaveChanges();
            dbContext.Dispose();*/
            while (choixQuestion.ToUpper() == "OUI")
            {
                Console.WriteLine("1- Lire un quizz" + Environment.NewLine +
                    "2- Lire tous les quizzs" + Environment.NewLine +
                    "3- Lire les technologies" + Environment.NewLine +
                    "4- Lire les difficultés" + Environment.NewLine);

                Console.WriteLine("Que voulez vous faire?");
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 1: //Lecture d'un quizz
                        Console.WriteLine("Selectionnez un numéro de quizz");
                        noQuizz = int.Parse(Console.ReadLine());
                        Quizz unQuizz = quizzService.GetQuizz(noQuizz);
                        Console.WriteLine("Contact: {0} \r\n Difficulté: {1} \r\n Technologie:{2}\r\n" +
                            "Nom du candidat: {3} \r\n Prénom du candidat: {4} \r\n Nombre de" + "questions: {5}", unQuizz.Contact.Prenom + " " + unQuizz.Contact.Name,
                            unQuizz.Difficulty.DifficultyName, unQuizz.Technologie.TechnoName,
                            unQuizz.NomUser, unQuizz.PrenomUser, unQuizz.NombreQuestion.ToString());
                        Console.WriteLine(question);
                        choixQuestion = Console.ReadLine();
                        break;
                    case 2: //Lecture de tous les quizz
                        foreach (var item in quizzService.GetAllQuizz())
                        {
                            Console.WriteLine("Contact: {0} \r\n Difficulté: {1} \r\n Technologie:{2}\r\n" +
                            "Nom du candidat: {3} \r\n Prénom du candidat: {4} \r\n Nombre de" + "questions: {5}", item.Contact.Prenom + " " + item.Contact.Name,
                            item.Difficulty.DifficultyName, item.Technologie.TechnoName,
                            item.NomUser, item.PrenomUser, item.NombreQuestion.ToString());
                        }
                        Console.WriteLine(question);
                        choixQuestion = Console.ReadLine();
                        break;
                    case 3: //Lecture des technologies
                        foreach (var item in referencesService.GetTechnologies())
                        {
                            Console.WriteLine("Technologie n°: {0} Nom: {1}", item.TechnoId, item.TechnoName);
                        }
                        Console.WriteLine(question);
                        choixQuestion = Console.ReadLine();
                        break;
                    case 4: //Lecture des difficultées
                        foreach (var item in referencesService.GetDifficulties())
                        {
                            Console.WriteLine("Diffuculté n°: {0} Nom: {1} \r\n Taux Junior: {2}% Taux Confirmé: {3}% Taux Expert: {4}%", item.DifficultyId, item.DifficultyName, item.TauxJunior * 100, item.TauxConfirmed * 100, item.TauxExpert * 100);
                        }
                        Console.WriteLine(question);
                        choixQuestion = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Fin du test");
                        Console.ReadKey();
                        break;

                }
            }            
        }
    }
}
