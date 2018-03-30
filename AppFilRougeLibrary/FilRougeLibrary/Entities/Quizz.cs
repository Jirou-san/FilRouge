using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FilRouge.Model.Entity;

namespace FilRouge.Model.Entity
{
    public partial class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzId { get; set; }
        public int Timer { get; set; } //Timer en minutes pour la durée du quizz
        public int EtatQuizz { get; set; } //Indique si le quizz non-fait, en cours ou terminé
        public string NomUser { get; set; }
        public string PrenomUser { get; set; }
        public bool QuestionLibre { get; set; } //true oui et false pour non
        public int NombreQuestion { get; set; } //nombre de questions à intégrer au quizz
        //Clés étrangères
        [ForeignKey("DifficultyMaster")]
        public int DifficultyMasterId { get; set; }
        [ForeignKey("Technology")]
        public int TechnologyId {get; set;}
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        #endregion
        #region Association

        public virtual DifficultyMaster DifficultyMaster { get; set; }
        public virtual Technology Technology { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual List<Questions> Questions { get; set; }

        #endregion
    }
}
