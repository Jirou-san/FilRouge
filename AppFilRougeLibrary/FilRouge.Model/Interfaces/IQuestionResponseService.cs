﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Model.Interfaces
{
    using FilRouge.Model.Entities;
    /// <summary>
    /// Interface permettant l'implémentaiton de RéférenceService
    /// </summary>
    public interface IQuestionResponseService
    {
        #region Responses
       
        Response GetResponse(int id);

        List<Response> GetAllResponses();
        int AddResponse(Response response, int idQuestion);
        bool UpdateResponse(Response response);
        int DeleteResponse(int id);
        List<Response> GetAllResponseByQuizz(int idQuizz);
        
        #endregion

        #region Question
        Question GetQuestion(int id);
        List<Question> GetAllQuestions();
        int AddQuestion(Question question);
        int DeleteQuestion(int id);
        bool UpdateQuestion(Question question);
        //Ne perçoit pas trop l'utilisé pour le moment, à expliquer ty
        Question ShowQuestion(int id);
        List<Question> GetQuestionsByQuizz(int idQuizz);
        #endregion
    }
}

