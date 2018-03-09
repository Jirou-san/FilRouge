using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Library
{
    public class Questions
    {
        #region Properties
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public string Commentaire { get; set; }
        public bool Active { get; set; }
        public int QuestionType { get; set; }
        public string Difficulty { get; set; }
        public static int CompteurQuestions { get; set; }
        public int TechnoId { get; set; }
        #endregion
        #region Association
        #endregion
    }
}
