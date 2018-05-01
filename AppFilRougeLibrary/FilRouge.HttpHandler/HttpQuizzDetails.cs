using System;
using System.Collections.Generic;
using System.Text;
using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;

namespace FilRouge.HttpHandler
{
    class  HttpQuizzDetails: IQuizzService
    {
        public int CreateQuizz(string userId, int technologyId, int difficultyId, string userLastName, string userFirstName,
            string externalNum, int numberQuestions, int freeAnswerMax = 0, int freeAnswerMin = 0)
        {
            throw new NotImplementedException();
        }

        public Quizz GetQuizById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Quizz> GetAllQuizz()
        {
            throw new NotImplementedException();
        }

        public List<Quizz> GetAllQuizz(Contact agent)
        {
            throw new NotImplementedException();
        }

        public List<Quizz> GetQuizz(Quizz quizzFilter)
        {
            throw new NotImplementedException();
        }

        public List<QuestionQuizz> GetQuestionQuizz(int quizzid)
        {
            HttpRequestHandler requestHandler = new HttpRequestHandler($"http://localhost:81/api/quizz");
            string finalUri = $"{requestHandler.baseUri}/";
            var response = requestHandler.client.GetAsync<QuestionQuizz>(finalUri, requestHandler.).Result;
            if (response == null)
            {
                throw new ExceptionCreate("Ajout impossible");
            }
            return response;
        }
    }
}
