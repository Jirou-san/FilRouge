using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilRouge.API.Models
{
    using System.ComponentModel.DataAnnotations;

    using FilRouge.Model.Entities;

    public struct QuestionModel
    {
        
        public int Id { get; set; }
        [Required]
        public int TechnologyId { get; set; }

        [Required]
        public int DifficultyId { get; set; }

        [MaxLength(300)]
        [Required]
        public string Content { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public bool IsEnable { get; set; }
        public bool IsFreeAnswer { get; set; } // True pour libre et False pour pas libre
        public List<Response> Responses { get; set; }
    }
}
