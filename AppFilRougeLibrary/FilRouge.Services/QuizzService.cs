using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FilRouge.Services
{
    public class QuizzService //Services liés au quizz, pdf, gestion, mails, CRUD...
    {
        #region Properties

        #endregion
        public QuizzService() { } //Constructeur        
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
    }
}
