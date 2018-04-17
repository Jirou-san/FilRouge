
namespace FilRouge.API.Controllers
{
    using System.Net;
    using System.Web.Http;
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe Quizz Controleur permettant de gérer tous les contrôles possible sur un quizz
    /// Ou en tout cas les contrôles désirés
    /// </summary>
    [RoutePrefix("api/quizz")]
    [Authorize]
    public class QuizzController : ApiController
    {
        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IQuizzService quizzService;

        // A déclarer sur le container unity

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizzController"/> class.
        /// </summary>
        /// <param name="quizzservice">
        /// The quizzservice.
        /// </param>
        public QuizzController(IQuizzService quizzservice)
        {
            this.quizzService = quizzservice;
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

            this.quizzService.CreateQuizz(
                quizz.ContactId,
                quizz.TechnologyId,
                quizz.DifficultyId,
                quizz.UserLastName,
                quizz.UserFirstName,
                quizz.ExternalNum,
                quizz.QuestionCount);

            return this.StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Requête HTTP GET permettant de trouver un quizz par son ID
        /// </summary>
        /// <param name="id">ID du quizz en question</param>
        /// <returns>Retourne un statut OK ainsi que le contenue du quizz au format JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetQuizzId(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.quizzService.GetQuizById(id));
        }

        /// <summary>
        /// Requête HTTP POST permettan d'obtenir une liste de quizz répondant aux critères 
        /// Du quizz rentré dans le body
        /// </summary>
        /// <param name="filter">Filtre d'exécution</param>
        /// <returns>Tourne OK ainsi que la liste des quizz</returns>
        [Route("filter")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetQuizzFilter(Quizz filter)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.quizzService.GetQuizz(filter));
        }

        /// <summary>
        /// Requête HTTP GET permettatn d'obtenir tous les quizz pour un agent/administrateur
        /// </summary>
        /// <param name="contact">
        /// Le contact pour lequel on cherche la liste de quizz
        /// </param>
        /// <returns>
        /// Retourne le statut OK ainsi que le contenue de tous les quizz au format JSON
        /// </returns>
        [HttpPost]
        [Route("agent")]
        public IHttpActionResult GetAllQuizz(Contact contact)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.quizzService.GetAllQuizz(contact));
        }

        /// <summary>
        /// Requête HTTP GET permettant de récupérer tous les quizz
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllQuizz()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(this.quizzService.GetAllQuizz());
        }
    }
}
