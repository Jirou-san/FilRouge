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
            int choix = 0;
            string continuer = "OUI";
            //DBFiller.AddDatas();
            while (continuer.ToUpper() == "OUI")
            {
                Console.WriteLine("1- Créer un quizz");
                Console.WriteLine("Choixissez une action à effectuer");
                choix = int.Parse(Console.ReadLine());
                bool librebool = false;
                Contact existingData;
                switch (choix)
                {
                    #region Case 1
                    case 1:
                        Console.WriteLine("Selectionnez un id de difficultée");
                        int difficultId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Selectionnez un id de technologie");
                        int technoId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Selectionnez un id d'utilisateur");
                        int userId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Selectionnez un nom de candidat");
                        string candidatName = Console.ReadLine();
                        Console.WriteLine("Selectionnez un prénom de candidat");
                        string candidatFirstName = Console.ReadLine();
                        Console.WriteLine("Question libre?");
                        string libre = Console.ReadLine().ToUpper();
                        if (libre == "OUI")
                        {
                            librebool = true;
                        }
                        else if(libre=="NON")
                        {
                            librebool = false;
                        }
                        else
                        {
                            Console.WriteLine("Erreur de saisie");
                        }
                        Console.WriteLine("Nombre de questions?");
                        int nbrQuestions = int.Parse(Console.ReadLine());
                        /*QuizzService.CreateQuizz(difficultId, technoId, userId, candidatName, candidatFirstName, librebool, nbrQuestions);*/
                        Console.WriteLine("Voulez-vous continuer?");
                        continuer = Console.ReadLine();
                        break;
                    #endregion
                    #region Ajouter des données
                    case 2:
                        
                        try
                        {
                            FilRougeDBContext db = new FilRougeDBContext();
                            existingData = db.Contact.Single(e => e.UserId == 1);
                            Console.WriteLine("Il y'a déjà des éléments dans la base");
                            db.Dispose();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message + " Les données vont être ajoutés");
                            DBFiller.AddDatas();

                            FilRougeDBContext db = new FilRougeDBContext();
                            existingData = db.Contact.Single(f => f.UserId == 1);
                            if(existingData != null)
                            {
                                Console.WriteLine("Les données ont bien été ajoutées");
                            }
                            else
                            {
                                Console.WriteLine("Un problème est survenue");
                            }
                            db.Dispose();
                        }
                        Console.WriteLine("Voulez-vous continuer?");
                        continuer = Console.ReadLine();
                        break;
                        #endregion
                }
            }

            Console.WriteLine(Environment.NewLine+"Appuyez sur une touche pour quitter...");
            Console.ReadKey();

        }
    }
}
