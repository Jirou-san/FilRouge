namespace FilRouge.Service
{
    using FilRouge.Model.Entities;
    using System.Linq;
    using FilRouge.Model.Interfaces;
    using System.Collections.Generic;
    using System.Data.Entity;

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
        /// Obtenir une technology par son Id
        /// </summary>
        /// <param name="id"> id de la technology</param>
        /// <returns>Une technologie unique</returns>
        public Technology GetTechnology(int id)
        {
            var technology = _db.Technology.Find(id);
            if (technology == null)
            {
                 throw new NotFoundException(string.Format($"Aucune technologie ({id}) trouvée" ));
            }
            return technology;
        }

        /// <summary>
        /// Obtenir la liste de toute les technologies
        /// </summary>
        /// <returns>Une liste de technology/returns>
        public List<Technology> GetAllTechnologies()
        {
            return _db.Technology.ToList();
        }

        /// <summary>
        /// Insérer une technologie
        /// </summary>
        /// <returns>L'id de la technologie insérée/returns>
        public int AddTechnology(Technology technology)
        {
            _db.Technology.Add(technology);
            return _db.SaveChanges();
        }

        /// <summary>
        /// Supprimer une technologie
        /// </summary>
        /// <returns>L'id de la technologie supprimée/returns>
        public int DeleteTechnology(int id)
        {
            var technology = new Technology() { Id = id };

            _db.Technology.Attach(technology);
            _db.Technology.Remove(technology);

            return _db.SaveChanges();
        }

        /// <summary>
        /// Mettre à jour une technologie
        /// </summary>
        /// <returns>L'id de la technologie mis à jour/returns>
        public int UpdateTechnology(Technology technology)
        {
            _db.Entry(technology).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        #endregion


        #region Difficulty

        /// <summary>
        /// Obtenir une difficulté par son id
        /// </summary>
        /// <param name="id"> l'id de la difficulté</param>
        /// <returns>Une difficulté (unique)</returns>
        public Difficulty GetDifficulty(int id)
        {
            var difficulty = _db.Difficulty.Find(id);
            if (difficulty == null)
            {
                throw new NotFoundException(string.Format($"No difficulty found with the id: {id}"));
            }
            return difficulty;
        }

        /// <summary>
        /// Obtenir la liste de toutes les difficultés
        /// </summary>
        /// <returns>Liste de difficulté/returns>
        public List<Difficulty> GetAllDifficuties()
        {
            return _db.Difficulty.ToList(); ;
        }

        /// <summary>
        /// Insérer une difficulté
        /// </summary>
        /// <returns>L'id de la diffulté insérée/returns>
        public int AddDifficulty(Difficulty difficulty)
        {
            _db.Difficulty.Add(difficulty);
            return _db.SaveChanges();
        }

        public int AddDifficultyRate(DifficultyRate difficultyRate)
        {
            _db.DifficultyRate.Add(difficultyRate);
            return _db.SaveChanges();
        }
        /// <summary>
        /// Supprimer une difficulté
        /// </summary>
        /// <returns>L'id de la diffulté supprimée/returns>
        public int DeleteDifficulty(int id)
        {
            var difficulty = new Difficulty() { Id = id };

            _db.Difficulty.Attach(difficulty);
            _db.Difficulty.Remove(difficulty);

            return _db.SaveChanges();
        }

        /// <summary>
        /// Mettre à jour une difficulté
        /// </summary>
        /// <returns>L'id de la difficulté mis à jour/returns>
        public int UpdateDifficulty(Difficulty difficulty)
        {
            _db.Entry(difficulty).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public DifficultyRate GetDifficultyRate(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<DifficultyRate> GetAllDifficultyRates()
        {
            throw new System.NotImplementedException();
        }

        public int AddDifficulty(DifficultyRate difficultyrate)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteDifficultyRate(int id)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateDifficultyRate(DifficultyRate difficultyRate)
        {
            throw new System.NotImplementedException();
        }
        #endregion


    }
}

