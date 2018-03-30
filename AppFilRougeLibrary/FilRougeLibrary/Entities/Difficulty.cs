using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Difficulty
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyId { get; set; }
        public string DifficultyName { get; set; }

        #endregion
        #region Associations
        public virtual List<Question> Questions { get; set; }
        #endregion
    }
}
