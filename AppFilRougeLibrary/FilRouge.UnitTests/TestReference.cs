using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FilRouge.Service;
using FilRouge.Model.Entities;
namespace FilRouge.UnitTests
{
    /// <summary>
    /// Nécessaire pour l'environnement de test
    /// </summary>
    public static class TestReference
    {
        /// <summary>
        /// Création d'un dbcontext, à utiliser dans un using
        /// </summary>
        /// <returns></returns>
        ///

        
        public static QuestionResponseService QuestionResponseService()
        {
            return new QuestionResponseService(new FilRougeDBContext());
        }
        public static ReferencesService ReferenceService()
        {
            return new ReferencesService(new FilRougeDBContext());
        }
        public static QuizzService QuizzService()
        {
            //TODO: Rejouter un paramètre db context dans le constructeur
            //Pour optimiser la réutilisabilité du code et son ergonomie
            return new QuizzService();
        }
    }

    /// <summary>
    /// Classe de référence pour les questions ainsi que la création d'objets nécessaire aux tests
    /// </summary>
    public class QuestionReference
    {
        public QuestionReference()
        {

        }
        public int NewQuestion()
        {
            Question question = new Question()
            {
                DifficultyId = 1,
                Content = "Unit test",
                IsFreeAnswer = true,
                IsEnable = true,
                Responses = new List<Response>(),
                TechnologyId = 1,
            };

            return TestReference.QuestionResponseService().AddQuestion(question);
        }
    }
}