using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Entities.Entity;

namespace FilRouge.Entities.Entity
{
    public partial class Reponse
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReponseId { get; set; }
        public string Content { get; set; }
        #endregion
        #region Association
        public virtual Questions Questions { get; set; }
        #endregion
    }
}
