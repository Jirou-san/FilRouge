using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Model.Interfaces
{
    public interface IQuizzService
    {
        /// <summary>
        /// Création d'un quizz
        /// </summary>
        /// <param name="userId">Id du contact créant le quizz</param>
        /// <param name="technologyId">L'id de la technology</param>
        /// <param name="difficultyId">L'id de la difficulté</param>
        /// <param name="userLastName">Le nom du contact</param>
        /// <param name="userFirstName">Le prénom du contact</param>
        /// <param name="externalNum">Le numéro externe du candidat</param>
        /// <param name="numberQuestions">Le nombre de questions pour un quizz</param>
        /// <param name="freeAnswerMax">Questions libre max</param>
        /// <param name="freeAnswerMin">Questions libre min</param>
        /// <returns></returns>
        int CreateQuizz(
            string userId,
            int technologyId,
            int difficultyId,
            string userLastName,
            string userFirstName,
            string externalNum,
            int numberQuestions,
            int freeAnswerMax = 0,
            int freeAnswerMin = 0);

        /// <summary>
        /// Obtneir un quizz grâce à son id
        /// </summary>
        /// <param name="id">Id du quizz</param>
        /// <returns></returns>
        Quizz GetQuizById(int id);

        /// <summary>
        /// Obtenir la liste de tous le squizz
        /// </summary>
        /// <returns>La liste des quizz</returns>
        List<Quizz> GetAllQuizz();

        /// <summary>
        /// La liste des quizz pour un agent
        /// </summary>
        /// <param name="agent"></param>
        /// <returns>Retourne tous les quizz</returns>
        List<Quizz> GetAllQuizz(Contact agent);

        /// <summary>
        /// Retourne une liste de quizz similaire au filtre passé en paramètre
        /// </summary>
        /// <param name="quizzFilter"></param>
        /// <returns>Retourne les quizz</returns>
        List<Quizz> GetQuizz(Quizz quizzFilter);


    }
}
