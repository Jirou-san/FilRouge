
namespace FilRouge.API.Controllers
{
    using System.Net;
    using System.Web.Http;
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe Quizz Controleur permettant de gérer tous les contrôles possible sur les questions
    /// d'un quizz
    /// </summary>
    [RoutePrefix("api/quizz")]
    [Authorize]
    public class QuestionControlleur : ApiController
    {
        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IQuestionResponseService questionService;

        // A déclarer sur le container unity

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionControlleur"/> class.
        /// </summary>
        /// <param name="questionservice">
        /// The questionservice.
        /// </param>
        public QuestionControlleur(IQuestionResponseService questionservice)
        {
            this.questionService = questionservice;
        }

        /// <summary>
        /// Requête HTTP POST prenant en paramètre un contenue body qui sera casté en QuizzModel
        /// Il pourra ensuite être traité grâce à la fonction associée CreateQuizz
        /// </summary>
        /// <param name="quizz">Corps de la requête renseignée sous format JSON</param>
        /// <returns>Retourne le code de status 201 - Created</returns>
        [HttpPost]
        [Route("create", Name = nameof(Create))]
        public IHttpActionResult Create(QuizzModel quizz)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            

            return this.StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Requête HTTP GET permettant de trouver une question par son ID
        /// </summary>
        /// <param name="id">ID de la question</param>
        /// <returns>Retourne un statut OK ainsi que le contenue de la question au format JSON</returns>
        [HttpGet]
        [Route("question/{id}")]
        public IHttpActionResult GetQuizzId(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            return this.Ok(this.questionService.GetQuestion(id));
        }

        /// <summary>
        /// Requête HTTP GET permettant de récupérer toutes les questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllQuizz()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.questionService.GetAllQuestions());
        }
    }
}
