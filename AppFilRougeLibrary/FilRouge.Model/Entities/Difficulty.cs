using System.Collections.Generic;

namespace FilRouge.Model.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Difficulty
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index("IdxDisplayNum")]
        public int DisplayNum { get; set; }
        [Required]
        public string Name { get; set; }
        #endregion
        #region Associations
        public virtual List<Quizz> Quizzs { get; set; }
        public virtual List<Question> Questions { get; set; }
        #endregion
    }
}
