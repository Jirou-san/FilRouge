using System;
using System.Collections.Generic;
using System.Text;
using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;

namespace FilRouge.HttpHandler
{
    public class HttpQuestionQuizz
    {
        public HttpQuestionQuizz()
        {

        }
        public List<QuestionQuizz> GetQuestionQuizz(int quizzid, string username, string password)
        {
            var response = new List<QuestionQuizz>();
            try
            {
                HttpRequestHandler requestHandler = new HttpRequestHandler($"http://localhost:81/api/questionquizz");
                requestHandler.Login(username, password);
                response = requestHandler.client.GetAsync<List<QuestionQuizz>>($"{requestHandler.baseUri}", requestHandler._token).Result;

            }
            catch (Exception e)
            {
            }

           return response;
        }

        public QuestionQuizz GetQuestionQuizzById(int idQuestionQuizz)
        {
            throw new NotImplementedException();
        }

        public int AddQuestionQuizz(QuestionQuizz questionQuizz)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestionQuizz(int idQuestionQuizz)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestionQuizz(QuestionQuizz questionQuizz)
        {
            throw new NotImplementedException();
        }
    }
}