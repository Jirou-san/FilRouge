using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FilRouge.Model.Entities;

namespace FilRouge.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public struct TechnologyModel
    {
        public int Id { get; set; }
        [Display(Name = "Nom", Prompt = "Entrez une technology", Description = "Technology")]
        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DisplayNum { get; set; }
    }

    //Classe partielle Map servant à passer d'un viewModel à un Model et inversement
    public static partial class Map
    {
        public static TechnologyModel MapToTechnologyModel(this Technology technology)
        {
            var technologyModel = new TechnologyModel();

            if (technology == null)
                return technologyModel;

            technologyModel.Id = technology.Id;
            technologyModel.Name = technology.Name;
            technologyModel.IsActive = technology.IsActive;
            technologyModel.DisplayNum = technology.DisplayNum;

            return technologyModel;
        }

        public static Technology MapToTechnology(this TechnologyModel technologyModel)
        {
            var technology = new Technology
            {
                Id = technologyModel.Id,
                Name = technologyModel.Name,
                IsActive = technologyModel.IsActive,
                DisplayNum = technologyModel.DisplayNum
            };

            return technology;
        }
    }
}