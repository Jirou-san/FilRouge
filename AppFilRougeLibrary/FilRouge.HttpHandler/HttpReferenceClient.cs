using System;
using System.Collections.Generic;
using System.Text;
namespace FilRouge.HttpHandler
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    class HttpReferenceClient : IReferenceService
    {
        public List<Difficulty> GetAllDifficuties()
        {
            HttpRequestHandler requestHandler = new HttpRequestHandler($"http://localhost:81/api/quizz");

            var response = requestHandler.client.PostAsJsonAsync<Room>(finalUri, room, _token).Result;
            if (response == null)
            {
                throw new ExceptionCreate("Ajout impossible");
            }
            return response;
        }

        public List<Technology> GetAllTechnologies()
        {
            throw new NotImplementedException();
        }

        public Difficulty GetDifficulty(int id)
        {
            throw new NotImplementedException();
        }

        public Technology GetTechnology(int id)
        {
            throw new NotImplementedException();
        }
    }
}
