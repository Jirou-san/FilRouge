namespace FilRouge.API.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors; // ajout MBa
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    [RoutePrefix("api/response")]
    [Authorize]
    public class ResponseController : ApiController
    {
        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IQuestionResponseService _questionResponseService;
        public string message = "";
        private Map mapping = new Map();
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceController"/> class.
        /// </summary>
        /// <param name="referenceService">
        /// The reference service.
        /// </param>
        public ResponseController(IQuestionResponseService questionResponseService)
        {
            this._questionResponseService = questionResponseService;
        }

        [HttpGet]
        [Route("{id")]
        public IHttpActionResult GetReponseById(int id)
        {
            return Ok(_questionResponseService.GetResponse(id));
        }

        [HttpGet]
        public IHttpActionResult GetAllReponses()
        {
           return Ok(_questionResponseService.GetAllResponses());
        }

        [HttpPost]
        public IHttpActionResult AddReponse(ReponseModel reponseVM)
        {
            try
            {
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }

        [HttpDelete]
        [Route("{id")]
        public IHttpActionResult DeleteReponse(int id)
        {
            try
            {
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }

        [HttpPatch]
        public IHttpActionResult UpdateReponse(ReponseModel reponseVM)
        {
            try
            {
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }
    }
}
