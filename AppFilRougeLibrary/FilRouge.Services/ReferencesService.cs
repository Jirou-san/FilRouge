using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Entities;

namespace FilRouge.Services
{
    /// <summary>
    /// Classe ReferencesService permettant d'utiliser les entités associés au Quizz
    /// Difficulté et Technologies
    /// </summary>
    public class ReferencesService
    {
        #region Properties
        #endregion
        /// <summary>
        /// Constructeur de la classe permettant d'utiliser les services associés
        /// </summary>
        public ReferencesService() { }


        #region Methods
        /// <summary>
        /// Cette fonction permet d'obtenir toutes les technologies
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Technologies</returns>
        public List<Entities.Entity.Technologies> GetTechnologies()
        {
            
            List<Entities.Entity.Technologies> desTechnologies =new List<Entities.Entity.Technologies>();
            Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();
            var fluentQuery = db.Technologies.Select(e => e);
            foreach (var item in fluentQuery)
            {
                desTechnologies.Add(item);
            }
            db.Dispose();
            return desTechnologies;
        }
        /// <summary>
        /// Cette méthode permet de récupérer toutes les difficultés
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Diffulties</returns>
        public List<Entities.Entity.Difficulties> GetDifficulties()
        {
            List<Entities.Entity.Difficulties> desDifficulties = new List<Entities.Entity.Difficulties>();
            Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext();
            var fluentQuery = db.Difficulties.Select(e => e);
            foreach (var item in fluentQuery)
            {
                desDifficulties.Add(item);
            }
            db.Dispose();
            return desDifficulties;
        }
        #endregion
    }
}
