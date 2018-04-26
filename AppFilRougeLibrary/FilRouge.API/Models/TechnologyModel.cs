using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilRouge.API.Models
{
    using System.ComponentModel.DataAnnotations;

    using FilRouge.Model.Entities;

    public class TechnologyModel
    {
        public int Id { get; set; }
        public int DisplayNum { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public partial class Map
    {
        public TechnologyModel MapToTechnologyModel(Technology technology)
        {
            var technoVM = new TechnologyModel();
            if (technology == null)
            {
                return technoVM;
            }

            technoVM.IsActive = technology.IsActive;
            technoVM.Name = technology.Name;
            technoVM.DisplayNum = technology.DisplayNum;

            return technoVM;
        }
        public Technology MapToTechnology(TechnologyModel technologyVM)
        {
            var techno = new Technology();
            if (technologyVM == null)
            {
                return techno;
            }

            techno.IsActive = technologyVM.IsActive;
            techno.Name = technologyVM.Name;
            techno.DisplayNum = technologyVM.DisplayNum;

            return techno;
        }
    }
}