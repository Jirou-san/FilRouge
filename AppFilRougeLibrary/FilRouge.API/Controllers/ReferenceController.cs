

namespace FilRouge.API.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors; // ajout MBa
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    [RoutePrefix("api/reference")]
    [Authorize]
    public class ReferenceController : ApiController
    {

        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IReferenceService _referenceService;
        public string message = "";
        private Map mapping = new Map();
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceController"/> class.
        /// </summary>
        /// <param name="referenceService">
        /// The reference service.
        /// </param>
        public ReferenceController(IReferenceService referenceService)
        {
            this._referenceService = referenceService;
        }
        #region Technology
        /// <summary>
        /// Controleur permettant d'obtenir toutes les technologies
        /// </summary>
        /// <returns>Le statut 200 OK et toutes les technologies au format JSON</returns>
        [Route("technologies")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetTechnologies()
        {
            return this.Ok(this._referenceService.GetAllTechnologies());
        }
        
        /// <summary>
        /// Ce contrôleur permet d'ajouter une technologie
        /// </summary>
        /// <param name="technologyVM">Corps de la requête HTTP pour une question</param>
        /// <returns>Retourne un statut Created 201</returns>
        [Route("technology")]
        [HttpPost]
        public IHttpActionResult AddTechnology(TechnologyModel technologyVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                _referenceService.AddTechnology(this.mapping.MapToTechnology(technologyVM));
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }

            
            return Ok(message);
        }

        /// <summary>
        /// Contrôleur permettant d'avoir une technologie par son ID
        /// </summary>
        /// <param name="id">L'id de la technologie</param>
        /// <returns>Retourn OK 200 et la technologie</returns>
        [Route("technology/{id}")]
        [HttpGet]
        public IHttpActionResult GetTechnology(int id)
        {
            return this.Ok(this._referenceService.GetTechnology(id));
        }

        /// <summary>
        /// Contrôleur permettant de supprimer une technologie
        /// </summary>
        /// <param name="id">L'ID de la technologie a supprimer</param>
        /// <returns>Retourne OK 200 et un message de suppression</returns>
        [Route("technology/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTechnology(int id)
        {
            try
            {               
                this._referenceService.DeleteTechnology(id);
                message = $"La ressource n°{id}a bien été supprimée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            
            return this.Ok(message);
        }

        /// <summary>
        /// Contrôleur permettant de mettre à jour une technologie
        /// </summary>
        /// <param name="technologyVM">Le corps de la requête HTTP</param>
        /// <returns>Retourne le statut OK 200 avec le message correspondant</returns>
        [Route("technology")]
        [HttpPatch]
        public IHttpActionResult UpdateTechnology(TechnologyModel technologyVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            Technology techno = this.mapping.MapToTechnology(technologyVM);
            try
            {
                this._referenceService.UpdateTechnology(techno);
                this.message = $"La ressource n°{techno.Id} a bien été mise à jour";
            }
            catch (Exception e)
            {
                this.message = $"ERROR: {e.Message}";
            }

            return this.Ok(this.message);
        }
        #endregion
        #region Difficulty

        /// <summary>
        /// Contrôleur permettant d'obtenir une difficulté par son ID
        /// </summary>
        /// <param name="id">l'ID de la difficulté</param>
        /// <returns>Un statut OK 200 avec un message personnalisé</returns>
        [Route("difficulty/{id}")]
        [HttpGet]
        public IHttpActionResult GetDifficulty(int id)
        {
            return this.Ok(this._referenceService.GetDifficulty(id));
        }

        /// <summary>
        /// Contrpileur permettant d'obtenir toutes les difficultés
        /// </summary>
        /// <returns>Un statut OK 200 avec le résultat de la requête HTTP</returns>
        [Route("difficulties")]
        [HttpGet]
        public IHttpActionResult GetDifficulties()
        {
            return this.Ok(this._referenceService.GetAllDifficuties());
        }

        /// <summary>
        /// Contrôleur permettant d'ajouter une difficulté
        /// </summary>
        /// <param name="difficultyVM">Le corps de la requête HTTP</param>
        /// <returns>Un statut OK 200 avec un message personnalisé</returns>
        [Route("difficulty")]
        [HttpPost]
        public IHttpActionResult AddDifficulty(DifficultyModel difficultyVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                _referenceService.AddDifficulty(this.mapping.MapToDifficulty(difficultyVM));
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }


            return Ok(message);
        }

        /// <summary>
        /// Controleur permettant de supprimer une difficulté
        /// </summary>
        /// <param name="id">l'ID de la difficulté</param>
        /// <returns>Un statut OK 200 avec un message personnalisé</returns>
        [Route("difficulty/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteDifficulty(int id)
        {
            try
            {               
                _referenceService.DeleteDifficulty(id);
                message = "La ressource a bien été supprimée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }

        /// <summary>
        /// Contrôleur permettant de mettre à jour une difficulté
        /// </summary>
        /// <param name="difficultyVM">Le corps de la requête HTTP</param>
        /// <returns>Un statut OK 200 avec un message personnalisé</returns>
        [Route("difficulty")]
        [HttpPatch]
        public IHttpActionResult UpdateDifficulty(DifficultyModel difficultyVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                Difficulty difficulty = mapping.MapToDifficulty(difficultyVM);
                _referenceService.UpdateDifficulty(difficulty);
                message = $"La ressource n°{difficulty.Id} a bien été mise à jour";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
                
            }
            return Ok(message);
        }
        #endregion
        #region DifficultyRate
        [Route("difficultyrate/{id}")]
        [HttpGet]
        public IHttpActionResult GetDifficultyRate(int id)
        {
            return this.Ok(this._referenceService.GetDifficultyRate(id));
        }
        #endregion
    }
}
