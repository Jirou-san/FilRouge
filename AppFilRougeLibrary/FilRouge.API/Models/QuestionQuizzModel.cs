using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilRouge.Model.Entities;

namespace FilRouge.API.Models
{
    public struct QuestionQuizzModel
    {
        public string Comment { get; set; }
        public int DisplayNum { get; set; }
        public string FreeAnswer { get; set; }
        public int QuizzId { get; set; }
        public int QuestionId { get; set; }
        public bool RefuseToAnswer { get; set; }
        public List<UserResponse> UserResponses { get; set; } 
    }

    public partial class Map
    {
        public QuestionQuizz MapToQuestionQuizz(QuestionQuizzModel questionQuizzVM)
        {
            var questionQuizz = new QuestionQuizz();
 
            questionQuizz.Comment = questionQuizzVM.Comment;
            questionQuizz.DisplayNum = questionQuizzVM.DisplayNum;
            questionQuizz.FreeAnswer = questionQuizzVM.FreeAnswer;
            questionQuizz.QuizzId = questionQuizzVM.QuizzId;
            questionQuizz.QuestionId = questionQuizzVM.QuestionId;
            questionQuizz.RefuseToAnswer = questionQuizzVM.RefuseToAnswer;
            questionQuizz.UserResponses = questionQuizzVM.UserResponses;

            return questionQuizz;
        }

        public QuestionQuizzModel MapToQuestionQuizz(QuestionQuizz questionQuizz)
        {
            var questionQuizzVM = new QuestionQuizzModel();
            if (questionQuizz == null)
            {
                return questionQuizzVM;
            }
            questionQuizzVM.Comment = questionQuizz.Comment;
            questionQuizzVM.DisplayNum = questionQuizz.DisplayNum;
            questionQuizzVM.FreeAnswer = questionQuizz.FreeAnswer;
            questionQuizzVM.QuizzId = questionQuizz.QuizzId;
            questionQuizzVM.QuestionId = questionQuizz.QuestionId;
            questionQuizzVM.RefuseToAnswer = questionQuizz.RefuseToAnswer;
            questionQuizzVM.UserResponses = questionQuizz.UserResponses;

            return questionQuizzVM;
        }
    }
}