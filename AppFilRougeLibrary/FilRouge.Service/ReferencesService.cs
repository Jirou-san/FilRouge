using System.Collections.Generic;

namespace FilRouge.Service
{
    using FilRouge.Model.Entities;
    using FilRouge.Service;
    using System;
    using System.Linq;

    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe ReferencesService permettant d'utiliser les entités associés au Quizz
    /// Difficulté et Technologies
    /// </summary>
    public class ReferencesService : IReferenceService
    {

        protected FilRougeDBContext _db;
        public ReferencesService(FilRougeDBContext db)
        {
            _db = db;
        }

        #region Technology
        /// <summary>
        /// Recuperer une technology par son Id
        /// </summary>
        /// <param name="id"> id de la technology</param>
        /// <returns>Une technologie unique</returns>
        public Technology GetTechnology(int id)
        {
            var technology = _db.Technology.Find(id);
            return technology ?? throw new NotFoundException(string.Format($"No technology found with the id: {id}"));
        }

        /// <summary>
        /// Obtenir la liste de toute les technologies
        /// </summary>
        /// <returns>Une liste de technology/returns>
        public List<Technology> GetAllTechnologies()
        {
            return _db.Technology.ToList();
        }
        #endregion

        #region Difficulty
        /// <summary>
        /// Recupérer une difficulté par son id
        /// </summary>
        /// <param name="id"> l'id de la difficulté</param>
        /// <returns>Une difficulté (unique)</returns>
        public Difficulty GetDifficulty(int id)
        {
            var difficulty = _db.Difficulty.Find(id);
            return difficulty ?? throw new NotFoundException(string.Format($"No difficulty found with the id: {id}"));
        }

        /// <summary>
        /// obtenir la liste de toutes les difficultés
        /// </summary>
        /// <returns>liste de difficulté/returns>
        public List<Difficulty> GetAllDifficuties()
        {
            return _db.Difficulty.ToList(); ;
        }
        #endregion


    }
}

