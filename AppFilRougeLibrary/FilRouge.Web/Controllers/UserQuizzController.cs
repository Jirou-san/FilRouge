using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;
using FilRouge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilRouge.Web.Controllers
{
    public class UserQuizzController : Controller
    {
        IQuizzService _quizzService;
        IQuestionResponseService _questionResponseService;


        public UserQuizzController(IQuizzService quizzService, IQuestionResponseService questionResponseService)
        {
            _quizzService = quizzService;
            _questionResponseService = questionResponseService;
        }


        // GET: UserQuizz
        public ActionResult Index(int quizzId)
        {
            var Quizz = _quizzService.GetQuizzById(quizzId);

            ViewBag.quizzId = quizzId;
            ViewBag.username = $"{Quizz.UserFirstName} {Quizz.UserLastName}";
            ViewBag.technology = Quizz.Technology.Name;
            ViewBag.date = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.Hour.ToString()}:{DateTime.Now.Minute.ToString()}";

            int CurrentQuestionId = _quizzService.GetActiveQuestion(quizzId);

            QuestionQuizz questionQuizz = Quizz.QuestionQuizz.Find(q => q.Id == CurrentQuestionId);
            UserQuestionResponseModel userQuestionResponseModel = questionQuizz.MapToquestionResponseQuizzModel();


            return View(userQuestionResponseModel);
        }

        public ActionResult Play( )
        {
            return View("");
        }

    }
} 