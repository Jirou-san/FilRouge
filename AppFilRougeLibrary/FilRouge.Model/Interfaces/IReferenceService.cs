namespace FilRouge.Model.Interfaces
{
    using System.Collections.Generic;

    using FilRouge.Model.Entities;

    public interface IReferenceService
    {
        #region Question
        Question GetQuestion(int id);
        List<Question> GetAllQuestions();
        int AddQuestion(Question question);
        int DeleteQuestion(int id);
        Question ShowQuestion(int id);
        List<Question> GetQuestionsByQuizz(int idQuizz);
        #endregion

        #region Response
        Response GetResponse(int id);
        List<Response> GetAllResponses();
        int AddResponse(Response response, int idQuestion);

        int DeleteResponse(int id);
        List<Response> GetAllResponseByQuizz(int idQuizz);
        #endregion

        #region Technology
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnologies();
        #endregion

        #region Difficulty
        Difficulty GetDifficulty(int id);
        List<Difficulty> GetAllDifficuties();
        #endregion

        #region Quizz

        #endregion

    }
}
