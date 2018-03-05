using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Library
{
    #region Exceptions
    public class ContactExeptionOverQuestions:Exception
    {
        public ContactExeptionOverQuestions(string message) :base(message)
            {
            }
    }
    public class ContactExeptionCantAdd:Exception
    {
        public ContactExeptionCantAdd(string message) :base(message)
            {
            }
    }
    public class ContactExeptionWrongTechno:Exception
    {
        public ContactExeptionWrongTechno(string message) :base(message)
            {
            }
    }
    public class ContactExeptionWrongDifficulty:Exception
    {
        public ContactExeptionWrongDifficulty(string message) :base(message)
            {
            }
    }
    #endregion
    public class Contact
    {
        #region Proporties
        private int _UserID;
        private string _Name;
        private string _Prenom;
        private string _Tel;
        private string _Email;
        private string _Type;
        private static int _compteurContact = 0;

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="ipname">The ipname.</param>
        /// <param name="ipprenom">The ipprenom.</param>
        /// <param name="iptel">The iptel.</param>
        /// <param name="ipemail">The ipemail.</param>
        /// <param name="iptype">The iptype.</param>
        public Contact(string ipname, string ipprenom, string iptel, string ipemail, string iptype)
        {
            _compteurContact++;
            UserID = _compteurContact;
            Name = ipname.ToUpper();
            Prenom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ipprenom);
            Tel = iptel;
            Email = ipemail;
            Type = iptype;
        }

        /// <summary>
        /// Getters / Setters
        /// </summary>
        /// 
        #region Accesseurs
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }


        public string Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion
        /// <summary>
        /// Surcharge de ToString afin d'afficher les informations d'un Agent ou d'un Admin.
        /// </summary>
        ///  
        #region Methods
        public override string ToString()
        {
            return string.Format("Utilisateur n° : {0} \nNom et Prénom : {1} {2} \nTel : {3} \nEmail : {4} \nType : {5}", UserID, Name, Prenom, Tel, Email, Type);
        }        
        /// <summary>
        /// Créer un quizz en prenant en compte la demande utilisateur / gère la technologie / la difficultée / le nombre de questions / présence de questions ouvertes ou non
        /// </summary>
        /// <param name="_laListeDeTouteLesQuestions">La liste de toute les questions.</param>
        /// <param name="_laListeQuizz">LalistedeQuizz.</param>
        /// <param name="_difficulty">The difficulty.</param>
        /// <param name="_technoId">The techno identifier.</param>
        /// <param name="_userId">The user identifier.</param>
        /// <param name="_userName">Name of the user.</param>
        /// <param name="_userFirstName">First name of the user.</param>
        /// <param name="_questionLibre">if set to <c>true</c> [question libre].</param>
        /// <param name="_nbQuestion">The nb question.</param>
        /// <exception cref="ContactExeptionWrongDifficulty">La difficultée choisie est incorecte</exception>
        /// <exception cref="ContactExeptionOverQuestions">Le nombre de questions saisies est invalide</exception>
        public void CreateQuizz(List<Questions> _laListeDeTouteLesQuestions,List<Quizz> _laListeQuizz,string _difficulty, int _technoId, int _userId, string _userName, string _userFirstName, bool _questionLibre, int _nbQuestion)
        {

            List<Questions> _laListeDesQuestionsDuQuizz = new List<Questions>();
            //Ajout du quizz à la liste des quizz
            Quizz unQuizz = new Quizz(_difficulty, _technoId,_userId,_userName,_userFirstName,_questionLibre,_nbQuestion);            

            //Ajout des questions libres pas encore faite

            int _txJuniorQuest = 0;
            int _txConfirmeQuest = 0;
            int _txExpertQuest = 0;

            Random _genIntAléatoire;
            int _idQuestionAlea;
            try
            {
                //Ajout des questions à un quizz (prend en compte le nombre de questions et la difficultée choisie par l'utilisateur
                if(_nbQuestion >= 50 || _nbQuestion <=30)//Nombre de questions min/max
                {                              
                    if(_difficulty.ToUpper=="JUNIOR")
                    {
                       
						_txJuniorQuest = 0.7;
                        _txConfirmeQuest = 0.2;
                        _txExpertQuest = 0.1;
                        
                        #region Taux de question Junior pour un quizz Junior
                        for (int i = 0; i < _nbQuestion*_txJuniorQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "JUNIOR")//Vérification de la difficultée d'une question
                                {
                                    if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                    {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                    _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                   throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }
                                            }
                                        }
                                    }                                 
                                }
                            }
			            }
                        #endregion
                        #region Taux de question Confirmé pour un quizz Junior
                        for (int i = 0; i < _nbQuestion*_txConfirmeQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "CONFIRMED")//Vérification de la difficultée d'une question
                                    {
                                        if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                        {
                                            if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                            {
                                                foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                                {
                                                    if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                    {
                                                        _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                    }
                                                    else
                                                    {
                                                        throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                
                            }
			            }
                        #endregion
                        #region Taux de question Expert pour un quizz Junior
                        for (int i = 0; i < _nbQuestion*_txExpertQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "EXPERT")//Vérification de la difficultée d'une question
                                {
                                     if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                     {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                            _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                    throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }                                            
                                            }
                                        }
                                     
                                     }
                                }
                            }
			            }
                        #endregion				   
					   
                    } 
                    else if(_difficulty.ToUpper=="CONFIRMED")
					{
                       
						_txJuniorQuest = 0.25;
                        _txConfirmeQuest = 0.5;
                        _txExpertQuest = 0.25;
                        
                        #region Taux de question Junior pour un quizz Confirmé
                        for (int i = 0; i < _nbQuestion*_txJuniorQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "JUNIOR")//Vérification de la difficultée d'une question
                                {
                                    if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                    {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                    _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                    throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }
                                            }
                                        }
                                    }                                 
                                }
                            }
			            }
                        #endregion
                        #region Taux de question Confirmé pour un quizz Confirmé
                        for (int i = 0; i < _nbQuestion*_txConfirmeQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "CONFIRMED")//Vérification de la difficultée d'une question
                                    {
                                        if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                        {
                                            if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                            {
                                                foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                                {
                                                    if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                    {
                                                        _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                    }
                                                    else
                                                    {
                                                        throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                
                            }
			            }
                        #endregion
                        #region Taux de question Expert pour un quizz Confirmé
                        for (int i = 0; i < _nbQuestion*_txExpertQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "EXPERT")//Vérification de la difficultée d'une question
                                {
                                     if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                     {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                            _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                    throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }                                            
                                            }
                                        }
                                     
                                     }
                                }
                            }
			            }
                        #endregion				   
					   
                    }
                    else if(_difficulty.ToUpper=="EXPERT")
					{
                       
						_txJuniorQuest = 0.1;
                        _txConfirmeQuest = 0.4;
                        _txExpertQuest = 0.5;
                        
                        #region Taux de question Junior pour un quizz Expert
                        for (int i = 0; i < _nbQuestion*_txJuniorQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "JUNIOR")//Vérification de la difficultée d'une question
                                {
                                    if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                    {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                    _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                    throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }
                                            }
                                        }
                                    }                                 
                                }
                            }
			            }
                        #endregion
                        #region Taux de question Confirmé pour un quizz Expert
                        for (int i = 0; i < _nbQuestion*_txConfirmeQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "CONFIRMED")//Vérification de la difficultée d'une question
                                    {
                                        if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                        {
                                            if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                            {
                                                foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                                {
                                                    if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                    {
                                                        _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                    }
                                                    else
                                                    {
                                                        throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                    }
                                                }
                                            }
                                        }
                                    }                               
                            }
			            }
                        #endregion
                        #region Taux de question Expert pour un quizz Expert
                        for (int i = 0; i < _nbQuestion*_txExpertQuest; i++)
			            {
                            //Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            _idQuestionAlea = _genIntAléatoire(_laListeDeTouteLesQuestions.Count);
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(uneQuestion.Difficulty == "EXPERT")//Vérification de la difficultée d'une question
                                {
                                     if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                     {
                                        if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                        {
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                            _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {
                                                    throw new ContactExeptionCantAdd("L'ajout de la question n'a pas pu être fait");
                                                }                                            
                                            }
                                        }
                                     
                                     }
                                }
                            }
			            }
                        #endregion				   					   
                    }
                    else
                    {
                        throw new ContactExeptionWrongDifficulty("La difficultée choisie est incorecte");
                    }
                }
                else
                {
                    throw new ContactExeptionOverQuestions("Le nombre de questions saisies est invalide");
                }
                _laListeQuizz.Add(unQuizz);
            }
            catch(ContactExeptionOverQuestions e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ContactExeptionOverQuestions e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ContactExeptionWrongDifficulty e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}

