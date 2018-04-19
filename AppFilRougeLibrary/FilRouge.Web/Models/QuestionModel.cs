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
        [Required]
        public string Content { get; set; }
        public Technology Technology { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<string> Comments { get; set; }
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

            questionVM.QuestionId = question.Id;
            questionVM.Content = question.Content;
            questionVM.Technology = question.Technology;
            questionVM.Difficulty = question.Difficulty;

            // les commentaires depuis questionQuizz qui est associé a userReponse)
            questionVM.Comments = question.UserResponses.Select(o=>o.QuestionQuizz.Comment).ToList();
            questionVM.Reponses = question.Responses.ToList();

            return questionVM;
        }

        public static QuestionModel MapToQuestionModel(this Question question)
        {
            var questionVM = new QuestionModel();

            if (question == null)
                return questionVM;

            questionVM.QuestionId = question.Id;
            questionVM.Content = question.Content;

            questionVM.Reponses = question.Responses.ToList();

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

            return question;
        }
    }
}