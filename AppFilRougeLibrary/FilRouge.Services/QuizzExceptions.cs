using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Services
{
    /// <summary>
    /// Classe d'exception permettant de gérer la selection d'un quizz par id
    /// </summary>
    public sealed class WrongIdQuizz : Exception
    {
        public string _msg;
        public WrongIdQuizz(string message) : base(message)
        {
            _msg = message;
        }
    }
    /// <summary>
    /// Classe d'exception permettant de gérer la selection de tous les quizz si jamais elle est vide
    /// </summary>
    public sealed class ListQuizzEmpty : Exception
    {
        public string _msg;
        public ListQuizzEmpty(string message) : base(message)
        {
            _msg = message;
        }
    }
}
