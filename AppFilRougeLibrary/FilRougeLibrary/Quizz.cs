using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace FilRouge.Library
{
    public class Quizz
    {
        #region Properties
        private int _QuizzID;
        private DateTime _Timer; //Timer en minutes pour la durée du quizz
        private int _etatQuizz; //Indique si le quizz non-fait, en cours ou terminé
        private string _Difficulty;
        private int _technoId;
        private int _userId;
        private string _nomUser;
        private string _prenomUser;
        private bool _questionLibre; //true oui oui et false pour non
        private int _nombreQuestion; //nombre de questions à intégrer au quizz
        private static int _nombreQuizz = 0;
        private List<Questions> _lesQuestions = new List<Questions>(); //List de questions que comportera un quizz
        #endregion        

        public Quizz(string ipDifficulty, int ipTechnoID, int ipUser, string ipNomUser, string ipPrenomUser, bool ipQuestionLibre, int ipNbQuestion)
        {
            _nombreQuizz++;
            _QuizzID = _nombreQuizz;
            _Timer = DateTime.Today; //A Modifier
            _etatQuizz = 0;
            _Difficulty = ipDifficulty;
            _technoId = ipTechnoID;
            _userId = ipUser;
            _nomUser = ipNomUser.ToUpper();
            _prenomUser = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ipPrenomUser);
            _questionLibre = ipQuestionLibre;
            _nombreQuestion = ipNbQuestion;
        }

        #region Accesseurs
        public int QuizzID { get => _QuizzID; set => _QuizzID = value; }
        public DateTime Timer { get => _Timer; set => _Timer = value; }
        public int EtatQuizz { get => _etatQuizz; set => _etatQuizz = value; }
        public string Difficulty { get => _Difficulty; set => _Difficulty = value; }
        public int TechnoId { get => _technoId; set => _technoId = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public string NomUser { get => _nomUser; set => _nomUser = value; }
        public string PrenomUser { get => _prenomUser; set => _prenomUser = value; }
        public bool QuestionLibre { get => _questionLibre; set => _questionLibre = value; }
        public int NombreQuestion { get => _nombreQuestion; set => _nombreQuestion = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("Quizz n° {0} \nEtat du Quizz : {1} \nDifficulté : {2} \nID Technologie : {3} \nID du Créateur : {4} \n Nom de la personne faisant le quizz : {5} "
                + "\nPrénom de la personne faisant le quizz : {6} \nNombre de questions : {7} \nQuestion Libre ? {8}"
                , QuizzID, EtatQuizz, Difficulty, TechnoId, UserId, NomUser, PrenomUser, NombreQuestion, QuestionLibre);
        }

        public void GeneratePdf() // Se base sur les libraires PDFSharp et MigraDoc
        {

        }
        #endregion
    }
}
