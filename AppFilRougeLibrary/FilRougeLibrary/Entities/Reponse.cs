using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class Reponse
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReponseId { get; set; }
        public string Content { get; set; }
        /*[ForeignKey("Questions")]
        public int QuestionId { get; set; }*/
        #endregion
        #region Association
        public virtual Question Question { get; set; }
        #endregion
    }
}
