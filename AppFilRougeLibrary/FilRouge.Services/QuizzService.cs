using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using FilRouge.Entities.Entity;
namespace FilRouge.Services
{
    /// <summary>
    /// Services liés au quizz, pdf, gestion, mails, CRUD...
    /// </summary>
    public class QuizzService 
    {
        #region Properties

        #endregion
        /// <summary>
        /// Constructeur de la classe de QuizzService
        /// </summary>
        public QuizzService() { } //Constructeur
        #region Methods
        
        /// <summary>
        /// Méthode permettant d'obtenir un quizz en fonction de son id
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
        /// <returns>Retourne un objet Quizz</returns>
        public Quizz GetQuizz(int id)
        {
            Quizz fluentQuery = new Quizz();
            FilRougeDBContext db = new FilRougeDBContext();
            try
            {
                fluentQuery = db.Quizz.Single(e => e.QuizzId == id);
                if(fluentQuery == null)
                {
                    throw new WrongIdQuizz("L'id saisie n'existe pas");
                }
                db.Dispose();                
            }
            catch(FormatException)
            {
                db.Dispose();
                Console.WriteLine("Veuillez saisir un id valide");
            }
            return fluentQuery;
        }
        /// <summary>
        /// Fonction retournant tous les quizz dans une liste de Quizz
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne tous les quizz</returns>
        public List<Quizz> GetAllQuizz()
        {
            List<Quizz> desQuizz = new List<Quizz>();
            FilRougeDBContext db = new FilRougeDBContext();
            try
            {   
                IQueryable<Quizz> fluentQuery = db.Quizz.Select(e => e);
                if(fluentQuery.Count() == 0)
                {
                    throw new ListQuizzEmpty("La liste des quizz est vide");
                }
                foreach (var item in fluentQuery)
                {
                    desQuizz.Add(item);
                }
                db.Dispose();
            }
            catch (ListQuizzEmpty)
            {
                db.Dispose();
            }
            
            return desQuizz;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionsQuizz"></param>
        /// <param name="lesQuestions"></param>
        /// <param name="questionlibre"></param>
        /// <param name="nombrequestions"></param>
        /// <returns></returns>
        public static List<Questions> AddQuestionToQuizz(List<Questions> questionsQuizz, IQueryable<Questions> lesQuestions, bool questionlibre, int nombrequestions)
        {
            Random rand = new Random();

            foreach (var item in lesQuestions)
            {//Parcours la liste
                if (questionlibre)
                {//Si le paramètre rentré par l'utilisateur pour une question est libre
                    if (item.QuestionId == rand.Next(1, nombrequestions))
                    {//Selection d'un id aléatoire pour notre liste de question
                        if (item.QuestionType == true)
                        {//Vérification question ouverte/fermée
                            foreach (var item1 in questionsQuizz)
                            {//Vérification présence dans la liste
                                if (item1.QuestionId == item.QuestionId)
                                {
                                    throw new AlreadyInTheQuestionsList("La question est déjà dans la liste");
                                }
                                else
                                {
                                    questionsQuizz.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new NoQuestionsForYou("Aucune question ne correspond à vos critères");
                    }
                }
                else
                {
                    if (item.QuestionId == rand.Next(1, nombrequestions))
                    {
                        if (item.QuestionType == false)
                        {
                            foreach (var item1 in questionsQuizz)
                            {//Vérification présence dans la liste
                                if (item1.QuestionId == item.QuestionId)
                                {
                                    throw new AlreadyInTheQuestionsList("La question est déjà dans la liste");
                                }
                                else
                                {
                                    questionsQuizz.Add(item);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new NoQuestionsForYou("Aucune question ne correspond à vos critères");
                    }
                }
            }
            return questionsQuizz;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="difficultyid"></param>
        /// <param name="technoid"></param>
        /// <param name="userid"></param>
        /// <param name="nomuser"></param>
        /// <param name="prenomuser"></param>
        /// <param name="questionlibre"></param>
        /// <param name="nombrequestions"></param>
        public static void CreateQuizz(int difficultyid, int technoid,int userid,string nomuser, string prenomuser, bool questionlibre, int nombrequestions)
        {
            List<Questions> questionsQuizz = new List<Questions>();
            int timer = 0;
            FilRougeDBContext db = new FilRougeDBContext();
            try
            {
                
                var contact = db.Contact.Single(e => e.UserId == userid);
                var difficulty = db.Difficulties.Single(e => e.DifficultyId == difficultyid);
                var technology = db.Technologies.Single(e => e.TechnoId == technoid);

                IQueryable<Questions> questions = db.Questions.Where(e => e.Technologies.TechnoId == technoid);

                if (nombrequestions <= 10 && nombrequestions >= 60)
                {//Nombre de questions min max
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxJunior); i++)
                    {//Taux de questions pour la liste de questions

                        AddQuestionToQuizz(questionsQuizz, questions, questionlibre, nombrequestions);
                    }
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxConfirmed); i++)
                    {
                        AddQuestionToQuizz(questionsQuizz, questions, questionlibre, nombrequestions);
                    }
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxExpert); i++)
                    {
                        AddQuestionToQuizz(questionsQuizz, questions, questionlibre, nombrequestions);
                    }
                }
                else
                {
                    //Throw new Exception
                }
                Quizz unQuizz = new Quizz
                {
                    NomUser = nomuser,
                    PrenomUser = prenomuser,
                    QuestionLibre = questionlibre,
                    NombreQuestion = nombrequestions,
                    EtatQuizz = 0,
                    Timer = timer,
                    Contact = contact,
                    Difficulties = difficulty,
                    Technologies = technology,
                    Questions = questionsQuizz

                };
                db.Quizz.Add(unQuizz);
                db.SaveChanges();
                db.Dispose();
            }

            catch(AlreadyInTheQuestionsList e)
            {
                Console.WriteLine(e.Message);
                db.Dispose();
            }
            catch (NoQuestionsForYou e)
            {
                Console.WriteLine(e.Message);
                db.Dispose();
            }
        }
        #endregion
    }
}
