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

        /// <summary>
        /// Contrôleur permettant d'obtenir une réponse par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IHttpActionResult GetReponseById(int id)
        {
            return Ok(_questionResponseService.GetResponse(id));
        }

        /// <summary>
        /// Permet d'obtenir toutes les réponses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAllReponses()
        {
           return Ok(_questionResponseService.GetAllResponses());
        }

        /// <summary>
        /// Permet d'ajouter une réponse associé à une question
        /// </summary>
        /// <param name="reponseVM"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public IHttpActionResult AddReponse(ResponseModel reponseVM, int id)
        {
            try
            {
                _questionResponseService.AddResponse(mapping.MapToResponse(reponseVM),id);
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }

        /// <summary>
        /// Permet de supprimer une question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteReponse(int id)
        {
            try
            {
                _questionResponseService.DeleteResponse(id);
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            return Ok(message);
        }

        [HttpPatch]
        public IHttpActionResult UpdateReponse(ResponseModel reponseVM)
        {
            try
            {
                _questionResponseService.UpdateResponse(mapping.MapToResponse(reponseVM));
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
