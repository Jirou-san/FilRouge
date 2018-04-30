using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilRouge.Tests;
using System.Linq;
//using Microsoft.AspNet.Identity;
using FilRouge.Model.Entities;

namespace FilRouge.UnitTests.Services.QuizzTests
{
    /// <summary>
    /// Description résumée pour UnitTestQuiz
    /// </summary>
    [TestClass]
    public class UnitTestQuiz
    {
        public QuizzService Quiz = new QuizzService();
        public DataSetTest DataSet = new DataSetTest();

        public UnitTestQuiz()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreateQuiz()
        {
            var userId =DataSet.GetUserId("Marc");
            
            //Récupération du QuizId créé
            var returnedQuizID = Quiz.CreateQuizz(userId
                            , DataSet.GetTechnologyCSharp()
                            , DataSet.GetDifficultyIntermediaire()
                            , "_TestCreatQuiz"
                            ,DateTime.Now.ToString()
                            , "#1234567890"
                            , 20
                            , 0
                            , 0
                            );

            Assert.AreNotEqual(returnedQuizID, 0); //Id retourné donc création réussie

            #region Test création du quiz et unicité de l'ID
            var quizFilter = new Quizz()
            {
                Id=returnedQuizID,
            };

            var myQuiz = Quiz.GetQuizz(quizFilter, true);
            Assert.IsNotNull(myQuiz);
            Assert.AreEqual(1, myQuiz.Count);
            Assert.AreEqual(returnedQuizID, myQuiz[0].Id);
            #endregion

            //Vérification que le nombre de questions est correct
            #region Test de l'existance des questions liste
            var myQuestions = myQuiz[0].QuestionQuizz;
            Assert.AreEqual(20, myQuestions.Count);

            //Assert.AreEqual(returnedQuizID.)

            #endregion

            #region Suppression des données précédement créées
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                var toDelete = db.Quizz
                                .Include(nameof(QuestionQuizz))
                                .Where(e => e.Id == myQuiz[0].Id);
                //throw new Exception("Erreur clause Where non implémentée\n impossible de supprimer les quizz en l'état");
                //Message pour le formidable dev qui va me lire :
                //Pour une raison inconnue la clause where n'est pas 
                //reconnue comme étant utilisable. C'estr troublant et désagréable.
                //Je noie mon chagrin dans le cognac en attendant ;-)
                // Le formidable dev c'est Nicolas ;-) Manquait un using mais message pas clair de MS VS
                db.Quizz.RemoveRange(toDelete);
            }
            #endregion
        }
    }
}
