using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class DifficultyRate
    {
        #region Properties
        //Clé composée de l'id d'un quizz et d'une difficultée
        [Key]
        [Column(Order = 0)]
        [ForeignKey("DifficultyMaster")]
        public int DifficultyMasterId { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }

        public decimal Rate { get; set; }
        #endregion

        #region Associations
        public virtual Difficulty Difficulty { get; set; }
        public virtual  DifficultyMaster DifficultyMaster { get; set; }
        #endregion
    }
}
