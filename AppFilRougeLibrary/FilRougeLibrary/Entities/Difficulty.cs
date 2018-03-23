using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class Difficulty
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
        public virtual ICollection<Quizz> QuizzS { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        #endregion
    }
}
