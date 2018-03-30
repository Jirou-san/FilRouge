﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
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
        //Clés étrangères
        [ForeignKey("TypeQuestion")]
        public int QuestionTypeId { get; set; }
        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }
        #endregion
        #region Association

        public virtual ICollection<Quizz> Quizzs { get; set; }
        public virtual ICollection<Reponses> Reponses { get; set; }
        public virtual Technology Technology{ get; set; }
        public virtual Difficulty Difficulty{ get; set; }
        public virtual TypeQuestion TypeQuestion { get; set; }
        #endregion
    }
}
