﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Entities.Entities;

namespace FilRouge.Entities.Entities
{

    public partial class Technology
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.IdEntities)]
        public int TechnoId { get; set; }
        public string TechnoName { get; set; }
        public bool Active { get; set; }

        #endregion
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        public virtual List<Questions> Questions { get; set; }
        #endregion
    }
}
