using System;
using WebGrease;

namespace FilRouge.API.Controllers
{
    using System.Net;
    using System.Web.Http;
    using FilRouge.API.Models;
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;

    /// <summary>
    /// Classe de contrôleur permettant de gérer les questionquizz
    /// </summary>
    [RoutePrefix("api/questionquizz")]
    [Authorize]
    public class QuestionQuizzController : ApiController
    {
        private string message = "";
        private readonly IQuestionQuizzService _questionQuizzService;
        private Map mapping = new Map();

        public QuestionQuizzController(IQuestionQuizzService questionQuizzService)
        {
            this._questionQuizzService = questionQuizzService;
        }

        /// <summary>
        /// Contrôleur permettant d'obtenir tous les questionquizz pour un quizz
        /// </summary>
        /// <param name="quizzId">L'id du quizz</param>
        /// <returns>Retourne la liste des questions quizz</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetAllQuestionQuizzByQuizz(int quizzId)
        {
            return Ok(_questionQuizzService.GetQuestionQuizz(quizzId));
        }

        /// <summary>
        /// Permet d'obtenir une question quizz par son ID 
        /// </summary>
        /// <param name="id">ID de la question quizz</param>
        /// <returns>La questionQuizz</returns>
        [Route("one/{id}")]
        [HttpGet]
        public IHttpActionResult GetQuestionQuizzById(int id)
        {
            return Ok(_questionQuizzService.GetQuestionQuizzById(id));
        }

        /// <summary>
        /// Contrôleur permettant d'ajouter une questionQuizz 
        /// </summary>
        /// <param name="questionQuizzVM">Le BODY de la requête HTTP</param>
        /// <returns>Un message d'erreur</returns>
        [HttpPost]
        public IHttpActionResult AddQuestionQuizz(QuestionQuizzModel questionQuizzVM)
        {
            try
            {
                _questionQuizzService.AddQuestionQuizz(mapping.MapToQuestionQuizz(questionQuizzVM));
                message = $"La ressource a bien été crée";
            }
            catch (Exception e)
            {
                message = $"La ressource n'a pas pu être crée";
            }

            return Ok(message);
        }

        /// <summary>
        /// Contrôleur permettant de supprimer une ressource
        /// </summary>
        /// <param name="id">Id de la ressource supprimée</param>
        /// <returns>Un message d'erreur</returns>
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteQuestionQuizz(int id)
        {
            try
            {
                _questionQuizzService.DeleteQuestionQuizz(id);
                message = $"La ressource a bien été supprimée";
            }
            catch (Exception e)
            {
                message = $"La ressource n'a pas pu être supprimée";
            }

            return Ok(message);
        }

        /// <summary>
        /// Met à jour une ressource
        /// </summary>
        /// <param name="questionQuizzVM">BODY de la requête HTTP</param>
        /// <returns>Retourne un message</returns>
        [HttpPatch]
        public IHttpActionResult UpdateQuestionQuizz(QuestionQuizzModel questionQuizzVM)
        {
            try
            {
                _questionQuizzService.UpdateQuestionQuizz(mapping.MapToQuestionQuizz(questionQuizzVM));
                message = $"La ressource a bien été mise à jour";
            }
            catch (Exception e)
            {
                message = $"La ressource n'a pas pu être mise à jour";
            }

            return Ok(message);
        }
    }
}