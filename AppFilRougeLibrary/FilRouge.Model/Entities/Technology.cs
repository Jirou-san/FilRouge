using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{

    public partial class Technology
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnoId { get; set; }
        [MaxLength(20)]
        [Required]
        public string TechnoName { get; set; }
        [Required]
        public bool IsActive { get; set; }

        #endregion
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        public virtual List<Question> Questions { get; set; }
        #endregion
    }
}
