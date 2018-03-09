using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace FilRouge.Library
{

    public sealed class Technologies
    {
        #region Properties

        private int _TechnoID;
        private string _TechnoName;
        private int _Active;

        #endregion        

        
        #region Accesseurs
        //Setters / Getters
        public int Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public string TechnoName
        {
            get { return _TechnoName; }
            set { _TechnoName = value; }
        }

        public int TechnoID
        {
            get { return _TechnoID; }
            set { _TechnoID = value; }
        }
        #endregion
        #region Methods        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Technologie n° {0} \nNom : {1} \nActive : {2} (1 signifie Oui, 0 signifie Non, -1 signifie une erreur.)", TechnoID, TechnoName, Active);
        }
        #endregion
    }
}
