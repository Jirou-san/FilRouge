using System;
using System.Collections.Generic;
using System.Text;
namespace FilRouge.HttpHandler
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    class HttpReferenceClient : IReferenceService
    {
        private HttpRequestHandler requestHandler;
        public HttpReferenceClient(string baseUri)
        {
            requestHandler = new HttpRequestHandler(baseUri);
        }

        #region Difficulty
        public int AddDifficulty(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Ajout d'une difficulté 
        /// </summary>
        /// <param name="difficultyrate"></param>
        /// <returns></returns>
        public int AddDifficulty(DifficultyRate difficultyrate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gestionnaire HTTP servant à récupérer toutes les difficultées
        /// </summary>
        /// <returns>La liste des difficultés ou une erreur</returns>
        public List<Difficulty> GetAllDifficuties()
        {
            var response = new List<Difficulty>();
            try
            {
                var finalUri = $"{requestHandler.baseUri}/reference/difficulties";
                response = requestHandler.client.GetAsync<List<Difficulty>>(finalUri, requestHandler.token).Result;
            }
            catch (Exception e)
            {
                return new List<Difficulty>()
                {
                    new Difficulty()
                    {
                        Name = $"{e.Message}",
                    }
                };          
            }
            
            return response;
        }

        /// <summary>
        /// Service HTTP permettant de supprimer une difficulté
        /// </summary>
        /// <param name="id">Id de la difficulté à supprimer</param>
        /// <returns></returns>
        public int DeleteDifficulty(int id)
        {
            int valideResult = 0;
            var finalUri = $"{requestHandler.baseUri}/reference/difficulty/{id}";
            var response = requestHandler.client.DeleteAsync(finalUri, requestHandler.token).Result;
            if(response = true) { valideResult = 1; } else { valideResult = 0; }
            return valideResult;
        }

        public Difficulty GetDifficulty(int id)
        {
            var response = new Difficulty();
            try
            {
                var finalUri = $"{requestHandler.baseUri}/reference/difficulty/{id}";
                response = requestHandler.client.GetAsync<Difficulty>(finalUri, requestHandler.token).Result;
            }
            catch (Exception e)
            {
                return new Difficulty()
                {
                    Name = $"{e.Message}"
                };
            }

            return response;
        }


        public int UpdateDifficulty(Difficulty difficulty)
        {
            var response = new Difficulty();
            try
            {
                var finalUri = $"{requestHandler.baseUri}/reference/difficulty";
                response = requestHandler.client.PatchAsJsonAsync<Difficulty>(requestHandler.client,finalUri, requestHandler.token).Result;
            }
            catch (Exception e)
            {
                
            }
        }
        #endregion

        #region DifficultyRate
        public int DeleteDifficultyRate(int id)
        {
            throw new NotImplementedException();
        }

        public List<DifficultyRate> GetAllDifficultyRates()
        {
            throw new NotImplementedException();
        }

        public DifficultyRate GetDifficultyRate(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateDifficultyRate(DifficultyRate difficultyRate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Technology
        public int DeleteTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public int AddTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }

        

        public List<Technology> GetAllTechnologies()
        {
            throw new NotImplementedException();
        }
        

        public Technology GetTechnology(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateTechnology(Technology technology)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
