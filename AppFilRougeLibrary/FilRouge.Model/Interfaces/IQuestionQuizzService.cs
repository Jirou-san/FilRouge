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
        /// Permet d'obtenir une liste de questions quizz par l'id d'unquizz
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
        bool DeleteQuestionQuizz(int idQuestionQuizz);

        /// <summary>
        /// Ecrit les réponses pour un un questionQuizz donné et donne le focus à la question suivante
        /// </summary>
        /// <param name="questionQuizz">QuestionQuiz sur lequel on souhaite répondre. Met à jour La réponse libre ou le refus de réponse le cas échéant</param>
        void SetQuestionQuizAnswer(QuestionQuizz questionQuizz);

        /// <summary>
        /// Donne l'Id de la question en cours pour un quiz donné et des propositions de réponse associées
        /// </summary>
        /// <param name="quizId">Id du quiz dont on souhaite connaitre la question en cours</param>
        /// <returns>questionQuiz active avec la question et les choix de réponse</returns>
        QuestionQuizz GetActiveQuestion(int quizId);
    }
}
