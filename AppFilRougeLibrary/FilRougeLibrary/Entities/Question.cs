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
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Commentaire { get; set; }
        public bool Active { get; set; }
        public bool QuestionType { get; set; }
        #endregion
        #region Association

        public virtual ICollection<Quizz> Quizz { get; set; }
        public virtual ICollection<Reponse> Reponses { get; set; }
        public virtual Technologies Technologies { get; set; }
        public virtual Difficulties Difficulties { get; set; }
        #endregion
    }
}
