namespace FilRouge.Model.Interfaces
{
    using System.Collections.Generic;

    using FilRouge.Model.Entities;

    public interface IReferenceService
    {

        #region Technology
        Technology GetTechnology(int id);
        List<Technology> GetAllTechnologies();
        #endregion

        #region Difficulty
        Difficulty GetDifficulty(int id);
        List<Difficulty> GetAllDifficuties();
        #endregion
    }
}
