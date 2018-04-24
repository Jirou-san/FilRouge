using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilRouge.Model.Entities;
namespace FilRouge.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public struct QuizzModel
    {

        public int Id { get; set; }       
        public int TechnologyId { get; set; }        
        public string ContactId { get; set; }       
        public int DifficultyId { get; set; }
        [MaxLength(20)]        
        public string UserLastName { get; set; }
        [MaxLength(20)]       
        public string UserFirstName { get; set; }  
        public int QuestionCount { get; set; } //number of questions for the current quizz
        public string ExternalNum { get; set; }
    }

    public partial class Map
    {
        public QuizzModel MapToQuizzModel(Quizz quizz)
        {
            var quizzVM = new QuizzModel();
            if (quizz == null)
            {
                return quizzVM;
            }

            quizzVM.ContactId = quizz.ContactId;
            quizzVM.DifficultyId = quizz.DifficultyId;
            quizzVM.ExternalNum = quizz.ExternalNum;
            quizzVM.QuestionCount = quizz.QuestionCount;
            quizzVM.TechnologyId = quizz.TechnologyId;
            quizzVM.UserFirstName = quizz.UserFirstName;
            quizzVM.UserLastName = quizz.UserLastName;

            return quizzVM;
        }
        public Quizz MapToQuizz(QuizzModel quizzVM)
        {
            var quizz = new Quizz();

            quizz.ContactId = quizzVM.ContactId;
            quizz.DifficultyId = quizzVM.DifficultyId;
            quizz.ExternalNum = quizzVM.ExternalNum;
            quizz.QuestionCount = quizzVM.QuestionCount;
            quizz.TechnologyId = quizzVM.TechnologyId;
            quizz.UserFirstName = quizzVM.UserFirstName;
            quizz.UserLastName = quizzVM.UserLastName;

            return quizz;
        }
    }

}