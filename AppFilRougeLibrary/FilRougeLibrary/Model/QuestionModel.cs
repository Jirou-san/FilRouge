using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Entities.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FilRouge.Entities.Model;
    using FilRouge.Model.Entities;

    public class QuestionModel
    {
        public int QuestionId { get; set; }
        [DisplayName("Question:")]
        public string Content { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
    }

    public static partial class Map
    {
        public static QuestionModel MapToQuestionModel(this Question question)
        {
            var questionModel = new QuestionModel();
            if (question == null)
            {
                return questionModel;
            }

            questionModel = new QuestionModel
             {
                 Content = question.Content
                 
             };
            return questionModel;
        }

        public static Question MapToQuestion(this QuestionModel questionModel)
        {
            var question = new Question();
            if (questionModel == null)
            {
                return question;
            }

            question = new Question
            {
                 Commentaire = questionModel.Comment

            };
            return question;
        }
    }
}
