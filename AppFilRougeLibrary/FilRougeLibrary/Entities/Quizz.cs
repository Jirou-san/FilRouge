﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzId { get; set; }
        public int Timer { get; set; } //Timer en minutes pour la durée du quizz
        /*public int EtatQuizz { get; set; } //Indique si le quizz non-fait, en cours ou terminé
        public string Difficulty { get; set; }
        [ForeignKey("Technologies")]
        public int TechnoId { get; set; }
        [ForeignKey("Contact")]
        public int UserId { get; set; }*/
        public string NomUser { get; set; }
        public string PrenomUser { get; set; }
        public bool QuestionLibre { get; set; } //true oui oui et false pour non
        public int NombreQuestion { get; set; } //nombre de questions à intégrer au quizz
        #endregion
        #region Association
        public virtual Technologie Technologie { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        #endregion
    }
}
