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
        
        public int TechnologyId { get; set; }

        
        public int DifficultyId { get; set; }

        [MaxLength(300)]
        
        public string Content { get; set; }
        [MaxLength(500)]
        public bool IsEnable { get; set; }
        public bool IsFreeAnswer { get; set; } // True pour libre et False pour pas libre
        public ICollection<Response> Responses { get; set; }
    }
    public partial class Map
    {
        public QuestionModel MapToQuestionModel(Question question)
        {
            var questionVM = new QuestionModel();
            if (question == null)
            {
                return questionVM;
            }
            questionVM.Content = question.Content;
            questionVM.DifficultyId = question.DifficultyId;
            questionVM.IsEnable = question.IsEnable;
            questionVM.IsFreeAnswer = question.IsFreeAnswer;
            questionVM.TechnologyId = question.TechnologyId;
            questionVM.Responses = question.Responses;

            return questionVM;
        }
        public Question MapToQuestion(QuestionModel questionVM)
        {
            var question = new Question();

            question.Content = questionVM.Content;
            question.DifficultyId = questionVM.DifficultyId;
            question.IsEnable = questionVM.IsEnable;
            question.IsFreeAnswer = questionVM.IsFreeAnswer;
            question.TechnologyId = questionVM.TechnologyId;
            question.Responses = questionVM.Responses;

            return question;
        }
    }
}
