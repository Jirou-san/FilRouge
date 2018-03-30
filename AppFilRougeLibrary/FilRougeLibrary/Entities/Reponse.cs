using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Reponses
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReponseId { get; set; }
        public string Content { get; set; }
        public bool TrueReponse { get; set; }
        //Clés étrangères
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        #endregion
        #region Association
        public virtual Question Question { get; set; }
        #endregion
    }
}
