using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Model.Models
{


    public class QuestionModel
    {
        public int QuestionId { get; set; }
        //[Display(Name = "Question", Prompt = "Entrez une question", Description = "Question unique ou multiple")]
        [DisplayName("Question:")]
        public string Content { get; set; }
        //public string Comment { get; set; }
        public bool Active { get; set; }
        public string Difficulty { get; set; }
        public string Technology { get; set; }
        public string Type { get; set; }
        public List<Response> Reponses { get; set; }

    }

    public static partial class Map
    {
        public static QuestionModel MapToQuestionViewModelFull(this Question question)
        {
            var questionVM = new QuestionModel();

            if (question == null)
                return questionVM;

            questionVM.Reponses = new List<Response>();

            questionVM.QuestionId = question.QuestionId;
            questionVM.Content = question.Content;
            questionVM.Reponses = question.Responses.ToList();
            questionVM.Difficulty = question.DifficultyId.ToString();
            questionVM.Technology = question.TechnologyId.ToString();
            questionVM.Type = question.QuestionTypeId.ToString();

            return questionVM;
        }

        public static QuestionModel MapToQuestionModel(this Question question)
        {
            var questionVM = new QuestionModel();

            if (question == null)
                return questionVM;

            questionVM.QuestionId = question.QuestionId;
            questionVM.Content = question.Content;
            questionVM.Difficulty = question.Difficulty.DifficultyName;
            questionVM.Technology = question.Technology.TechnoName;
            questionVM.Type = question.TypeQuestion.NameType;
            return questionVM;
        }



        public static Question MapToQuestion(this QuestionModel questionVM)
        {
            var question = new Question();
            if (questionVM == null)
            {
                return question;
            }
            question.Content = questionVM.Content;
            question.DifficultyId = Int32.Parse(questionVM.Difficulty);
            question.TechnologyId = Int32.Parse(questionVM.Technology);
            question.QuestionTypeId = Int32.Parse(questionVM.Type);

            return question;
        }
    }
}