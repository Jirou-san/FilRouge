using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Library.Datas
{
    class Reponse
    {
        #region Properties
        private int _ReponseId;
        private string _Content;
        private int _QuestionId;
        #endregion
        #region Accesseurs
        public int ReponseId { get => _ReponseId; set => _ReponseId = value; }
        public string Content { get => _Content; set => _Content = value; }
        public int QuestionId { get => _QuestionId; set => _QuestionId = value; }
        #endregion
    }
}
