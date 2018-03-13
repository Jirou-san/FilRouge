using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Entities;

namespace FilRouge.Services
{
    public class ReferencesService
    {
        #region Properties
        #endregion
        public ReferencesService() { }


        #region Methods
        /// <summary>
        /// Obtient une liste des technologies 
        /// </summary>
        /// <param name="datachain">La chaine de connexion à la base</param>
        /// <returns>Retourne la liste des technologies sous forme de string</returns>
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
