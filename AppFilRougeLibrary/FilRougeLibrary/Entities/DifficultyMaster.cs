using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Model.Entity;

namespace FilRouge.Model.Entity
{
    public partial class DifficultyMaster
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiffMasterId { get; set; }
        public string DiffMasterName { get; set; }
        #endregion
        #region Associations
        public virtual List<Quizz> Quizzs { get; set; }
        #endregion
    }
}