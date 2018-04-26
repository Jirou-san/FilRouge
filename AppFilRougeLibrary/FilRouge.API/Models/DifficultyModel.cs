using FilRouge.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilRouge.API.Models
{
    #region Difficulty
    public class DifficultyModel
    {
        public int DisplayNum { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

    }
    public partial class Map
    {
        public Difficulty MapToDifficulty(DifficultyModel difficultyVM)
        {
            var difficulty = new Difficulty();
            if(difficultyVM == null)
            {
                return difficulty;
            }

            difficulty.DisplayNum = difficultyVM.DisplayNum;
            difficulty.Name = difficultyVM.Name;

            return difficulty;
        }

        public DifficultyModel MapToDifficultyModel(Difficulty difficulty)
        {
            var difficultyVM = new DifficultyModel();
            if (difficulty == null)
            {
                return difficultyVM;
            }

            difficultyVM.DisplayNum = difficulty.DisplayNum;
            difficultyVM.Name = difficulty.Name;

            return difficultyVM;
        }
    }
    #endregion

    #region DifficultyRate
    public class DifficultyRateModel
    {
        public int DifficultyQuizzId { get; set; }
        public int DifficultyQuestionId { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public Difficulty DifficultyQuizz { get; set; }
        public Difficulty DifficultyQuestion { get; set; }
    }

    public partial class Map
    {
        public DifficultyRate MapToDifficultyRate(DifficultyRateModel difficultyRateVM)
        {
            var difficultyRate = new DifficultyRate();
            if(difficultyRateVM == null)
            {
                return difficultyRate;
            }

            difficultyRate.Rate = difficultyRateVM.Rate;
            difficultyRate.DifficultyQuestionId = difficultyRateVM.DifficultyQuestionId;
            difficultyRate.DifficultyQuizzId = difficultyRateVM.DifficultyQuizzId;
            difficultyRate.DifficultyQuizz = difficultyRateVM.DifficultyQuizz;
            difficultyRate.DifficultyQuestion = difficultyRateVM.DifficultyQuestion;

            return difficultyRate;
        }

        public DifficultyRateModel MapToDifficultyRate(DifficultyRate difficultyRate)
        {
            var difficultyRateVM = new DifficultyRateModel();
            if(difficultyRate == null)
            {
                return difficultyRateVM;
            }

            difficultyRateVM.Rate = difficultyRate.Rate;
            difficultyRate.DifficultyQuestionId = difficultyRate.DifficultyQuestionId;
            difficultyRateVM.DifficultyQuizzId = difficultyRate.DifficultyQuizzId;
            difficultyRateVM.DifficultyQuizz = difficultyRate.DifficultyQuizz;
            difficultyRateVM.DifficultyQuestion = difficultyRate.DifficultyQuestion;

            return difficultyRateVM;
        }
    }
    #endregion
}