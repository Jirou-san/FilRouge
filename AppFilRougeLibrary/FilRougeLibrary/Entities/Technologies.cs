using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Entities.Entity
{

    public partial class Technologies
    {
        #region Properties

        public int TechnoID { get; set; }
        public string TechnoName { get; set; }
        public int Active { get; set; }

        #endregion     
        #region Association
        #endregion
    }
}
