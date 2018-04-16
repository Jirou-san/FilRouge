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
        public int Id { get; set; }
        [Index("IdxDisplayNum")]
        public int DisplayNum { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        #endregion
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        public virtual List<Question> Questions { get; set; }
        #endregion
    }
}
