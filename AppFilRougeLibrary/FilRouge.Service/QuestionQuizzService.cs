using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _db.QuestionQuizz.Where(e => e.QuizzId == quizzid)
                   .Include(nameof(UserResponse)) 
                   .Include(nameof(Quizz))
                   .ToList()
                ;
        }

        public QuestionQuizz GetQuestionQuizzById(int idQuestionQuizz)
        {
            return _db.QuestionQuizz.Find(idQuestionQuizz);
        }


        public int AddQuestionQuizz(QuestionQuizz questionQuizz)
        {
            _db.QuestionQuizz.Add(questionQuizz);
            return _db.SaveChanges();
        }

        public bool DeleteQuestionQuizz(int idQuestionQuizz)
        {
            try
            {
                var questionQuizz = new QuestionQuizz() { Id = idQuestionQuizz };
                _db.QuestionQuizz.Attach(questionQuizz);
                _db.QuestionQuizz.Remove(questionQuizz);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateQuestionQuizz(QuestionQuizz questionQuizz)
        {
            try
            {
                _db.Entry(questionQuizz).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
