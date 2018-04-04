using System.Collections.Generic;

namespace FilRouge.Services
{
    using FilRouge.Model.Entities;
    using System;
    using System.Linq;

    /// <summary>
    /// Classe ReferencesService permettant d'utiliser les entités associés au Quizz
    /// Difficulté et Technologies
    /// </summary>
    public class ReferencesService
    {
        #region Question
        /// <summary>
        /// Cette méthode permet d'afficher toutes les questions
        /// </summary>
        /// <returns>Retourne une liste de questions</returns>
        public List<Question> GetAllQuestion()
        {
            List<Question> allQuestions = new List<Question>();
            using (var db = new FilRougeDBContext())
            {
                try
                {
                    allQuestions = db.Question
                                            .Include("Technology")
                                            .Include("Difficulty")
                                            .Include("TypeQuestion")
                                            .ToList();
                }
                catch (FormatException)
                {

                }
            }
            return allQuestions;
        }

        /// <summary>
        /// Cette méthode permet d'afficher le detail d'une question
        /// </summary>
        /// <returns>Retourne une Question</returns>
        public Question ShowQuestion(int? id)
        {
            var question = new Question();

            using (var db = new FilRougeDBContext())
            {
                question = db.Question.Include("Reponses").SingleOrDefault(x => x.QuestionId == id);
            }
            return question;
        }
        
        /// <summary>
        /// Cette méthode permet d'afficher une question (sans détail)
        /// </summary>
        /// <returns>Retourne une Question</returns>
        public Question GetQuestion(int? id)
        {
            var question = new Question();

            using (var db = new FilRougeDBContext())
            {
                question = db.Question.Find(id);
            }
            return question;
        }

        /// <summary>
        /// Cette méthode permet d'enregistrer une nouvelle question
        /// </summary>
        /// <returns>Retourne l'id de la question inserée</returns>
        public int AddQuestion(Question question)
        {
            using (var db = new FilRougeDBContext())
            {
                db.Question.Add(question);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Cette méthode permet de supprimer une question
        /// </summary>
        /// <returns>Retourne l'id de la question supprimée</returns>
        public int DeleteQuestion(int id)
        {
            using (var db = new FilRougeDBContext())
            {
                Question question = new Question() { QuestionId = id };
                db.Question.Attach(question);
                db.Question.Remove(question);
                return db.SaveChanges();
            }
        }
        #endregion

        #region Technology
        /// <summary>
        /// Cette fonction permet d'obtenir toutes les technologies
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Technologies</returns>
        public List<Technology> GetTechnologies()
        {

            List<Technology> desTechnologies = new List<Technology>();
            FilRougeDBContext db = new FilRougeDBContext();
            var fluentQuery = db.Technology.Select(e => e);
            foreach (var item in fluentQuery)
            {
                desTechnologies.Add(item);
            }
            db.Dispose();
            return desTechnologies;
        }

        /// <summary>
        /// Cette fonction permet d'afficher une technologie
        /// </summary>
        /// <returns>Retourne technologie</returns>
        public Technology GetTechnologyById(int id)
        {

            FilRougeDBContext db = new FilRougeDBContext();
            var fluentQuery = db.Technology.Single(e => e.TechnoId == id);
            db.Dispose();
            return fluentQuery;
        }

        /// <summary>
        /// Cette méthode permet de récupérer toutes les difficultés
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Diffulties</returns>
        public List<Difficulty> GetDifficulties()
        {
            List<Difficulty> desDifficulties = new List<Difficulty>();
            FilRougeDBContext db = new FilRougeDBContext();
            var fluentQuery = db.Difficulty.Select(e => e);
            foreach (var item in fluentQuery)
            {
                desDifficulties.Add(item);
            }
            db.Dispose();
            return desDifficulties;
        }

        /// <summary>
        /// Cette méthode permet d'afficher toutes les technolgies
        /// </summary>
        /// <returns>Retourne la liste des technolgies</returns>
        public List<Technology> GetAllTechnology()
        {
            var technologies = new List<Technology>();
            using (var db = new FilRougeDBContext())
            {
                technologies = db.Technology.ToList();
            }
            return technologies;
        }
        #endregion

        #region Difficulty
        /// <summary>
        /// Cette méthode permet d'afficher toutes les difficultés
        /// </summary>
        /// <returns>Retourne la liste des difficultés</returns>
        public List<Difficulty> GetAllDifficuty()
        {
            var difficulties = new List<Difficulty>();
            using (var db = new FilRougeDBContext())
            {
                difficulties = db.Difficulty.ToList();
            }
            return difficulties;
        }
        #endregion

        #region Type
        /// <summary>
        /// Cette méthode permet d'afficher toutes les types
        /// </summary>
        /// <returns>Retourne la liste des types</returns>
        public List<TypeQuestion> GetAllType()
        {
            var types = new List<TypeQuestion>();
            using (var db = new FilRougeDBContext())
            {
                types = db.TypeQuestion.ToList();
            }
            return types;
        }
        #endregion
    }
}
