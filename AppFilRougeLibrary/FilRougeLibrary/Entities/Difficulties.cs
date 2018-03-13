using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entity
{
    public partial class Difficulties
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyId { get; set; }
        public string DifficultyName { get; set; }
        public decimal TauxJunior { get; set; }
        public decimal TauxConfirmed { get; set; }
        public decimal TauxExpert { get; set; }
        #endregion
        #region Associations
        #endregion
    }
}
