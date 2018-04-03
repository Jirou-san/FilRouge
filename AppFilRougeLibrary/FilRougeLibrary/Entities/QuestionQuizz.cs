using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class QuestionQuizz
    {
        #region Proporties
        [Key]
        public int QuestionQuizzId { get; set; }
        [Index("IndexQuizz_Question",IsUnique = true,Order = 1)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }
        [Index("IndexQuizz_Question", IsUnique = true, Order = 2)]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public string Value { get; set; } //Stockage de la réponse libre
        public string Comment { get; set; }
        public bool RefuseToAnswer { get; set; } // True pour a répondue, false pour l'inverse
        #endregion
        #region Association
        public virtual Question Question { get; set; }
        public virtual Quizz Quizz { get; set; }
        public virtual List<UserResponse> UserResponses { get; set; }
        #endregion

    }
}

