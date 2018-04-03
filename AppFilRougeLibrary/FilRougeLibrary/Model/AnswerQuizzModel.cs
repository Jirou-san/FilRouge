using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Entities.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FilRouge.Model.Entities;

    public class AnswerQuizzModel
    {
        

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
                                    Content = questionModel.Content
            };
            return question;
        }
    }
}
