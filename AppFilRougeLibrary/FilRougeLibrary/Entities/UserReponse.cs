using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FilRouge.Model.Entities
{
    public partial class UserResponse
    {
        #region Proporties
        [Key]
        [Column(Order = 0)]
        [ForeignKey("QuestionQuizz")]
        public int QuestionQuizzId { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Response")]
        public int ResponseId { get; set; }

        #endregion
        #region Association
        public virtual Response Response { get; set; }
        public virtual QuestionQuizz QuestionQuizz{ get; set; }
        #endregion
    }
}
