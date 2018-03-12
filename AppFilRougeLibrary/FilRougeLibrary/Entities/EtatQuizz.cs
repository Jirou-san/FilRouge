using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Entities.Entities
{
    class EtatQuizz
    {
        #region Proporties
        [Key, Column(Order = 0)]
        public int QuizzId { get; set; }
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        #endregion
        #region Associations
        #endregion
    }
}
