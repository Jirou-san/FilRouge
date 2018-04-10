using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Services
{
    interface IReferenceService
    {
        #region Question
        List<Question> GetAllQuestion();
        Question ShowQuestion(int? id);
        Question GetQuestion(int? id);
        int AddQuestion(Question question);
        bool DeleteQuestion(int id);
        #endregion

        #region Technology
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnology();
        #endregion

        #region Difficulty
        List<Difficulty> GetAllDifficuty();
        Difficulty GetDifficulty(int id);

        #endregion

        #region Type
        List<TypeQuestion> GetAllType();
        TypeQuestion GetTypeQuestion(int id);
        
        #endregion

    }
}
