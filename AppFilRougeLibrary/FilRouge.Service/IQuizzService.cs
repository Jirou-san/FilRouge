using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Service
{
    public interface IQuizzService
    {
        Quizz CreateQuizz();
        bool UpdateQuizzAnswer(int quizzId, int questionId, Response response);
        bool UpdateQuizzAnswers(int quizzId, List<Question> questions);
        Quizz GetQuizzById(int id);
        List<Quizz> GetAllQuizz();
    }
}
