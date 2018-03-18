using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public virtual ICollection<Quizz> Quizz { get; set; }
        #endregion

    }
}

