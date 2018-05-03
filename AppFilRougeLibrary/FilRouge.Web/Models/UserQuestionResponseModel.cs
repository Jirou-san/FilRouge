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

        public int UserQuestionQuizzId { get; set; }

        public string Content { get; set; }
        public ICollection<Response> Responses { get; set; }

        public List <UserResponse> UserResponses{ get; set; }
        public bool IsFreeAnswer { get; set; }

        [DisplayName("Commentaire")]
        public string Comment { get; set; }
        public bool RefuseToAnswer { get; set; }
    }

    public static partial class Map
    {

        public static QuestionQuizz MapToQuestionQuizz(this UserQuestionResponseModel questionResponseQuizzModel)
        {
            var question = new QuestionQuizz();

            question.Id = questionResponseQuizzModel.UserQuestionQuizzId;
            question.Question.Content = questionResponseQuizzModel.Content;
            question.Question.IsFreeAnswer =questionResponseQuizzModel.IsFreeAnswer;
            question.RefuseToAnswer = questionResponseQuizzModel.RefuseToAnswer;
            question.Question.Responses = questionResponseQuizzModel.Responses;
            question.UserResponses = questionResponseQuizzModel.UserResponses;
            question.Comment = questionResponseQuizzModel.Comment;

            return question;

        }

        public static UserQuestionResponseModel MapToquestionResponseQuizzModel(this QuestionQuizz questionQuizz)
        {
            var questionResponseQuizzModel = new UserQuestionResponseModel();
            if (questionQuizz == null)
            {
                return questionResponseQuizzModel;
            }
            questionResponseQuizzModel.UserQuestionQuizzId = questionQuizz.Id;
            questionResponseQuizzModel.Content = questionQuizz.Question.Content;
            questionResponseQuizzModel.IsFreeAnswer = questionQuizz.Question.IsFreeAnswer;
            questionResponseQuizzModel.RefuseToAnswer = questionQuizz.RefuseToAnswer;
            questionResponseQuizzModel.Responses = questionQuizz.Question.Responses;
            questionResponseQuizzModel.UserResponses = questionQuizz.UserResponses;
            questionResponseQuizzModel.Comment = questionQuizz.Comment;

            return questionResponseQuizzModel;

        }
    }
}

