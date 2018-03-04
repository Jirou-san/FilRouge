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
        
        public void CreateQuizz(List<Questions> _laListeDeTouteLesQuestions,List<Quizz> _laListeQuizz,string _difficulty, int _technoId, int _userId, string _userName, string _userFirstName, bool _questionLibre, int _nbQuestion)
        {

            List<Questions> _laListeDesQuestionsDuQuizz = new List<Questions>();
            //Ajout du quizz à la liste des quizz
            Quizz unQuizz = new Quizz(_difficulty, _technoId,_userId,_userName,_userFirstName,_questionLibre,_nbQuestion);
            _laListeQuizz.Add(unQuizz);

            
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
                    for (int i = 0; i <= _nbQuestion; i++) //Boucle servant à remplir le quizz en fonction du nombre de questions voulues
			        {
                        //if question libre à voir pour gérer ça
                        _idQuestionAlea = _questionAléatoire(_laListeDeTouteLesQuestions.Count);//Génération d'un id de question aléatoire en fonction de la liste totale des questions
                            foreach (Questions uneQuestion in _laListeDeTouteLesQuestions)//Pour chaque questions de la liste totale
	                        {
                                if(_idQuestionAlea == uneQuestion.QuestionID)//Si un id de question correspond au chiffre aléatoire
                                {
                                    if(_technoId == uneQuestion.TechnoId) //Vérification de la technologie associée au quizz pour la question
                                    {
                                    //Assignation des taux de questions en fonction de la difficultée
                                        if (_difficulty.ToUpper == "JUNIOR")
	                                    {
                                        
                                            _txJuniorQuest = 0.7;
                                            _txConfirmeQuest = 0.2;
                                            _txExpertQuest = 0.1;

                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {

                                                }
                                            }
	                                    }
                                        if (_difficulty.ToUpper == "CONFIRMED")
	                                    {
                                            _txJuniorQuest = 0.25;
                                            _txConfirmeQuest = 0.5;
                                            _txExpertQuest = 0.25;
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {

                                                }
                                            }
	                                    }
                                        if (_difficulty.ToUpper == "EXPERT")
	                                    {
                                            _txJuniorQuest = 0.1;
                                            _txConfirmeQuest = 0.4;
                                            _txExpertQuest = 0.50;
                                            foreach(Questions uneQuestionDuQuizz in _laListeDesQuestionsDuQuizz) // pour chaque questions dans le quizz
                                            {
                                                if(_idQuestionAlea != uneQuestionDuQuizz.QuestionID)//Gestion des doublons de questions
                                                {
                                                _laListeDesQuestionsDuQuizz.Add(uneQuestion); // Ajouter la question au quizz
                                                }
                                                else
                                                {

                                                }
                                            }
	                                    }
                                    }
                                    else
                                    {
                                    throw new ContactExeptionWrongTechno("Technologie choisie invalide");
                                    }
                                }
                            }                                                
	                }                    			  
                }
                else
                {
                    throw new ContactExeptionOverQuestions("Le nombre de questions saisies est invalide");
                }
            }
            catch(ContactExeptionOverQuestions)
            {
                //Retour au menu de base
            }
            catch(ContactExeptionWrongDifficulty)
            {
                //Retour au menu de base
            }
            catch(ContactExeptionOverQuestions)
            {
                //Retour au menu de base
            }
        }
        #endregion
    }
}
