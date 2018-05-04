using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Service
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    public class QuestionResponseService : IQuestionResponseService
    {
        protected FilRougeDBContext _db;
        public QuestionResponseService(FilRougeDBContext db)
        {
            _db = db;
        }
        #region Question
        /// <summary>
        /// Récuperer une question par son Id(sans détail)
        /// </summary>
        /// <returns>Retourne une Question</returns>
        public Question GetQuestion(int id)
        {
            var question = _db.Question
                            //.Include(nameof(Response))
                            .Where(e => e.Id == id).FirstOrDefault();
            if (question == null)
            {
                throw new NotFoundException(string.Format($"No question found with the id: {id}"));
            }

            return question;
        }
        public bool UpdateQuestion(Question question)
        {
            try
            {
                _db.Entry(question).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Recuperer une question (avec son detail)
        /// </summary>
        /// <returns>Un</returns>
        public Question ShowQuestion(int id)
        {
            var question = new Question();
            question = _db.Question
                                    .Include("Responses")
                                    .Include("Technology")
                                    .Include("Difficulty")
                                    .Include("UserResponses.QuestionQuizz")
                                    .Include("Responses")
                                    .FirstOrDefault(x => x.Id == id);

            if (question == null)
            {
                throw new NotFoundException(string.Format($"No question found with the id: {id}"));
            }
            return question;
        }

        /// <summary>
        /// Cette méthode permet d'afficher toutes les questions
        /// </summary>
        /// <returns>Retourne une liste de questions</returns>
        public List<Question> GetAllQuestions()
        {
            return _db.Question
                                .ToList();
        }

        /// <summary>
        /// Retourne toute les questions d'un quizz
        /// </summary>
        /// <param name="quizzId"></param>
        /// <returns>Liste de question (d'un quizz)</returns>
        public List<Question> GetQuestionsByQuizz(int quizzId)
        {
            //var questions = _db.Question
            //                            .Join(_db.QuestionQuizz,
            //                                question => question.Id,
            //                                questionQuizz => questionQuizz.QuestionId,
            //                                (question, questionQuizz) => new { question, questionQuizz })
            //                                .Where(o => o.questionQuizz.QuizzId == quizzId)
            //                            .Select(p => p.question).ToList();
            var questions = _db.QuestionQuizz
                            .Where(e => e.QuizzId == quizzId)
                            .Select(e=>e.Question)
                            .ToList();
            return questions;
        }

        /// <summary>
        /// Enregistrer une nouvelle question
        /// </summary>
        /// <returns>Retourne l'id de la question inserée</returns>
        public int AddQuestion(Question question)
        {
            _db.Question.Add(question);
            return _db.SaveChanges();
        }

        /// <summary>
        /// supprimer une question
        /// </summary>
        /// <returns>Retourne l'id de la question supprimée</returns>
        public int DeleteQuestion(int id)
        {
            var question = new Question() { Id = id };
            _db.Question.Attach(question);
            _db.Question.Remove(question);
            return _db.SaveChanges();
        }
        #endregion


        #region Response

        public bool UpdateQuizzAnswer(UserResponse useresponse)
        {
            try
            {
                _db.Entry(useresponse).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Récupérer une reponse par son id
        /// </summary>
        /// <param name="id">l'id de la reponse</param>
        /// <returns>une reponse (unique)/returns>
        public Response GetResponse(int id)
        {
            var response = _db.Response.Find(id);
            if (response == null)
            {
                throw new NotFoundException(string.Format($"No response found with the id: {id}"));
            }
            return response;
        }

        /// <summary>
        /// Récupérer l'ensemble des reponses
        /// </summary>
        /// <returns>une liste de reponse/returns>
        public List<Response> GetAllResponses()
        {
            return _db.Response.ToList();
        }

        /// <summary>
        /// Ajouter une reponse a une question
        /// </summary>
        /// <param name="response">la reponse a ajouter</param>
        /// <param name="questionId">la question dans laquelle ajouter</param>
        /// <returns>une liste de reponse/returns>
        public int AddResponse(Response response, int questionId)
        {
            _db.Response.Add(response);
            return _db.SaveChanges();
        }

        /// <summary>
        /// Ajouter une reponse a une question
        /// </summary>
        /// <param name="id">l'id de la reponse a supprimer</param>
        /// <returns>l'id de la reponse supprimée/returns>
        public int DeleteResponse(int id)
        {
            var reponse = new Response() { Id = id };

            _db.Response.Attach(reponse);
            _db.Response.Remove(reponse);
            return _db.SaveChanges();
        }
        public bool UpdateResponse(Response reponse)
        {
            try
            {
                _db.Entry(reponse).State = EntityState.Modified;
                 _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public List<Response> GetAllResponseByQuizz(int idQuizz)
        {
            throw new NotImplementedException();
        }


        // A CODERs
        //public List<Response> GetAllResponseByQuizz(int idQuizz)
        //{
        //    var responses = new List<Response>();
        //    responses = _db.QuestionQuizz
        //        .Where(e => e.QuizzId == idQuizz)
        //        .Select(e => e.Question.Responses)
        //        .ToList();
        //    return null;
        //}
        #endregion


    }
}
