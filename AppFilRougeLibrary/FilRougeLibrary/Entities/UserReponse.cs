using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class UserReponse
    {
        #region Proporties
        [Key, Column(Order = 0)]
        public int QuizzId { get; set; }
        [Key, Column(Order = 1)]
        public int ReponseId { get; set; }
        public string Valeur { get; set; }
        #endregion
        #region Association
        public virtual ICollection<Quizz> Quizzs { get; set; }
        public virtual ICollection<Reponse> Reponses { get; set; }
        #endregion
    }
}
