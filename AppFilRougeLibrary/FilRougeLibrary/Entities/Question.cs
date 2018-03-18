using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class Question
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Commentaire { get; set; }
        public bool Active { get; set; }
        public bool QuestionType { get; set; }
        /*public string Difficulty { get; set; }
        [ForeignKey("Technologies")]
        public string TechnoId { get; set; }
        [ForeignKey("Quizz")]
        public string QuizzId { get; set; }
        [ForeignKey("Reponses")]
        public string ReponseId { get; set; }*/
        #endregion
        #region Association

        public virtual ICollection<Quizz> Quizz { get; set; }
        public virtual ICollection<Reponse> Reponses { get; set; }
        public virtual Technologie Technologie { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        #endregion
    }
}
