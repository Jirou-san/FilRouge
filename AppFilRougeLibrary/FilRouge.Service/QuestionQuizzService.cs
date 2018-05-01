using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;

namespace FilRouge.Service
{
    public class QuestionQuizzService : IQuestionQuizzService
    {
        protected FilRougeDBContext _db;
        public QuestionQuizzService(FilRougeDBContext db)
        {
            _db = db;
        }
        public List<QuestionQuizz> GetQuestionQuizz(int quizzid)
        {
            return _db.QuestionQuizz.Where(e => e.QuizzId == quizzid).ToList();
        }

        public QuestionQuizz GetQuestionQuizzById(int idQuestionQuizz)
        {
            return 
        }


        public int AddQuestionQuizz(QuestionQuizz questionQuizz)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestrionQuizz(int idQuestionQuizz)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestionQuizz(QuestionQuizz questionQuizz)
        {
            throw new NotImplementedException();
        }
    }
}
