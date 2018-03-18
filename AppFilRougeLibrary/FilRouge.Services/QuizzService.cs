using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FilRouge.Services;
using FilRouge.Entities.Entity;
namespace FilRouge.Services
{
    public class QuizzService //Services liés au quizz, pdf, gestion, mails, CRUD...
    {
        #region Properties

        #endregion
        public QuizzService() { } //Constructeur
        #region Methods
        /// <summary>
        /// Méthode permettant d'obtenir un quizz en fonction de son id
        /// </summary>
        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
        /// <returns>Retourne le quizz voulue</returns>
        public Quizz GetQuizz(int id)
        {
            // Contexte d'accès à la base
            FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();
            //Requête
            Quizz unQuizz = db.Quizz.Single(e => e.QuizzId == id);            
            db.Dispose();
            return unQuizz;
        }
        /// <summary>
        /// Fonction permettan d'obtenir tous les objets Quizz présent dans la base de données
        /// </summary>
        /// <returns>Retourne une lsite d'objets quizz</returns>
        public List<Quizz> GetAllQuizz()
        {
            //Initialisation de la liste des quizz a retourner
            List<Quizz> lesQuizz = new List<Quizz>();
            // Contexte d'accès à la base
            FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();
            //Requête
            IQueryable<Quizz> fluentQuery = db.Quizz.Select(e => e);
            //Ajout à la liste
            foreach (var item in fluentQuery)
            {
                lesQuizz.Add(item);
            }
            db.Dispose();
            return lesQuizz;
        }
        public void CreateQuizz(int userid, int difficultyid, int technoid, int nombrequestion, string username, string userfirstname, bool questionlibre)
        {
            //Entier servant à remplir la liste aléatoirement
            Random randomid = new Random();
            int count = 0;
            //Timer initialisé à 0
            int timer = DateTime.Now.Minute;
            //Liste de questions
            List<Question> questions = new List<Question>();
            //Contexte d'accès à la base de données
            FilRougeDBContext dbContext = new FilRougeDBContext();
            //Requetes

            //Obtenir le contact qui crée le quizz par son id
            var contactQuizz = dbContext.Contact.Single(e => e.UserId == userid);

            //Obtenir la difficultée du quizz par son id
            var difficultyQuizz = dbContext.Difficulties.Single(e => e.DifficultyId == difficultyid);

            //Obtenir la technologie du quizz par son id
            var technoQuizz = dbContext.Technologies.Single(e => e.TechnoId == technoid);

            //Obtention de la liste des questions en fonction de leur technologie, il y'aura un nombre de questions identiques a celles que l'utilisateur aura saisi et elle seront aléatoires, leur nombre sera proportionnel à la difficultée du quizz
            IQueryable<Question> questionsQuizz = dbContext.Questions.Where(e => e.Technologie.TechnoId == technoid).Select(e => e);
            count = questionsQuizz.Count();
            //Gestion optionnelle d'un min-max nombre de questions
            if (nombrequestion >= 20 && nombrequestion <= 50)
            {
                //Gestion de la difficultée pour le taux junior
                for (int i = 0; i < nombrequestion * difficultyQuizz.TauxJunior; i++)
                {
                    randomid.Next(1, count);
                }
                for (int i = 0; i < nombrequestion * difficultyQuizz.TauxConfirmed; i++)
                {
                    randomid.Next(1, count);
                }
                for (int i = 0; i < nombrequestion * difficultyQuizz.TauxExpert; i++)
                {
                    randomid.Next(1, count);
                }
            }
            else
            {
                //Erreur à gérer
            }
            //Création de l'objet quizz avec tout ses paramètres sauf l'id qui est auto incrémenté
            Quizz unQuizz = new Quizz
            {
                Contact = contactQuizz,
                Difficulty = difficultyQuizz,
                Technologie = technoQuizz,
                NombreQuestion = nombrequestion,
                NomUser = username,
                PrenomUser = userfirstname,
                Questions = questions,
                QuestionLibre = questionlibre,
                Timer = timer,
            };
            // Contexte d'accès à la base
            
            // Ajout du quizz
            /*db.Quizz.Add(unQuizz);
            // Sauvegarde des changements
            db.SaveChanges();
            db.Dispose();*/
        }
        #endregion
    }
}
