using System.Collections.Generic;
using System.Linq;

namespace FilRouge.Services
{
    using FilRouge.Model.Entities;

    /// <summary>
    /// Classe ReferencesService permettant d'utiliser les entités associés au Quizz
    /// Difficulté et Technologies
    /// </summary>
    public static class ReferencesService
    {
        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Cette fonction permet d'obtenir toutes les technologies
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Technologies</returns>
        public static List<Technology> GetTechnologies()
        {
            
            List<Technology> desTechnologies =new List<Technology>();
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
        /// Cette méthode permet de récupérer toutes les difficultés
        /// Fonctionne avec une fluentQuerry
        /// </summary>
        /// <returns>Retourne une liste d'objets Diffulties</returns>
        public static List<Difficulty> GetDifficulties()
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
        #endregion
    }
}
