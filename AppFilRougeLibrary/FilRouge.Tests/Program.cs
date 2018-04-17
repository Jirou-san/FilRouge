using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model;


namespace FilRouge.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Chargement d'un jeux de données
            var dataset = new DataSetTest();
            //dataset.FillAllTables();

            //Test création d'un quiz
            var myService = new QuizzService();
            string marcId = "ca4fd903-b099-470b-a19c-69ab8e54233e";
            myService.CreateQuizz(marcId
                        , dataset.GetTechnologyIdByName("C")
                        , dataset.GetDifficultyDebutant()
                        , "MACRON"
                        , "Emmanuel"
                        , ""
                        , 40 // numberQuestions
                        , 0  //int freeAnswerMax = 0
                        , 0  //int freeAnswerMin = 0
                        );
            Console.ReadKey();
        }
    }
}
