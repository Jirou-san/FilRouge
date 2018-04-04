using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    public partial class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzId { get; set; }
        [Required]
        public int QuizzState { get; set; } //0 for not started, 1 for in progress, 2 for done
        [MaxLength(20)]
        [Required]
        public string UserLastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public bool HasFreeQuestion { get; set; } //0 for yes & 1 for no
        [Required]
        public int QuestionCount { get; set; } //number of questions for the current quizz
        //Clés étrangères
        [ForeignKey("Technology")]
        public int TechnologyId {get; set;}
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }
        #endregion
        #region Association

        public virtual Technology Technology { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        #endregion
    }
}
