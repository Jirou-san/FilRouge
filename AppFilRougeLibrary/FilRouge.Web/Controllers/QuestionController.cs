using FilRouge.Service;
using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilRouge.Model.Entities;

namespace FilRouge.Web.Controllers
{
    using FilRouge.Web.Models;

    public class QuestionController : Controller
    {
        private IReferenceService _referenceService;

        private IQuestionResponseService _questionService;
        public QuestionController(IReferenceService service, IQuestionResponseService questionservice)
        {
            _referenceService = service;
            _questionService = questionservice;
        }

        // GET: Questions/(All)
        public ActionResult Index()
        {

            return All();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id=0)
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

        // GET: Question/All
        public ActionResult All()
        {
            ICollection<QuestionModel> questionsVM = new List<QuestionModel>();
            var questions = _questionService.GetAllQuestions();
            if (questions == null)
            {
                return HttpNotFound();
            }

            questions.ForEach(question => questionsVM.Add(Map.MapToQuestionModel(question)));
            return View(questionsVM);
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
        public ActionResult Create([Bind(Include = "Content,Active,Difficulty,Technology")] QuestionModel questionVM)
        {
            Question question = questionVM.MapToQuestion();
            if (ModelState.IsValid)
            {
                _questionService.AddQuestion(question);
            }
            //Redirect pour effectuer action detail et recharger url.
            return RedirectToAction("Details", new { id = question.Id });
        }

        // GET: Technology/Delete/5
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete()
        {
            var questions = _questionService.GetAllQuestions();

            IEnumerable<SelectListItem> dropDownTechnologies = questions.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Content
            });
            return View();
        }

        // POST: Technology/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _questionService.DeleteQuestion(id);
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

        //// GET: Technology/Edit/5
        //public ActionResult Edit(int? id)
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

        //// POST: Technology/Edit/5
        //// Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        //// plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "TechnoId,TechnoName,Active")] Technology technology)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(technology).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(technology);
        //}

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
