using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserQuizzModel
    {
        public int StateQuizz { get; set; }
        public string Technology { get; set; }
        public int QuestionCount { get; set; }
        [DisplayName("Nom")]
        public string UserLastname { get; set; }
        [DisplayName("Prénom")]
        public string UserFirstname { get; set; }
    }
    //Classe partielle Map servant à passer d'un viewModel à un Model et inversement
    public static partial class Map
    {
        public static UserQuizzModel MapToQuizzModel(this Quizz Quizz)
        {
            var QuizzModel = new UserQuizzModel();
            if (Quizz == null)
            {
                return QuizzModel;
            }

            QuizzModel = new UserQuizzModel
            {
                QuestionCount = Quizz.QuestionCount,
                Technology = Quizz.Technology.Name,
                UserFirstname = Quizz.UserFirstName,
                UserLastname = Quizz.UserLastName,
            };
            return QuizzModel;
        }

        //public static Quizz MapToQuizz(this UserQuizzModel QuizzModel)
        //{
        //    var Quizz = new Quizz();


        //    Quizz = new Quizz
        //    {
        //        UserLastName = QuizzModel.UserLastname,
        //        UserFirstName = QuizzModel.UserFirstname,
        //        QuestionCount = QuizzModel.QuestionCount,
        //    };
        //    return Quizz;
        //}
    }
}
