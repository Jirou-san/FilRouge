namespace FilRouge.API.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe QuestionQuizzControleur permettant de gérer tous les contrôles possible sur une questionquizz
    /// Ou en tout cas les contrôles désirés
    /// </summary>
    [RoutePrefix("api/quizz")]
    [Authorize]
    public class QuestionQuizzController : ApiController
    {
        /// <summary>
        /// Interface permettant d'utiliser directement les méthodes qui lui sont associés
        /// Plutot que les classes
        /// </summary>
        private readonly IQuizzService _quizzService;

        public string message = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizzController"/> class.
        /// </summary>
        /// <param name="quizzservice">
        /// The quizzservice.
        /// </param>
        public QuestionQuizzController(IQuizzService quizzservice)
        {
            this._quizzService = quizzservice;
        }

    }
}
