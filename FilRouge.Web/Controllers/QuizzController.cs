using FilRouge.Model.Entities;
using FilRouge.Services;
using FilRouge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilRouge.Model;
using FilRouge.Model.Models;

namespace FilRouge.Web.Controllers
{
    public class QuizzController : Controller
    {
        private ReferencesService service = new ReferencesService();
        //private QuizzService quizzService = new QuizzService();


        // GET: Quizz
        public ActionResult Index()
        {

            //j'affiche la page de la derniere question répondu ... si aucune question rep... page 1.

            ViewBag.test = "TEST REUSSI";
            return View();
        }

        // GET: Quizz/Play/5
        /*public ActionResult Play(int idQuizz)
        {
            var question = quizzService.GetLastQuestion(idQuizz);
            return PartialView("_question", question.MapToQuestionModel());
        }*/

        // GET: Quizz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quizz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quizz/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quizz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quizz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
