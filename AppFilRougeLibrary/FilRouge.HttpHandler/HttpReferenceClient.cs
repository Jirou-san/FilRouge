//Classe permettant d'effectuer des requêtes HTTP et de consommer le service Web
//Celle-ci ne sers uniquement qu'aux données de référence - Partie optionnelle administration mobile

//using System;
//using System.Collections.Generic;
//using System.Text;
//namespace FilRouge.HttpHandler
//{
//    using FilRouge.Model.Entities;
//    using FilRouge.Model.Interfaces;

//    class HttpReferenceClient : IReferenceService
//    {
//        public List<Difficulty> GetAllDifficuties()
//        {
//            HttpRequestHandler requestHandler = new HttpRequestHandler($"http://localhost:81/api/quizz");

//            var response = requestHandler.client.PostAsJsonAsync<Room>(finalUri, room, _token).Result;
//            if (response == null)
//            {
//                throw new ExceptionCreate("Ajout impossible");
//            }
//            return response;
//        }

//        public int AddDifficulty(Difficulty difficulty)
//        {
//            throw new NotImplementedException();
//        }

//        public int DeleteDifficulty(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public int UpdateDifficulty(Difficulty difficulty)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Technology> GetAllTechnologies()
//        {
//            throw new NotImplementedException();
//        }

//        public int AddTechnology(Technology technology)
//        {
//            throw new NotImplementedException();
//        }

//        public int DeleteTechnology(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public int UpdateTechnology(Technology technology)
//        {
//            throw new NotImplementedException();
//        }

//        public Difficulty GetDifficulty(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Technology GetTechnology(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
