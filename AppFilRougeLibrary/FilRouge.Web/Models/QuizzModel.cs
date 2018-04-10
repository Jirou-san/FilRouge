﻿using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class QuizzModel
    {
        public int StateQuizz { get; set; }
        public int TechnologyId { get; set; }
        public int QuestionCount { get; set; }
        [DisplayName("Lastname")]
        [MinLength(1)]
        [MaxLength(20)]
        public string UserLastname { get; set; } // Nom
        [DisplayName("Firstname")]
        [MinLength(1)]
        [MaxLength(20)]
        public string UserFirstname { get; set; } // Prénom
    }
    //Classe partielle Map servant à passer d'un viewModel à un Model et inversement
    public static partial class Map
    {
        public static QuizzModel MapToQuizzModel(this Quizz Quizz)
        {
            var QuizzModel = new QuizzModel();
            if (Quizz == null)
            {
                return QuizzModel;
            }

            QuizzModel = new QuizzModel
             {
                 QuestionCount = Quizz.QuestionCount,
                 TechnologyId = Quizz.TechnologyId,
                 UserFirstname = Quizz.UserFirstName,
                 UserLastname = Quizz.UserLastName
                    
             };
            return QuizzModel;

        }

        public static Quizz MapToQuizz(this QuizzModel QuizzModel)
        {
            var Quizz = new Quizz();
            if (QuizzModel == null)
            {
                return Quizz;
            }

            Quizz = new Quizz
            {
                UserLastName = QuizzModel.UserLastname,
                UserFirstName = QuizzModel.UserFirstname,
                QuestionCount = QuizzModel.QuestionCount,
                TechnologyId = QuizzModel.TechnologyId
            };
            return Quizz;
        }
    }
}
