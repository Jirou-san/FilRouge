﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilRouge.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public struct QuizzModel
    {
        public int Id { get; set; }
        [Required]
        public int TechnologyId { get; set; }
        [Required]
        public string ContactId { get; set; }
        [Required]
        public int DifficultyId { get; set; }
        public int QuizzState { get; set; } //0 for not started, 1 for in progress, 2 for done
        [MaxLength(20)]
        [Required]
        public string UserLastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string UserFirstName { get; set; }
        public bool HasFreeQuestion { get; set; } //0 for yes & 1 for no
        [Required]
        public int QuestionCount { get; set; } //number of questions for the current quizz

        public string ExternalNum { get; set; }
    }
}