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
        public virtual List<Questions> Question { get; set; }
        #endregion
    }
}
