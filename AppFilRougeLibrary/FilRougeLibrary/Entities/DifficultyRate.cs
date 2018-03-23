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
    public partial class DifficultyRate
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyRateId { get; set; }
        public decimal Rate { get; set; }
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }
        #endregion

        #region Associations
        public Difficulty Difficulty { get; set; }
        #endregion
    }
}
