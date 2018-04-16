using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class DifficultyRate
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       
        [ForeignKey("DifficultyQuizz")]
        public int DifficultyQuizzId { get; set; }
        [ForeignKey("DifficultyQuestion")]
        public int DifficultyQuestionId { get; set; }
        [Required]
        public decimal Rate { get; set; }
        #endregion
        #region Associations
        public virtual Difficulty DifficultyQuizz { get; set; }
        public virtual Difficulty DifficultyQuestion { get; set; }
        #endregion
    }
}