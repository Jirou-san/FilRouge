using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace FilRouge.Entities.Entity
{
    public partial class UserReponse
    {
        #region Proporties
        [Key]
        [Column(Order = 0)]
        public int QuizzId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ReponseId { get; set; }
        public string Valeur { get; set; }
        #endregion
        #region Association
        public Quizz Quizz { get; set; }
        public Reponse Reponse{ get; set; }
        #endregion
    }
}
