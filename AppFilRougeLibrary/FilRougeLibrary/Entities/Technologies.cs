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

        public int _TechnoID { get; set; }
        public string _TechnoName { get; set; }
        public int _Active { get; set; }

        #endregion              
    }
}
