using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace FilRouge.Service
{
    /// <summary>
    /// Classe d'exception permettant de gérer la selection d'un quizz par id
    /// </summary>
    public sealed class NotFoundException : Exception
    {
        public string _msg;
        public NotFoundException(string message) : base(message)
        {
            _msg = message;
        }
    }

    public sealed class CustomDbUpdateException : DbUpdateException
    {
        public string _msg;

        public CustomDbUpdateException(DbUpdateException dbUpdateException, string message) : base(message)
        {
            var sqlException = dbUpdateException.GetBaseException() as SqlException;

            switch (sqlException.Number)
            {
                case 547:
                    this._msg = ($"{message}, car utilisé par un autre enregistrement");
                    break;
                default:
                    this._msg = "Exception non géré";
                    break;
                    //TODO !!!
            }
        }
    }

    public sealed class FkConstraintException : Exception
    {
        public string _msg;
        public FkConstraintException(string message) : base(message)
        {
            _msg = message;
        }
    }

    /// <summary>
    /// Classe d'exception permettant de gérer la selection de tous les quizz si jamais elle est vide
    /// </summary>
    //public sealed class ListQuizzEmpty : Exception Commenté par marc pour faire des tests. Cette modif ne doit pas être remontée
    //{
    //    public string _msg;
    //    public ListQuizzEmpty(string message) : base(message)
    //    {
    //        _msg = message;
    //    }
    //}
    //public sealed class AlreadyInTheQuestionsList : Exception
    //{
    //    public string _msg;
    //    public AlreadyInTheQuestionsList(string message) : base(message)
    //    {
    //        _msg = message;
    //    }
    //}
    //public sealed class NoQuestionsForYou : Exception
    //{
    //    public string _msg;
    //    public NoQuestionsForYou(string message) : base(message)
    //    {
    //        _msg = message;
    //    }
    //}

}
