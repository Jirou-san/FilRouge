using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Entities.Models
{
    using FilRouge.Model.Entities;

    class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Comment { get; set; }
        public int DifficultyId { get; set; }
        public bool Active { get; set; }
    }

    public static partial class Mapping
    {
        public static QuestionModel MapToQuestionModel(this Questions question)
        {

        }
    }
}
