using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Response
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Content { get; set; }
        public bool IsTrue { get; set; }
        //Clés étrangères
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        #endregion
        #region Association
        public virtual Question Question { get; set; }
        #endregion
    }
}
