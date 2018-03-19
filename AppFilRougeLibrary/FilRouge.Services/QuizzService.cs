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
        public Entities.Entity.Quizz GetQuizz(int id)
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
        
        public void CreateQuizz(int difficultyid, int technoid,int userid,string nomuser, string prenomuser, bool questionlibre, int nombrequestions)
        {
            List<Questions> questionsQuizz = new List<Questions>();
            int timer = DateTime.Now.Minute;
            FilRougeDBContext db = new FilRougeDBContext();
            ToolBox unOutil = new ToolBox();
            try
            {

                var contact = db.Contact.Single(e => e.UserId == userid);
                var difficulty = db.Difficulties.Single(e => e.DifficultyId == difficultyid);
                var technology = db.Technologies.Single(e => e.TechnoId == technoid);

                IQueryable<Questions> questions = db.Questions.Where(e => e.Technologies.TechnoId == technoid);
                if (nombrequestions <= 10 && nombrequestions >= 60)
                {
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxJunior); i++)
                    {

                    }
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxConfirmed); i++)
                    {

                    }
                    for (int i = 0; i < Math.Floor(nombrequestions * difficulty.TauxExpert); i++)
                    {

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
            }
            catch(Exception)
            {

            }
        }
        #endregion
    }
}
