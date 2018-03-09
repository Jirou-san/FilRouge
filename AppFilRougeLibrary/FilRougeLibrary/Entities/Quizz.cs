using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Entities.Entity
{
    public partial class Quizz
    {
        #region Properties
        public int QuizzID { get; set; }
        public DateTime Timer { get; set; } //Timer en minutes pour la durée du quizz
        public int EtatQuizz { get; set; } //Indique si le quizz non-fait, en cours ou terminé
        public string Difficulty { get; set; }
        public int TechnoId { get; set; }
        public int UserId { get; set; }
        public string NomUser { get; set; }
        public string PrenomUser { get; set; }
        public bool QuestionLibre { get; set; } //true oui oui et false pour non
        public int NombreQuestion { get; set; } //nombre de questions à intégrer au quizz
        #endregion
        #region Association
        #endregion
    }
}
