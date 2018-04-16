using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Service
{
    interface IReferenceService
    {
        #region Question
        Question GetQuestion(int id);
        List<Question> GetAllQuestions();
        int AddQuestion(Question question);
        int DeleteQuestion(int id);
        Question ShowQuestion(int id);

        List<Question> GetQuestionsByQuizz(int quizzId);
        #endregion

        #region Technology
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnologies();
        #endregion

        #region Difficulty
        Difficulty GetDifficulty(int id);
        List<Difficulty> GetAllDifficuties();
        #endregion


    }
}
