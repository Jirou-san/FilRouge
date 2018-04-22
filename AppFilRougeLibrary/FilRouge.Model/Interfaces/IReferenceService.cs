namespace FilRouge.Model.Interfaces
{
    using System.Collections.Generic;
    using FilRouge.Model.Entities;

    public interface IReferenceService
    {
        #region Technology
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnologies();
        int AddTechnology(Technology technology);
        int DeleteTechnology(int id);
        int UpdateTechnology(Technology technology);
        #endregion

        #region Difficulty
        Difficulty GetDifficulty(int id);
        List<Difficulty> GetAllDifficuties();
        int AddDifficulty(Difficulty difficulty);
        int DeleteDifficulty(int id);
        int UpdateDifficulty(Difficulty difficulty);
        #endregion
    }
}
