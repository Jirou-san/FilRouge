using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Entities.Entity
{
    public partial class Reponse
    {
        #region Properties
        public int ReponseId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        #endregion
        #region Association
        #endregion
    }
}
