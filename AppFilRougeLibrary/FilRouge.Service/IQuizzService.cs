using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Services
{
    interface IQuizzService
    {
        void CreateQuizz(int userId, int technologyId, int difficultyId, string userLastName, string userFirstName, string externalNum, int numberQuestions, int freeAnswerMax = 0, int freeAnswerMin = 0);
        List<int> AddQuestions(string userLastName, string userFirstName, string externalNum, int technologyId, int difficultyId, int numberQuestions, bool isFreeAnswer = false);
    }
}
