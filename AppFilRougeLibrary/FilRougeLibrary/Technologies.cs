using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRougeLibrary
{
    public sealed class Technologies
    {
        #region Propoerties

        private int _TechnoID;
        private string _TechnoName;
        private int _Active;
        private static int _compteurTechno = 0;

        #endregion          
        public Technologies(string ipTechnoname, string ipActive)
        {
            _compteurTechno++;
            _TechnoID = _compteurTechno;
            _TechnoName = ipTechnoname;
            if (ipActive.ToUpper() == "OUI")
                _Active = 1;
            else if (ipActive.ToUpper() == "NON") _Active = 0;
            else _Active = -1;
        }
        #region Accesseurs
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
        public override string ToString()
        {
            return string.Format("Technologie n° {0} \nNom : {1} \nActive : {2} (1 signifie Oui, 0 signifie Non, -1 signifie une erreur.)", TechnoID, TechnoName, Active);
        }
        #endregion
    }
}
