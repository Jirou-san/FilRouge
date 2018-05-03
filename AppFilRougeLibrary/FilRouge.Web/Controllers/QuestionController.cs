﻿namespace FilRouge.Web.Controllers
{
    using FilRouge.Model.Entities;
    using FilRouge.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PagedList;
    using FilRouge.Web.Models;
    using FilRouge.Service;

    public class QuestionController : Controller
    {
        private IReferenceService _referenceService;
        private IQuestionResponseService _questionService;

        public QuestionController(IReferenceService service, IQuestionResponseService questionservice)
        {
            _referenceService = service;
            _questionService = questionservice;
        }

        // GET: Questions/
        public ViewResult Index(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.alert = TempData["Alert"];

            //Nb item per page
            int pageSize = 25;
            //Default page 
            int pageNumber = (page ?? 1);

            //Order filter
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DifficultySortParam = sortOrder == "Difficulty" ? "difficulty_desc" : "Difficulty";
            ViewBag.TechnologySortParam = sortOrder == "Technology" ? "technology_desc" : "Technology";

            ICollection<QuestionModels> questionModels = new List<QuestionModels>();
            var questions = _questionService.GetAllQuestions();
            @ViewBag.count = string.Format($"{questions.Count()} item(s) found");

            questions.ForEach(question => questionModels.Add(question.MapToQuestionModel()));
            switch (sortOrder)
            {
                case "id_desc":
                    //PROBLEM !!! FONCTION POUR DES STRING... donc 444 se place avant 5...
                    questionModels = questionModels.OrderByDescending(q => q.QuestionId).ToList();
                    break;
                case "Difficulty":
                    questionModels = questionModels.OrderBy(q => q.DifficultyName).ToList();
                    break;
                case "difficulty_desc":
                    questionModels = questionModels.OrderByDescending(q => q.DifficultyName).ToList();
                    break;
                case "Technology":
                    questionModels = questionModels.OrderBy(q => q.TechnologyName).ToList();
                    break;
                case "technology_desc":
                    questionModels = questionModels.OrderByDescending(q => q.TechnologyName).ToList();
                    break;
                default:
                    questionModels = questionModels.OrderBy(q => q.QuestionId).ToList();
                    break;
            }
            return View(questionModels.ToPagedList(pageNumber, pageSize));
        }

        // GET: Question/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = _questionService.ShowQuestion(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question.MapToQuestionViewModelFull());
        }

        // GET: Question/Create
        [HttpGet]
        public ActionResult Create()
        {
            var difficulties = _referenceService.GetAllDifficuties();
            var technologies = _referenceService.GetAllTechnologies();


            IEnumerable<SelectListItem> dropDownDifficulties = difficulties.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });

            IEnumerable<SelectListItem> dropDownTechnologies = technologies.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            });

            ViewBag.difficulties = dropDownDifficulties;
            ViewBag.technologies = dropDownTechnologies;

            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DifficultyId,TechnologyId,Content,IsEnable")] QuestionModels questionVM)
        {
            Question question = questionVM.MapToQuestion();
            if (ModelState.IsValid)
            {
                _questionService.AddQuestion(question);
            }
            //Redirect pour effectuer action detail et recharger url.
            return RedirectToAction("Details", new { id = question.Id });
        }

        // GET: Question/Delete/5
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var question = new Question();
            var questionModel = new QuestionModels();
            try
            {
                question = _questionService.GetQuestion(id);
                questionModel = question.MapToQuestionModel();
            }
            catch (NotFoundException e)
            {

                TempData["alert"] = string.Format($"Problême lors de la suppression de la Question (id: {id}");
            }
            return View(questionModel);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Question question)
        {
            var status = _questionService.DeleteQuestion(question.Id);

            if (question.Id == 0 || status == 0)
            {
                TempData["Alert"] = "Error: Problême durant la suppression de la question";
            }
            else
            {
                TempData["Alert"] = string.Format($"Success: suppression de la question (id:{question.Id}");
            }
            return RedirectToAction("Index");
        }
        // POST: Technology/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    service.DeleteQuestion(id);
        //    return RedirectToAction("Index");
        //}
        // GET: Technology/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Technology technology = db.Technology.Find(id);
        //    if (technology == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(technology);
        //}

        // GET: Question/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = _questionService.ShowQuestion(id);
            QuestionModels questionModel = new QuestionModels();

            if (question == null)
            {
                throw new NotFoundException("Question à editer non trouvée");
            }
            else
            {
                questionModel = question.MapToQuestionModel();

                //ordonne les listes pour afficher les valeurs de la question a editer, puis les autres valeurs disponibles.
                var difficulties = _referenceService.GetAllDifficuties().OrderByDescending(i => i.Id == question.Id).ThenBy(i => i.Id); 
                var technologies = _referenceService.GetAllTechnologies().OrderByDescending(i => i.Id == question.Id).ThenBy(i => i.Id);

                IEnumerable<SelectListItem> dropDownDifficulties = difficulties.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                });

                IEnumerable<SelectListItem> dropDownTechnologies = technologies.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });

                ViewBag.difficulties = dropDownDifficulties;
                ViewBag.technologies = dropDownTechnologies;
            }
            TempData["responses"] = question.Responses;
            return View(questionModel);
        }
        //TOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO DOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

        [HttpPost]
        public ActionResult Edit(QuestionModels questionModel)
        {
            Question question = questionModel.MapToQuestion();

           
            List <Response> originResponse = (List<Response>)TempData["responses"];
            List<Response> reponsesToUpdate = new List<Response>();
            var oldResponses = questionModel.Responses.Where(r => r.Id != 0);

            _questionService.UpdateQuestion(question);

            foreach (Response oldResponse in oldResponses)
            {
                if ((originResponse.Where(x=>x.Content != oldResponse.Content)).Count() == oldResponses.Count())
                {
                    reponsesToUpdate.Add(oldResponse);

                }
            }
            reponsesToUpdate.ForEach(r => _questionService.UpdateResponse(r));

            return RedirectToAction("Details", new { id = questionModel.QuestionId });
        }

        //// GET: Technology/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Technology technology = db.Technology.Find(id);
        //    if (technology == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(technology);
        //}

        //// POST: Technology/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Technology technology = db.Technology.Find(id);
        //    db.Technology.Remove(technology);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
