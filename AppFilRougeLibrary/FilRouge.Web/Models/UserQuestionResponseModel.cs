using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FilRouge.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilRouge.Web.Models
{
    public struct UserQuestionResponseModel
    {

        public int UserQuizzId { get; set; }
        public int QuestionId { get; set; }
        public int Id { get; set; }

        public string Content { get; set; }
        public ICollection<Response> Responses { get; set; }

        public List <UserResponse> UserResponses{ get; set; }
        public bool IsFreeAnswer { get; set; }

        [DisplayName("Commentaire")]
        public string Comment { get; set; }
        public bool RefuseToAnswer { get; set; }
        public string FreeAnswer { get; set; }
        public int DisplayNum { get; set; }
    }

    public static partial class Map
    {

        public static QuestionQuizz MapToQuestionQuizz(this UserQuestionResponseModel questionResponseQuizzModel)
        {
            var question = new QuestionQuizz();
            question.Id = questionResponseQuizzModel.Id;
            question.Comment = questionResponseQuizzModel.Comment;

            if (questionResponseQuizzModel.FreeAnswer!=null)
                question.FreeAnswer = questionResponseQuizzModel.FreeAnswer;

            question.QuestionId = questionResponseQuizzModel.QuestionId;
            question.QuizzId = questionResponseQuizzModel.UserQuizzId;
            question.RefuseToAnswer = questionResponseQuizzModel.RefuseToAnswer;
            question.DisplayNum = questionResponseQuizzModel.DisplayNum;
            
            question.UserResponses = questionResponseQuizzModel.UserResponses;

            return question;

        }

        public static UserQuestionResponseModel MapToquestionResponseQuizzModel(this QuestionQuizz questionQuizz)
        {
            var questionResponseQuizzModel = new UserQuestionResponseModel();
            if (questionQuizz == null)
            {
                return questionResponseQuizzModel;
            }
            questionResponseQuizzModel.Id = questionQuizz.Id;

            questionResponseQuizzModel.UserQuizzId = questionQuizz.Id;
            questionResponseQuizzModel.Content = questionQuizz.Question.Content;
            questionResponseQuizzModel.IsFreeAnswer = questionQuizz.Question.IsFreeAnswer;
            questionResponseQuizzModel.RefuseToAnswer = questionQuizz.RefuseToAnswer;
            questionResponseQuizzModel.Responses = questionQuizz.Question.Responses;
            questionResponseQuizzModel.UserResponses = questionQuizz.UserResponses;
            questionResponseQuizzModel.Comment = questionQuizz.Comment;
            questionResponseQuizzModel.DisplayNum = questionQuizz.DisplayNum;

            return questionResponseQuizzModel;

        }
    }
}

