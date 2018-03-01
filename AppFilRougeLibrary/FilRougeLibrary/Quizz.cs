﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeLibrary
{
    class Quizz
    {
        #region Properties
        private int _QuizzID;
        private DateTime _Timer; //Timer en minutes pour la duréer du quizz
        private int _etatQuizz; //Indique si le quizz non-fait, en cours ou terminé
        private string _Difficulty;
        private int _technoId;
        private int _userId;
        private string _nomUser;
        private string _prenomUser;
        private bool _questionLibre;//true oui oui et false pour non
        private int _nombreQuestion;//nombre de questions à intégrer au quizz
        #endregion        

        public Quizz()
        {

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
        #endregion
    }
}
