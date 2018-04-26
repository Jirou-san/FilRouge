namespace FilRouge.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Il ne s'agit pas d'une classe à implémenter, elle sert principalement à ajouter
    /// Certaines fonctionnalitées aux classes de service implémentées
    /// </summary>
    public static class ServiceExtention
    {

        /// <summary>
        /// URI de base qui ne pourra pas être récupéré avec cette classe
        /// Elle ne sert qu'à alimenter les méthodes d'extentions
        /// </summary>
        private static string _baseUri;

        /// <summary>
        /// Dictionnaire de string permettant de convertir un caractère en une chaîne
        /// </summary>
        private static Dictionary<char, string> _alphabetConvert = new Dictionary<char, string>();

        #region DicoFiller
        /// <summary>
        /// Fonction servant uniquement à remplir le dictionnaire de convertion
        /// </summary>
        /// <returns>Le dictionnaire associé à la classe</returns>
        private static Dictionary<char,string> DicoFiller()
        {
            //Dictionnaire alpha-numérique
            #region Dico
            _alphabetConvert.Add('a', "0nab");
            _alphabetConvert.Add('b', "bzv1");
            _alphabetConvert.Add('c', "2vec");
            _alphabetConvert.Add('d', "crx3");
            _alphabetConvert.Add('e', "4xtw");
            _alphabetConvert.Add('f', "wym5");
            _alphabetConvert.Add('g', "6mul");
            _alphabetConvert.Add('h', "lik7");
            _alphabetConvert.Add('i', "8koj");
            _alphabetConvert.Add('j', "jph9");
            _alphabetConvert.Add('k', "5hqg");
            _alphabetConvert.Add('l', "gsf4");
            _alphabetConvert.Add('m', "6fdd");
            _alphabetConvert.Add('n', "dfs3");
            _alphabetConvert.Add('o', "7sgq");
            _alphabetConvert.Add('p', "qhp2");
            _alphabetConvert.Add('q', "8pjo");
            _alphabetConvert.Add('r', "oki1");
            _alphabetConvert.Add('s', "9ilu");
            _alphabetConvert.Add('t', "umy0");
            _alphabetConvert.Add('u', "9ywt");
            _alphabetConvert.Add('v', "txr8");
            _alphabetConvert.Add('w', "7rce");
            _alphabetConvert.Add('x', "evz6");
            _alphabetConvert.Add('y', "5zba");
            _alphabetConvert.Add('y', "ann4");
            _alphabetConvert.Add('0', "3bgz");
            _alphabetConvert.Add('1', "vhe2");
            _alphabetConvert.Add('2', "1cfr");
            _alphabetConvert.Add('3', "xjt0");
            _alphabetConvert.Add('4', "8wdy");
            _alphabetConvert.Add('5', "mku5");
            _alphabetConvert.Add('6', "2lsi");
            _alphabetConvert.Add('7', "klo1");
            _alphabetConvert.Add('8', "4jqp");
            _alphabetConvert.Add('9', "hmq7");
            #endregion
            return _alphabetConvert;
        }
        #endregion

        #region EncodeData
        /// <summary>
        /// Méthode d'extention encodant une chaîne de caractères modifiable à volonté via la fonction DicoFiller
        /// Et l'appliquant à la chaîne rentrée en paramètres
        /// </summary>
        /// <param name="oldString">La chaîne nécessitant une modification</param>
        /// <returns>Retourne la nouvelle chaîne de charactères</returns>
        public static string EncodeData(string oldString)
        {
            DicoFiller(); //Remplissage du dictionnaire
            string newString = String.Empty;

            //Pour chaque lettres dans la chaîne saisie en paramètres, elle sera remplacé par la valeur associée 
            //En fonction du tableau
            foreach (var lettre in oldString)
            {
                newString += _alphabetConvert.Where(e => e.Key == lettre).Select(e => e.Value);
            }

            return newString;
        }
        #endregion

        #region UriGenerator
        /// <summary>
        /// Méthode d'extention permettant de gé7
        /// 
        /// nérer une URI
        /// </summary>
        /// <param name="baseUri">L'URL de base ex: http://localhost:81</param>
        /// <param name="externalnumber">Le numéro externe du candidat</param>
        /// <param name="lastname">Le nom du candidat</param>
        /// <param name="firstname">Le prénom du candidat</param>
        /// <param name="quizzid">L'id du quizz qui va être joué</param>
        /// <returns>Retourne la nouvelle url</returns>
        public static string UriGenerator(string baseUri, string externalnumber, string lastname, string firstname, int quizzid)
        {
            _baseUri = baseUri;
            string newUri = String.Empty;
            newUri = $"{_baseUri}/{EncodeData(quizzid.ToString())}/{EncodeData(externalnumber)}/{EncodeData(lastname)}/{EncodeData(firstname)}";
            return newUri;
        }
        #endregion

        public static void SendMail()
        {
            //TODO
            //La fonction qui permettra d'envoyer un mail via l'appli mobile
        }

        public static void GeneratePdf()
        {
            //TODO
            //La fonction qui permettra de générer un PDF du résultat du quizz ainsi qu'une correction
        }
    }
}