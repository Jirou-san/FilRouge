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


        #endregion

        
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
        #endregion
    }
}

