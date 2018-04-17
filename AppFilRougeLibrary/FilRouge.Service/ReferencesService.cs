using System.Collections.Generic;

namespace FilRouge.Model
{
    using FilRouge.Model.Entities;
    using FilRouge.Services;
    using System;
    using System.Linq;

    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe ReferencesService permettant d'utiliser les entités associés au Quizz
    /// Difficulté et Technologies
    /// </summary>
    public class ReferencesService : IReferenceService
    {
        FilRougeDBContext _db;

        #region Question
        /// <summary>
        /// Récuperer une question par son Id(sans détail)
        /// </summary>
        /// <returns>Retourne une Question</returns>
        public Question GetQuestion(int id)
        {
            var question = _db.Question.Find(id);
            return question ?? throw new NotFoundException(string.Format($"No question found with the id: {id}"));
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
                                    .Include("TypeQuestion")
                                    .Include("Difficulty")
                                    .SingleOrDefault(x => x.Id == id);

            return question ?? throw new NotFoundException(string.Format($"No question found with the id: {id}"));
        }

        /// <summary>
        /// Cette méthode permet d'afficher toutes les questions
        /// </summary>
        /// <returns>Retourne une liste de questions</returns>
        public List<Question> GetAllQuestions()
        {
            return _db.Question
                                .Include("Technology")
                                .Include("Difficulty")
                                .Include("TypeQuestion")
                                .ToList();
        }

        /// <summary>
        /// Retourne toute les questions d'un quizz
        /// </summary>
        /// <param name="quizzId"></param>
        /// <returns>Liste de question (d'un quizz)</returns>
        public List<Question> GetQuestionsByQuizz(int quizzId)
        {
            var questions = _db.Question
                                        .Join(_db.QuestionQuizz,
                                            question => question.Id,
                                            questionQuizz => questionQuizz.QuestionId,
                                            (question, questionQuizz) => new { question, questionQuizz })
                                            .Where(o => o.questionQuizz.QuizzId == quizzId)
                                        .Select(p => p.question).ToList();

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
            var question = new Question() {Id = id};
            _db.Question.Attach(question);
            _db.Question.Remove(question);
            return _db.SaveChanges();
        }
        #endregion
        #region Reponse

        #endregion

        #region Technology
        /// <summary>
        /// Recuperer une technology par son Id
        /// </summary>
        /// <param name="id"> id de la technology</param>
        /// <returns>Une technologie unique</returns>
        public Technology GetTechnology(int id)
        {
            var technology = _db.Technology.Find(id);
            return technology ?? throw new NotFoundException(string.Format($"No technology found with the id: {id}"));
        }

        /// <summary>
        /// Obtenir la liste de toute les technologies
        /// </summary>
        /// <returns>Une liste de technology/returns>
        public List<Technology> GetAllTechnologies()
        {
            return _db.Technology.ToList();
        }
        #endregion

        #region Difficulty
        /// <summary>
        /// Recupérer une difficulté par son id
        /// </summary>
        /// <param name="id"> l'id de la difficulté</param>
        /// <returns>Une difficulté (unique)</returns>
        public Difficulty GetDifficulty(int id)
        {
            var difficulty = _db.Difficulty.Find(id);
            return difficulty ?? throw new NotFoundException(string.Format($"No difficulty found with the id: {id}"));
        }

        /// <summary>
        /// obtenir la liste de toutes les difficultés
        /// </summary>
        /// <returns>liste de difficulté/returns>
        public List<Difficulty> GetAllDifficuties()
        {
            return _db.Difficulty.ToList(); ;
        }
        #endregion

        #region Response
        /// <summary>
        /// Récupérer une reponse par son id
        /// </summary>
        /// <param name="id">l'id de la reponse</param>
        /// <returns>une reponse (unique)/returns>
        public Response GetResponse(int id)
        {
            var response = _db.Response.Find(id);
            return response ?? throw new NotFoundException(string.Format($"No response found with the id: {id}"));
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

        // A CODERs
        public List<Response> GetAllResponseByQuizz(int idQuizz)
        {
            var responses = new List<Response>();
            return null;
        }
        #endregion


    }
}
