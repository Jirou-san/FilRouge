using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model.Entities;

namespace FilRouge.Model.Interfaces
{
    public interface IQuestionQuizzService
    {
        /// <summary>
        /// Permet d'obtenir une liste de questions quizz par l'id deu quizz
        /// </summary>
        /// <param name="quizzid">Id du quizz </param>
        /// <returns>La liste de questions quizz</returns>
        List<QuestionQuizz> GetQuestionQuizz(int quizzid);

        /// <summary>
        /// Permet d'obtenir une question quizz par son id
        /// </summary>
        /// <param name="idQuestionQuizz">Id de la question quizz</param>
        /// <returns>Retourne la quesiton quizz</returns>
        QuestionQuizz GetQuestionQuizzById(int idQuestionQuizz);

        /// <summary>
        /// Ajoute une question quizz
        /// </summary>
        /// <param name="questionQuizz">Quesiton quizz à rajouter</param>
        /// <returns>L'id de la question quizz ajoutée</returns>
        int AddQuestionQuizz(QuestionQuizz questionQuizz);

        /// <summary>
        /// Suppression d'une question quizz
        /// </summary>
        /// <param name="idQuestionQuizz">Id d ela question quizz a supprimer</param>
        /// <returns>Retourne success or fail</returns>
        bool DeleteQuestrionQuizz(int idQuestionQuizz);

        /// <summary>
        /// Mise à jour d'une question quizz 
        /// </summary>
        /// <param name="questionQuizz">La question quizz</param>
        /// <returns>Success or fail</returns>
        bool UpdateQuestionQuizz(QuestionQuizz questionQuizz);
    }
}
