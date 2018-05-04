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

        /// <summary>
        /// Ecrit les réponses pour un un questionQuizz donné et donne le focus à la question suivante
        /// </summary>
        /// <param name="questionQuizz">QuestionQuiz sur lequel on souhaite répondre. Met à jour La réponse libre ou le refus de réponse le cas échéant</param>
        public void SetQuestionQuizAnswer(QuestionQuizz questionQuizz)
        {
            //throw new Exception("Méthode non implémentée");
            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    // On récupère l'enregistrement qui correspond au question Quiz
                    var myQuestionQuiz = db.QuestionQuizz.Where(e => e.Id == questionQuizz.Id).FirstOrDefault();

                    if (myQuestionQuiz == null)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("QuestionQuiz Id non trouvé");
                    }
                    else
                    {
                        //Enregistrement existe
                        //On vérifie si certains champs ont été modifiés et on réalise la modif le cas échéant
                        if (questionQuizz.FreeAnswer != null) myQuestionQuiz.FreeAnswer = questionQuizz.FreeAnswer;
                        if (questionQuizz.RefuseToAnswer == true) myQuestionQuiz.RefuseToAnswer = questionQuizz.RefuseToAnswer;


                        //On écrit la liste des réponses de l'utilisateur
                        //throw new Exception("Méthode non implémentée"); // A traiter
                        try
                        {
                            foreach (var userResponse in questionQuizz.UserResponses)
                            {
                                // Vérification que la réponse utilisateur est apporté pour le questionQuiz donné et qu'il répond aussi à une proposition de réponse associé au questionQuiz
                                if (questionQuizz.Id != userResponse.QuestionQuizzId) throw new Exception("Discordance userRéponse et questionQuiz");
                                var questionId = (db.Response.Where(e => e.Id == userResponse.ResponseId).FirstOrDefault()).QuestionId;
                                if (questionQuizz.QuestionId != ((db.Response.Where(e => e.Id == userResponse.ResponseId).FirstOrDefault()).QuestionId))
                                    throw new Exception("Discordance userResponse et questionId du questionQuiz");

                                // Ajout de la userResponse
                                db.UserResponse.Add(userResponse);
                                db.SaveChanges();

                            }
                        }
                        catch (NullReferenceException)
                        {
                            //On passe cette exception sans la lever
                        }


                        //On met à jour le numéro de la question active
                        var myQuiz = db.Quizz.Where(e => e.Id == myQuestionQuiz.QuizzId).FirstOrDefault();
                        if (myQuiz == null)
                        {
                            dbContextTransaction.Rollback();
                            throw new Exception("Quiz Id non trouvé");
                        }
                        else
                        {
                            //On incrément la question active
                            myQuiz.ActiveQuestionNum += 1;
                            //Si on est arrivé à la fin du quiz on le marque dans la table
                            if (myQuiz.QuestionCount < myQuiz.ActiveQuestionNum) myQuiz.QuizzState = QuizzStateEnum.Done;
                            else myQuiz.QuizzState = QuizzStateEnum.InProgress;
                        }
                        db.SaveChanges();
                        // On est ici donc tout c'est bien passé
                        dbContextTransaction.Commit();
                    }
                }
            }
        }

        /// <summary>
        /// Donne l'Id de la question en cours pour un quiz donné et des propositions de réponse associées
        /// </summary>
        /// <param name="quizId">Id du quiz dont on souhaite connaitre la question en cours</param>
        /// <returns>questionQuiz active avec la question et les choix de réponse</returns>
        public QuestionQuizz GetActiveQuestion(int quizId)
        {
            int returnedQuestionId = 0;
            var myActiveQuestionQuiz =new QuestionQuizz();

            using (FilRougeDBContext db = new FilRougeDBContext())
            {
                
                //Récupération du numéro de la question active
                var numQ = db.Quizz
                            .Where(e => e.Id == quizId)
                            .Include(e=>e.Technology)
                            .First().ActiveQuestionNum;

                var questionsQuiz = db.QuestionQuizz
                            .Include(e=>e.Question)
                            .Include(e=>e.Question.Responses)
                            .Where(e => e.QuizzId == quizId)
                            .OrderBy(e => e.DisplayNum)
                            ;

                if (numQ == 0) numQ = 1; // Si le test n'a pas été commencé, on positionne sur la première question
                if (questionsQuiz.Count() < numQ)
                {
                    returnedQuestionId = 0;
                }
                else
                {
                    //returnedQuestionId = questionsQuiz.ElementAt(numQ - 1).QuestionId;
                    myActiveQuestionQuiz = questionsQuiz.Skip(numQ - 1).Take(1).FirstOrDefault();
                    //myActiveQuestionQuiz = questionsQuiz.Skip(
                    //                        (questionsQuiz.FirstOrDefault().Quizz.ActiveQuestionNum - 1)
                    //                        ).Take(1).FirstOrDefault();

                }

            }

            return myActiveQuestionQuiz;
        }
    }
}
