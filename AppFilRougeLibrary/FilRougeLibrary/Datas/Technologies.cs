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
    }
}
