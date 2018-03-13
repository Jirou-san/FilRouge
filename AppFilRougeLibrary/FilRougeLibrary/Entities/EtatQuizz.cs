using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace FilRouge.Entities.Entity
{
    public partial class EtatQuizz
    {
        #region Proporties
        [Key, Column(Order = 0)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Questions")]
        public int QuestionId { get; set; }
        #endregion
        #region Associations
        public virtual ICollection<Quizz> Quizz { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        #endregion
    }
}
