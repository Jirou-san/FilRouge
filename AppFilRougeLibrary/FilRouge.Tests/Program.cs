using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model;
using FilRouge.HttpHandler;


namespace FilRouge.Tests
{
    using FilRouge.Service;

    class Program
    {
        static void Main(string[] args)
        {
            var again = "Y";
            var dataset = new DataSetTest();


            //Menu pour gérer les tests
            Console.WriteLine($"1- Remplir les tables de la base{Environment.NewLine}");
            
            while (again == "Y" || again == "O")
            {
                Console.WriteLine($"Selectionnez une option");
                int choix = int.Parse(Console.ReadLine());
                again = again[0].ToString().ToUpper();
                switch (choix)
                {
                    case 1: // Chargement d'un jeu de données     
                        try
                        {
                            if(dataset.IsNull())
                            {
                                dataset.FillAllTables();
                            }
                            else
                            {
                                throw new Exception("La base de données contient déjà un jeu de données");

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"ERROR: {ex.Message}{Environment.NewLine}");
                        }
                        
                        Console.WriteLine($"{Environment.NewLine}Souhaitez vous continuer?");
                        again = Console.ReadLine();
                        break;
                    case 2: // Consommation de l'API    
                        try
                        {
                            var HttpHandler = new HttpQuestionQuizz();
                            foreach (var item in HttpHandler.GetQuestionQuizz(1, "string","string"))
                            {
                                Console.WriteLine($@"L'id du quizz est:{item.QuizzId}");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"ERROR: {ex.Message}{Environment.NewLine}");
                        }

                        Console.WriteLine($"{Environment.NewLine}Souhaitez vous continuer?");
                        again = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Fin des tests");
                        break;
                }
            }
            //Test création d'un quiz
            /*var myService = new QuizzService();
            string marcId = "ca4fd903-b099-470b-a19c-69ab8e54233e";
            int QuizId = myService.CreateQuizz(marcId
                        , dataset.GetTechnologyIdByName("C#")
                        , dataset.GetDifficultyDebutant()
                        , "MACRON"
                        , "Emmanuel"
                        , ""
                        , 40 // numberQuestions
                        , 0  //int freeAnswerMax = 0
                        , 10  //int freeAnswerMin = 0
                        );
            Console.WriteLine("QuizId = " + QuizId);*/
            Console.ReadKey();
        }
    }
}
