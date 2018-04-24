using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class QuestionModels
    {
        public int QuestionId { get; set; }
        //[Display(Name = "Question", Prompt = "Entrez une question", Description = "Question unique ou multiple")]
        [DisplayName("Question")]
        [MinLength(1)]
        [MaxLength(250)]
        //Aussi annoté dans le code first de la base de données
        [Required]
        public string Content { get; set; }
        public bool IsEnable { get; set; }

        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }

        public int DifficultyId { get; set; }
        public string DifficultyName { get; set; }

        public List<string> Comments { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
    //Classe partielle Map servant à passer d'un viewModel à un Model et inversement
    public static partial class Map
    {
        public static QuestionModels MapToQuestionViewModelFull(this Question question)
        {
            var questionVM = new QuestionModels();

            if (question == null)
                return questionVM;

            questionVM.Responses = new List<Response>();

            questionVM.QuestionId = question.Id;
            questionVM.Content = question.Content;
            questionVM.TechnologyId = question.Technology.Id;
            questionVM.DifficultyId = question.DifficultyId;
            questionVM.IsEnable = question.IsEnable;

            // les commentaires depuis questionQuizz qui est associé a userReponse)
            questionVM.Comments = question.UserResponses.Select(o=>o.QuestionQuizz.Comment).ToList();
            questionVM.Responses = question.Responses;

            return questionVM;
        }

        public static QuestionModels MapToQuestionModel(this Question question)
        {
            var questionVM = new QuestionModels();

            if (question == null)
                return questionVM;

            questionVM.QuestionId = question.Id;
            questionVM.Content = question.Content;
            questionVM.DifficultyId = question.DifficultyId;
            questionVM.DifficultyName = question.Difficulty.Name;
            questionVM.TechnologyId = question.TechnologyId;
            questionVM.TechnologyName = question.Technology.Name;
            questionVM.Responses = question.Responses;
            questionVM.IsEnable = question.IsEnable;

            return questionVM;
        }

        public static Question MapToQuestion(this QuestionModels questionVM)
        {
            var question = new Question();
            if (questionVM == null)
            {
                return question;
            }
            question.Content = questionVM.Content;
            question.DifficultyId = questionVM.DifficultyId;
            question.TechnologyId =  questionVM.TechnologyId;
            question.IsEnable = questionVM.IsEnable;
            question.Responses = questionVM.Responses;

            return question;
        }
    }
}