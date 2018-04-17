using System;
using System.Collections.Generic;
using System.Text;
namespace FilRouge.HttpHandler
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    class HttpQuizzClient : IReferenceService
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
    }
}
