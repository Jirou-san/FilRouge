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

        Quizz GetQuizById(int id);

        List<Quizz> GetAllQuizz();

        List<Quizz> GetAllQuizz(Contact agent);

        List<Quizz> GetQuizz(Quizz quizzFilter, bool extended = false);

        void SetQuestionQuizAnswer(QuestionQuizz questionQuizz, List<UserResponse> userResponses);
    }
}
