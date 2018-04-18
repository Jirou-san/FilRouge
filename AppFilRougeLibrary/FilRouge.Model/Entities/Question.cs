    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Question
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }

        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Content { get; set; }
        public bool IsEnable { get; set; }
        public bool IsFreeAnswer { get; set; } // True pour libre et False pour pas libre

        
        #endregion
        #region Association
        public virtual ICollection<UserResponse> UserResponses { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual Technology Technology{ get; set; }
        public virtual Difficulty Difficulty{ get; set; }
        #endregion
    }
}
