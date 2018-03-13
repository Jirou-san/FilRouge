using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using FilRouge.Entities;
namespace FilRouge.Services
{
    public class QuizzService //Services liés au quizz, pdf, gestion, mails, CRUD...
    {
        #region Properties

        #endregion
        public QuizzService() { } //Constructeur
        #region Methods
        
        /// <summary>
        /// Méthode permettant d'obtenir une chaine de caractères composée des infos d'un quizz en fonction de son id
        /// </summary>
        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
        /// <returns>Retourne la chaine de caractères du quizz</returns>
        public Entities.Entity.Quizz GetQuizz(int id)
        {
            Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();            
            Entities.Entity.Quizz fluentQuery = db.Quizz.Single(e => e.QuizzId == id);               
            db.Dispose();
            return fluentQuery;
        }
        public List<Entities.Entity.Quizz> GetAllQuizz()
        {
            List<Entities.Entity.Quizz> lesQuizz = new List<Entities.Entity.Quizz>();
            Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();
            
            var fluentQuery = db.Quizz.Select(e => e);
            foreach (var item in fluentQuery)
            {
                
                lesQuizz.Add(item);
            }
            db.Dispose();
            return lesQuizz;
        }
        #endregion
    }
}
