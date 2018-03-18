using System.Collections.Generic;
using System.Linq;
using FilRouge.Entities.Entity;

namespace FilRouge.Services
{
    public class ReferencesService
    {
        #region Properties
        #endregion
        public ReferencesService() { }


        #region Methods
        
        /// <summary>
        /// Permet d'obtenir toutes les technologies sous forme la forme d'une liste
        /// </summary>
        /// <returns>Retourne une liste</returns>
        public List<Technologie> GetTechnologies()
        {
            //Liste des technoligies
            List<Technologie> desTechnologies = new List<Technologie>();
            //Contexte d'accès à la base
            Entities.Entity.FilRougeDBContext db = new FilRougeDBContext();
            //Requête
            IQueryable<Technologie> fluentQuery = db.Technologies.Select(e => e);
            //Ajout à la liste
            foreach (var item in fluentQuery)
            {
                desTechnologies.Add(item);
            }
            db.Dispose();
            return desTechnologies;
        }
        /// <summary>
        /// Permet d'obtenir toutes les difficulties sous forme la forme d'une liste
        /// </summary>
        /// <returns>Retourne une liste</returns>
        public List<Difficulty> GetDifficulties()
        {
            //Liste des technoligies
            List<Difficulty> desDifficulties = new List<Difficulty>();
            //Contexte d'accès à la base
            Entities.Entity.FilRougeDBContext db = new FilRougeDBContext();
            //Requête
            IQueryable<Difficulty> fluentQuery = db.Difficulties.Select(e => e);
            //Ajout à la liste
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
