using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> GetTechnologies(string datachain)
        {
            string concatDataQuizz = "";
            List<string> desTechnologies = new List<string>();
            Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext(datachain);
            var fluentQuery = db.Technologies.Select(e => e);
            foreach (var item in fluentQuery)
            {
                concatDataQuizz = "Nom de la technologie: "+item.TechnoName; //On peut ajouter Active c'est optionnel
                desTechnologies.Add(concatDataQuizz);
            }
            db.Dispose();
            return desTechnologies;
        }
        #endregion
    }
}
