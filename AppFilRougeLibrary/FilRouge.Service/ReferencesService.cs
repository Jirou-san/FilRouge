using System.Collections.Generic;

namespace FilRouge.Service
{
    using FilRouge.Model.Entities;
    using FilRouge.Services;
    using System;
    using System.Linq;

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
            Question question = _db.Question.Find(id);
            if (question == null)
                throw new QuestionNotFoundExeption(id);
            return _db.Question.Find(id);
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
            return question ?? throw new QuestionNotFoundExeption(id);

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
            List<Question> questions = _db.Question
                                                    .Join(_db.QuestionQuizz,
                                                        question => question.Id,
                                                        questionQuizz => questionQuizz.QuestionId,
                                                        (question, questionQuizz) => new { question, questionQuizz })
                                                        .Where(o => o.questionQuizz.QuizzId == quizzId)
                                                    .Select(p => p.question).ToList();

            return questions ?? throw new QuestionsNotFoundException(quizzId);
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
            Question question = new Question() {Id = id};
            _db.Question.Attach(question);
            _db.Question.Remove(question);
            return _db.SaveChanges();
        }
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
            return technology ?? throw new TechnologyNotFound(id);
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
            return difficulty ?? throw new DifficultyNotFound(id);
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
    }
}
