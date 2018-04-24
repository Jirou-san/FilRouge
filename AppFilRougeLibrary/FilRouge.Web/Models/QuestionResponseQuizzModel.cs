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
    public class QuestionResponseQuizzModel
    {

        public int QuestionQuizzId { get; set; }

        public int QuizzId { get; set; }

        public int QuestionId { get; set; }

        public bool FreeAnswer { get; set; }
        [DisplayName("Commentaire")]
        public string Comment { get; set; }

        public bool RefuseToAnswer { get; set; }
    }
}