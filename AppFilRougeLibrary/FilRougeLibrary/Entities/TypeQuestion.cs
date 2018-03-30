using System.Collections.Generic;

namespace FilRouge.Model.Entities
{
    public partial class TypeQuestion
    {
        #region Properties
        public int TypeQuestionId { get; set; }
        public string NameType { get; set; }

        #endregion
        #region Association
        public virtual List<Question> Question { get; set; }
        #endregion
    }
}
