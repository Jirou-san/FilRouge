using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Entities.Entity;

namespace FilRouge.Entities.Entity
{
    public partial class Questions
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public string Commentaire { get; set; }
        public bool Active { get; set; }
        public int QuestionType { get; set; }
        public string Difficulty { get; set; }
        public static int CompteurQuestions { get; set; }
        #endregion
        #region Association
        public virtual ICollection<Technologies> Technologies { get; set; }
        public virtual ICollection<Quizz> Quizzs { get; set; }
        public virtual ICollection<Reponse> Reponses { get; set; }
        #endregion
    }
}
