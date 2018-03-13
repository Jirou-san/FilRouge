﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace FilRouge.Entities.Entity
{
    public partial class UserReponse
    {
        #region Proporties
        [Key, Column(Order = 0)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Reponse")]
        public int ReponseId { get; set; }
        public string Valeur { get; set; }
        #endregion
        #region Association
        public virtual ICollection<Quizz> Quizz { get; set; }
        public virtual ICollection<Reponse> Reponse { get; set; }
        #endregion
    }
}
