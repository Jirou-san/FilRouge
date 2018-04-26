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
                throw new NotFoundException(string.Format($"Aucune technologie ({id}) trouvée"));
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
                throw new NotFoundException(string.Format($"Aucune difficulté trouvé avec l'id: {id}"));
            }
            return difficulty;
        }

        /// <summary>
        /// Obtenir la liste de toutes les difficultés
        /// </summary>
        /// <returns>Liste de difficulté/returns>
        public List<Difficulty> GetAllDifficuties()
        {
            var difficulties = _db.Difficulty.ToList();
            return _db.Difficulty.ToList();
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

        #endregion

        #region DifficultyRate
        public DifficultyRate GetDifficultyRate(int id)
        {
            DifficultyRate difficultyRate = new DifficultyRate();
            try
            {
                difficultyRate = _db.DifficultyRate.Find(id);
                if (difficultyRate == null)
                {
                    throw new NotFoundException($"Aucun taux de difficulté n'a été trouvé avec l'id: {id}");
                }
            }
            catch (System.Exception e)
            {
                return null;
            }

            return difficultyRate;
        }

        public List<DifficultyRate> GetAllDifficultyRates()
        {
            List<DifficultyRate> difficultyRates = new List<DifficultyRate>();
            try
            {
                difficultyRates = _db.DifficultyRate.Select(e => e).ToList(); ;
                if (difficultyRates.Count == 0)
                {
                    throw new NotFoundException($"Aucun taux de difficulté n'a été trouvé");
                }
            }
            catch (System.Exception e)
            {
                return null;
            }

            return difficultyRates;
        }

        public int AddDifficultyRate(DifficultyRate difficultyrate)
        {
            int difficultyId = 0;
            try
            {
                _db.DifficultyRate.Add(difficultyrate);
                difficultyId = _db.SaveChanges();
            }
            catch (System.Exception e)
            {
                return 0;
            }


            return difficultyId;
        }

        public int DeleteDifficultyRate(int id)
        {
            var difficultyRate = new DifficultyRate() { Id = id };
            try
            {
                _db.DifficultyRate.Attach(difficultyRate);
                _db.DifficultyRate.Remove(difficultyRate);
            }
            catch (System.Exception e)
            {
                return 0;
            }


            return _db.SaveChanges();
        }

        public int UpdateDifficultyRate(DifficultyRate difficultyRate)
        {
            try
            {
                _db.Entry(difficultyRate).State = EntityState.Modified;
            }
            catch (System.Exception e)
            {
                return 0;
            }

            return _db.SaveChanges();
        }

        #endregion
    }
}

