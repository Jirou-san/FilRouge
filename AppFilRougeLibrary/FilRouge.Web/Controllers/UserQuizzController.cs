﻿using FilRouge.Model.Entities;
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
            ViewBag.Title = $"Quizz: {Quizz.Technology.Name}";

            var CurrentQuestionId = _quizzService.GetActiveQuestion(quizzId);
            var CurrentQuestion = _quizzService.getQuestionQuizz(quizzId, CurrentQuestionId);

            ViewBag.TitlePartialView = $"Question n°{CurrentQuestion.DisplayNum}";

            UserQuestionResponseModel userQuestionResponseModel = CurrentQuestion.MapToquestionResponseQuizzModel();


            return View(userQuestionResponseModel);
        }

        public ActionResult Play()
        {
            return View("");
        }



        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            int idQuizz = (int)TempData["quizzId"];

            return RedirectToAction("Index");
        }

    }
}