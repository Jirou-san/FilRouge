using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Model.Entities
{
    public partial class TypeQuestion
    {
        #region Properties
        public int TypeQuestionId { get; set; }
        [MaxLength(20)]
        [Required]
        public string NameType { get; set; }

        #endregion
        #region Association
        public virtual List<Question> Question { get; set; }
        #endregion
    }
}
