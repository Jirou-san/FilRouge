using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{

    public partial class Technologie
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnoId { get; set; }
        public string TechnoName { get; set; }
        public int Active { get; set; }

        #endregion     
        #region Association
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Quizz> Quizzs { get; set; }
        #endregion
    }
}
