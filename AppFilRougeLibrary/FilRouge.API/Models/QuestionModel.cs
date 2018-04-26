using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilRouge.API.Models
{
    using System.ComponentModel.DataAnnotations;

    using FilRouge.Model.Entities;

    #region Question
    public struct QuestionModel
    {
        
        public int TechnologyId { get; set; }

        public int DifficultyId { get; set; }


        [MaxLength(500)]
        public string Content { get; set; }

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
        #endregion
    }
    public struct ResponseModel
    {

        public int QuestionId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Content { get; set; }
        public string Explanation { get; set; }

        public bool IsTrue { get; set; }
        public Question Question { get; set; }
    }
    public partial class Map
    {
        public Response MapToResponse (ResponseModel responseVM)
        {
            var response = new Response();

            response.Content = responseVM.Content;
            response.Explanation = responseVM.Explanation;
            response.IsTrue = responseVM.IsTrue;
            response.QuestionId = responseVM.QuestionId;
            response.Question = responseVM.Question;

            return response;
        }

        public ResponseModel MapToResponse(Response response)
        {
            var responseVM = new ResponseModel();

            if(response==null)
            {
                return responseVM;
            }

            responseVM.Content = response.Content;
            responseVM.Explanation = response.Explanation;
            responseVM.IsTrue = response.IsTrue;
            responseVM.QuestionId = response.QuestionId;
            responseVM.Question = response.Question;

            return responseVM;
        }
    }
}
