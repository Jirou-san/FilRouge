using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Library
{
    public class Questions
    {
        #region Properties
        private int _QuestionID;
        private string _Content;
        private string _Commentaire;
        private bool _Active;
        private int _QuestionType;
        private string _Difficulty;
        private static int _CompteurQuestions;
        private int _TechnoId;
        #endregion
        
        #region Accesseurs
        public int QuestionID { get => _QuestionID; set => _QuestionID = value; }
        public string Content { get => _Content; set => _Content = value; }
        public string Commentaire { get => _Commentaire; set => _Commentaire = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int QuestionType { get => _QuestionType; set => _QuestionType = value; }
        public string Difficulty { get => _Difficulty; set => _Difficulty = value; }
        public int TechnoId { get => _TechnoId; set => _TechnoId = value; }
        #endregion
        #region Methods
        #endregion
    }
}
