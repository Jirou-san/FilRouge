using System;
using System.Collections.Generic;
using System.Text;

namespace FilRouge.HttpHandler
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;
    class HttpQuestionClient : IReferenceService
    {
        public Question GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public int AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public int DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Question ShowQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsByQuizz(int quizzId)
        {
            throw new NotImplementedException();
        }

        public Response GetResponse(int id)
        {
            throw new NotImplementedException();
        }

        public List<Response> GetAllResponses()
        {
            throw new NotImplementedException();
        }

        public int AddResponse(Response response, int idQuestion)
        {
            throw new NotImplementedException();
        }

        public int DeleteResponse(int id)
        {
            throw new NotImplementedException();
        }

        public List<Response> GetAllResponseByQuizz(int idQuizz)
        {
            throw new NotImplementedException();
        }

        public Technology GetTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public List<Technology> GetAllTechnologies()
        {
            throw new NotImplementedException();
        }

        public Difficulty GetDifficulty(int id)
        {
            throw new NotImplementedException();
        }

        public List<Difficulty> GetAllDifficuties()
        {
            throw new NotImplementedException();
        }

        public int AddTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }

        public int DeleteTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }

        public int AddDifficulty(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }

        public int DeleteDifficulty(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateDifficulty(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }

        public DifficultyRate GetDifficultyRate(int id)
        {
            throw new NotImplementedException();
        }

        public List<DifficultyRate> GetAllDifficultyRates()
        {
            throw new NotImplementedException();
        }

        public int AddDifficultyRate(DifficultyRate difficultyrate)
        {
            throw new NotImplementedException();
        }

        public int DeleteDifficultyRate(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateDifficultyRate(DifficultyRate difficultyRate)
        {
            throw new NotImplementedException();
        }
    }
}
