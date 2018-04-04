using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Contact
    {
        #region Proporties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(30)]
        [Required]
        public string Mail { get; set; }

        [Required]
        public bool Type { get; set; } //0 for admin & 1 for agent
        #endregion
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        #endregion
    }
}

