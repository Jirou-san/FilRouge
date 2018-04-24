

namespace FilRouge.API.Controllers
{
    using System.Net;
    using System.Web.Http;
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

        /// <summary>
        /// Controleur permettant d'obtenir toutes les technologies
        /// </summary>
        /// <returns>Le statut 200 OK et toutes les technologies au format JSON</returns>
        [HttpGet]
        public IHttpActionResult GetTechnologies()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this._referenceService.GetAllTechnologies());
        }

        [HttpPost]
        public IHttpActionResult AddTechnology(TechnologyModel technologyVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            _referenceService.AddTechnology()

            return this.StatusCode(HttpStatusCode.Created);
        }

        
    }
}