using System;

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

    #region Not Found (by id)
    /// <summary>
    /// Handle difficulty not found (by id) error
    /// </summary>
    public sealed class DifficultyNotFound : Exception
    {
        public string _msg;
        public DifficultyNotFound(int id)
        {
            _msg = string.Format($"No difficulty found with the id: {id}");
        }
    }

    /// <summary>
    /// Handle technology not found (by id) error
    /// </summary>
    public sealed class TechnologyNotFound : Exception
    {
        public string _msg;
        public TechnologyNotFound(int id)
        {
            _msg = string.Format($"No technology found with the id: {id}");
        }
    }

    /// <summary>
    /// Handle question not found (by id) error
    /// </summary>
    public sealed class QuestionNotFoundExeption : Exception
    {
        public string _msg;
        public QuestionNotFoundExeption(int id)
        {
            _msg = string.Format($"No question found with the id: {id}");
        }
    }

    /// <summary>
    /// Handle question not found (by quizzId) error
    /// </summary>
    public sealed class QuestionsNotFoundException : Exception
    {
        public string _msg;
        public QuestionsNotFoundException(int idQuizz)
        {
            _msg = string.Format($"No question found for the quizz id: {idQuizz}");
        }
    }
    #endregion


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
    public sealed class AlreadyInTheQuestionsList : Exception
    {
        public string _msg;
        public AlreadyInTheQuestionsList(string message) : base(message)
        {
            _msg = message;
        }
    }
    public sealed class NoQuestionsForYou : Exception
    {
        public string _msg;
        public NoQuestionsForYou(string message) : base(message)
        {
            _msg = message;
        }
    }

}
