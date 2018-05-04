
namespace FilRouge.API.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe Quizz Controleur permettant de gérer tous les contrôles possible sur les questions
    /// d'un quizz
    /// </summary>
    [RoutePrefix("api/question")]
    [Authorize]
    public class QuestionController : ApiController
    {
        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IQuestionResponseService questionService;
        public Map mapping = new Map();
        public string message = "";
        // A déclarer sur le container unity

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionControlleur"/> class.
        /// </summary>
        /// <param name="questionservice">
        /// The questionservice.
        /// </param>
        public QuestionController(IQuestionResponseService questionservice)
        {
            this.questionService = questionservice;
        }


        [HttpGet]
        [Route("quizz/{idquizz}")]
        public IHttpActionResult GetQuestionByQuizz(int idquizz)
        {
            return this.Ok(this.questionService.GetQuestionsByQuizz(idquizz));
        }

        /// <summary>
        /// Requête HTTP POST prenant en paramètre un contenue body qui sera casté en QuestionModel
        /// Il pourra ensuite être traité grâce à la fonction associée AddQuestion
        /// </summary>
        /// <param name="question">Corps de la requête renseignée sous format JSON</param>
        /// <returns>Retourne le code de status 201 - Created</returns>
        [HttpPost]
        public IHttpActionResult Create(QuestionModel questionVM)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            try
            {
                var newQuestion = mapping.MapToQuestion(questionVM);
                this.questionService.AddQuestion(newQuestion);
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
            

            return this.StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Requête HTTP DELETE permettant de supprimer une question par son ID
        /// </summary>
        /// <param name="id">Id de la question à supprimer</param>
        /// <returns>Retourne un statut OK ainsi que l'id de la ressource supprimée</returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.questionService.DeleteQuestion(id);
                message = "La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"ERROR: {e.Message}";
            }
           
            return this.Ok(id);
        }

        /// <summary>
        /// Requête HTTP GET permettant de trouver une question par son id
        /// </summary>
        /// <param name="id">ID de la question</param>
        /// <returns>Retourne un statut OK ainsi que le contenue de la questions au format JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetQuestionById(int id)
        {
            return this.Ok(this.questionService.GetQuestion(id));
        }

        /// <summary>
        /// Requête HTTP GET permettant de récupérer toutes les questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllQuestions()
        {
            return this.Ok(this.questionService.GetAllQuestions());
        }

        [HttpPatch]
        public IHttpActionResult UpdateQuestion(QuestionModel questionVM)
        {
            try
            {
                questionService.UpdateQuestion(mapping.MapToQuestion(questionVM));
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
