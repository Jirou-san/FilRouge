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
        /// Permet d'obtenir la chaine de connexion à la base via un document XML
        /// </summary>
        /// <param name="path">Le chemin d'accès du fichier en paramètre</param>
        /// <returns>Retourne la chaine de connexion, modifier le fichier xml pour modifier l'accès à la base</returns>
        public string GetConnexionChain(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);           
            XmlNode node = doc.DocumentElement.SelectSingleNode("/Data/Chain");
            string chain = node.InnerText;
            return chain;
        }
        /// <summary>
        /// Méthode permettant d'obtenir une chaine de caractères composée des infos d'un quizz en fonction de son id
        /// </summary>
        /// <param name="id">l'ID du quizz (sa clé primaire)</param>
        /// <returns>Retourne la chaine de caractères du quizz</returns>
        public string GetQuizz(int id)
        {
            string concatDataQuizz = "";
            using (Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext())
            {
                Entities.Entity.Quizz fluentQuery = db.Quizz.Single(e => e.QuizzId == id);
                concatDataQuizz += " Difficultée: " + fluentQuery.Difficulty +
                    "\r\n Nombre de questions: " + fluentQuery.NombreQuestion.ToString() +
                    "\r\n Prenom du candidat: " + fluentQuery.PrenomUser +
                    "\r\n Nom du candidat: " + fluentQuery.NomUser +
                    "\r\n Temps pour le faire:" + fluentQuery.Timer.ToString();
                if (fluentQuery.EtatQuizz == 0)
                {
                    concatDataQuizz += "\r\nEtat du quizz: Pas encore effectué";
                }
                else if (fluentQuery.EtatQuizz == 1)
                {
                    concatDataQuizz += "\r\nEtat du quizz: En cours";
                }
                else
                {
                    concatDataQuizz += "\r\nEtat du quizz: Terminé";
                }

                concatDataQuizz += "\r\nContact:";
                foreach (var item1 in fluentQuery.Contact)
                {
                    concatDataQuizz += " Prenom:" + item1.Prenom +
                        " Nom: " + item1.Name + " Mail: " + item1.Email;
                }
                foreach (var item1 in fluentQuery.Technologies)
                {
                    concatDataQuizz += " Technologie:" + item1.TechnoName;
                }

            }
            return concatDataQuizz;

        }
        public List<string> GetAllQuizz()
        {
            string concatDataQuizz = "";
            using (Entities.Entity.FilRougeDBContext db = new Entities.Entity.FilRougeDBContext())
            {
                var fluentQuery = db.Quizz.Select(e => e);
                foreach (var item in fluentQuery)
                {

                }
            }
        }
        #endregion
    }
}
