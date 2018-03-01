using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeLibrary
{

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
            Name = ipname;
            Prenom = ipprenom;
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
        #endregion
    }
}
