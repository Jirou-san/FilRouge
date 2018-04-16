using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Response
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Content { get; set; }
        //Explication de la bonne réponse (facultative)
        public string Explanation { get; set; }

        public bool IsTrue { get; set; }
        #endregion
        #region Association
        public virtual Question Question { get; set; }
        #endregion
    }
}
