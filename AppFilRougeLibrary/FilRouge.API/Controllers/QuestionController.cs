
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
    [RoutePrefix("api/question")]
    [Authorize]
    public class QuestionController : ApiController
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
        public QuestionController(IQuestionResponseService questionservice)
        {
            this.questionService = questionservice;
        }


        [HttpGet]
        [Route("{idquizz}")]
        public IHttpActionResult GetQuestionByQuizz(int idquizz)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.questionService.GetQuestionsByQuizz(idquizz));
        }

        /// <summary>
        /// Requête HTTP POST prenant en paramètre un contenue body qui sera casté en QuestionModel
        /// Il pourra ensuite être traité grâce à la fonction associée AddQuestion
        /// </summary>
        /// <param name="question">Corps de la requête renseignée sous format JSON</param>
        /// <returns>Retourne le code de status 201 - Created</returns>
        [HttpPost]
        public IHttpActionResult Create(QuestionModel question)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newQuestion = new Question
                               {
                                   TechnologyId = question.TechnologyId,
                                   DifficultyId = question.DifficultyId,
                                   Content = question.Content,
                                   IsEnable = question.IsEnable,
                                   IsFreeAnswer = question.IsFreeAnswer
                               };
            this.questionService.AddQuestion(newQuestion);

            return this.StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Requête HTTP DELETE permettant de supprimer une question par son ID
        /// </summary>
        /// <param name="id">Id de la question à supprimer</param>
        /// <returns>Retourne un statut OK ainsi que l'id de la ressource supprimée</returns>
        [HttpDelete]
        [Route("{id}", Name = nameof(Delete))]
        public IHttpActionResult Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.questionService.DeleteQuestion(id);
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
        public IHttpActionResult GetAllQuestions()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.questionService.GetAllQuestions());
        }
    }
}
