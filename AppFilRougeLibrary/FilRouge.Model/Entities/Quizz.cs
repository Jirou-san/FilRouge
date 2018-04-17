using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public enum QuizzStateEnum
    {
        NotStarted=0,
        InProgress=1,
        Done=2,
    }//0 for not started, 1 for in progress, 2 for done

    public partial class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }
        [ForeignKey("Contact")]
        public string ContactId { get; set; }
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }
        [Required]
        public QuizzStateEnum QuizzState { get; set; } 
        [MaxLength(20)]
        [Required]
        public string UserLastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string UserFirstName { get; set; }
        public bool HasFreeQuestion { get; set; } //true for yes & false for no
        [Required]
        public int QuestionCount { get; set; } //number of questions for the current quizz
        public string ExternalNum { get; set; }
        public int ActiveQuestionNum { get; set; }

        #endregion
        #region Association

        public virtual Technology Technology { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        #endregion
    }
}
