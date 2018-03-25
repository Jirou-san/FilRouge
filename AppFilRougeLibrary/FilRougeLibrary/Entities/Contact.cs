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
    public partial class Contact
    {
        #region Proporties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        #endregion
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        #endregion

    }
}

