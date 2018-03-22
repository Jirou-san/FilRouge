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
    public partial class Difficulties
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyId { get; set; }
        public string DifficultyName { get; set; }
        public decimal TauxJunior { get; set; }
        public decimal TauxConfirmed { get; set; }
        public decimal TauxExpert { get; set; }
        #endregion
        #region Associations
        public virtual List<Quizz> Quizzs { get; set; }
        public virtual List<Questions> Questions { get; set; }
        #endregion
    }
}
