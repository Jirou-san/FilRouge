using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class QuestionModel
    {
        public int QuestionId { get; set; }
        //[Display(Name = "Question", Prompt = "Entrez une question", Description = "Question unique ou multiple")]
        [DisplayName("Question")]
        [MinLength(1)]
        [MaxLength(250)]
        //Aussi annoté dans le code first de la base de données
        public string Content { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public List<Response> Reponses { get; set; }

    }
    //Classe partielle Map servant à passer d'un viewModel à un Model et inversement
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
            question.QuestionTypeId = Int32.Parse(questionVM.Type);

            return question;
        }
    }
}