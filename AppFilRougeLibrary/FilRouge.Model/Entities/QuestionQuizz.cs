using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    using System.Collections.Concurrent;

    public partial class QuestionQuizz
    {
        #region Proporties
        [Key]
        public int Id { get; set; }
        [Index("IdxQuizz_Question",IsUnique = true,Order = 1)]
        [Index("IdxDisplayNum",IsUnique=false,Order =1)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }
        [Index("IdxQuizz_Question", IsUnique = true, Order = 2)]
        [Index("IdxDisplayNum", IsUnique = false, Order = 3)]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [Index("IdxDisplayNum",IsUnique = false,Order = 2)]
        public int DisplayNum { get; set; }

        public string FreeAnswer { get; set; } //Stockage de la réponse libre
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

